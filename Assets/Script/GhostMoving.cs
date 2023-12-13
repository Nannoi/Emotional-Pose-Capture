using UnityEngine;
using System.Collections;

public class GhostMoving : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed of the ghost movement
    public float amplitude = 1.0f; // Adjust the vertical range of motion
    public Material shader;
    private bool isFading = true;

    private float initialY;
    private Color initialFresnelColor;

    void OnEnable()
    {
        // Store the initial local Y position of the ghost
        initialY = transform.localPosition.y;

        // Store the initial Fresnel color
        initialFresnelColor = shader.GetColor("_FresnelColor");

        // Start the fade-in coroutine only when the script is enabled
        StartCoroutine(FadeIn());
    }

    void OnDisable()
    {
        // Reset the Fresnel color to fully transparent when the script is disabled
        shader.SetColor("_FresnelColor", new Color(initialFresnelColor.r, initialFresnelColor.g, initialFresnelColor.b, 0f));
    }

    void Update()
    {
        // Calculate the vertical movement using a sine wave
        float verticalMovement = Mathf.Sin(Time.time * speed) * amplitude;

        // Update the local position of the ghost (only considering the Y-axis)
        transform.localPosition = new Vector3(transform.localPosition.x, initialY + verticalMovement, transform.localPosition.z);
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        float fadeDuration = 3.0f; // Adjust the duration of the fade-in

        while (elapsedTime < fadeDuration)
        {
            // Interpolate between black and initialFresnelColor with alpha 1
            Color newColor = Color.Lerp(Color.black, new Color(initialFresnelColor.r, initialFresnelColor.g, initialFresnelColor.b, 1f), elapsedTime / fadeDuration);

            // Apply the new color to the material's Fresnel color
            shader.SetColor("_FresnelColor", newColor);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final alpha value is 1
        shader.SetColor("_FresnelColor", new Color(initialFresnelColor.r, initialFresnelColor.g, initialFresnelColor.b, 1f));

        // Set the fading flag to false
        isFading = false;
    }
}
