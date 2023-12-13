using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EmotionManager : MonoBehaviour
{
    //ReferencePoint
    public GameObject LpointA;
    public GameObject LpointB;
    public GameObject LpointC;
    public GameObject LpointD;
    public GameObject LpointE;
    public GameObject LpointF;
    public GameObject LpointH;
    public Material LightBall;

    public Light directlight;
    public TMP_Text description;

    //love Section
    public GameObject Love;

    // Sad Section
    public GameObject Snow;

    // Happy Section
    public GameObject Butterfly;

    //Angry Section
    public GameObject Angry;

    //Excited
    public GameObject Confetti;

    //Fear
    public GameObject Ghost;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //love
        Vector3 DisLoveAB = LpointA.transform.position - LpointB.transform.position;
        Vector3 DisLoveCD = LpointC.transform.position - LpointD.transform.position;
        Vector3 DisLoveEF = LpointE.transform.position - LpointF.transform.position;

        //love
        if (LpointA.transform.position.y > LpointC.transform.position.y && LpointB.transform.position.y > LpointD.transform.position.y
            && LpointH.transform.position.y < LpointA.transform.position.y && LpointH.transform.position.y < LpointB.transform.position.y &&
            DisLoveAB.magnitude < DisLoveCD.magnitude)
        {
            Love.transform.position = LpointH.transform.position;
            Love.SetActive(true);
            Snow.SetActive(false);
            Butterfly.SetActive(false);
            Angry.SetActive(false);
            Ghost.SetActive(false);
            Confetti.SetActive(false);

            LightBall.SetColor("_EmissionColor", new Color(1.0f, 0.2f, 0.67f)); // Change to pink
            directlight.color = Color.white; // Lighter pink
            description.text = "You are in love.";
        }
        //sad
        else if (LpointA.transform.position.y < LpointC.transform.position.y && LpointB.transform.position.y < LpointD.transform.position.y
            && DisLoveAB.magnitude * 2f < DisLoveEF.magnitude)
        {
            Snow.transform.position = LpointH.transform.position + new Vector3(0, 5, 0);
            Snow.SetActive(true);
            Love.SetActive(false);
            Butterfly.SetActive(false);
            Angry.SetActive(false);
            Ghost.SetActive(false);
            Confetti.SetActive(false);

            LightBall.SetColor("_EmissionColor", new Color(0.25f, 0.62f, 0.88f)); // Change to light blue
            directlight.color = new Color(0.6f, 0.7f, 0.9f); // Lighter light blue
            description.text = "You are sad.";
        }
        //happy
        else if (LpointA.transform.position.y - LpointC.transform.position.y >= -0.3f && LpointA.transform.position.y - LpointC.transform.position.y <= 0.3f &&
         LpointA.transform.position.y - LpointE.transform.position.y >= -0.3f && LpointB.transform.position.y - LpointF.transform.position.y >= -0.3f &&
         DisLoveAB.magnitude > DisLoveCD.magnitude)
        {
            Butterfly.transform.position = LpointH.transform.position + new Vector3(0, -1, 0);
            Butterfly.SetActive(true);
            Love.SetActive(false);
            Snow.SetActive(false);
            Angry.SetActive(false);
            Ghost.SetActive(false);
            Confetti.SetActive(false);

            LightBall.SetColor("_EmissionColor", new Color(1.0f, 0.7f, 0.0f)); // Lighter and more orange
            directlight.color = Color.white; // Lighter yellow
            description.text = "You are happy.";
        }
        //angry
        else if (LpointA.transform.position.y < LpointE.transform.position.y && LpointB.transform.position.y < LpointF.transform.position.y
            && LpointH.transform.position.y > LpointA.transform.position.y && LpointH.transform.position.y > LpointB.transform.position.y &&
            DisLoveAB.magnitude - DisLoveEF.magnitude >= -0.3f && DisLoveAB.magnitude - DisLoveEF.magnitude <= 0.3f&& DisLoveCD.magnitude>DisLoveAB.magnitude*2)
        {
            Angry.transform.position = LpointH.transform.position;
            Butterfly.SetActive(false);
            Love.SetActive(false);
            Snow.SetActive(false);
            Angry.SetActive(true);
            Ghost.SetActive(false);
            Confetti.SetActive(false);

            LightBall.SetColor("_EmissionColor", Color.red);
            directlight.color = new Color(0.9f, 0.5f, 0.5f); // Lighter red
            description.text = "You are angry.";
        }
        //fear
        else if (LpointA.transform.position.y > LpointC.transform.position.y && LpointB.transform.position.y > LpointD.transform.position.y
           && LpointH.transform.position.y > LpointA.transform.position.y && LpointH.transform.position.y > LpointB.transform.position.y && DisLoveAB.magnitude <= 2.0f)
        {
            Ghost.transform.position = LpointH.transform.position;
            Butterfly.SetActive(false);
            Love.SetActive(false);
            Snow.SetActive(false);
            Angry.SetActive(false);
            Ghost.SetActive(true);
            Confetti.SetActive(false);

            LightBall.SetColor("_EmissionColor", new Color(0.07f, 0.1f, 0.4f)); // Purple Lavender
            directlight.color = Color.grey; // Lighter red
            description.text = "You are scared.";
        }
        //excited
        else if (LpointA.transform.position.y > LpointC.transform.position.y && LpointA.transform.position.y > LpointC.transform.position.y &&
         LpointA.transform.position.y > LpointE.transform.position.y && LpointB.transform.position.y > LpointF.transform.position.y &&
         DisLoveAB.magnitude > DisLoveCD.magnitude)
                {
            Confetti.transform.position = LpointH.transform.position + new Vector3(0, 1, 0);
            Butterfly.SetActive(false);
            Love.SetActive(false);
            Snow.SetActive(false);
            Angry.SetActive(false);
            Ghost.SetActive(false);
            Confetti.SetActive(true);

            LightBall.SetColor("_EmissionColor", new Color(0.18f, 1.0f, 0.0f)); // Lighter and more orange
            directlight.color = Color.white; // Lighter yellow
            description.text = "You are excited.";
        }

        else
        {
            Love.SetActive(false);
            Snow.SetActive(false);
            Butterfly.SetActive(false);
            Angry.SetActive(false);
            Ghost.SetActive(false);
            Confetti.SetActive(false);

            LightBall.SetColor("_EmissionColor", Color.white);
            directlight.color = Color.white; // Change light color
            description.text = "Change your posture to express your emotion.";
        }
    }
}
