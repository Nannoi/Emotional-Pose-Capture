using TMPro;
using UnityEngine;

public class BallAttachment : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform humanoidModel;
    public int numberOfBalls;

    public GameObject pointA;
    public GameObject pointB;

    public GameObject pointC;
    public GameObject pointD;

    public GameObject pointE;
    public GameObject pointF;


    private GameObject[] balls;
    private Mesh bakedMesh;

    // Define an array of modified pastel colors
    private Color[] pastelColors = new Color[]
    {
        new Color(0.9f, 0.9f, 0.4f), // Yellow Pastel (Modified from Green)
        new Color(0.9f, 0.4f, 0.4f), // Pink (Modified from Red)
        new Color(0.4f, 0.7f, 0.9f), // Baby Blue (Modified from Blue)
        // Add more colors as needed
    };

    void Start()
    {
        balls = new GameObject[numberOfBalls];
        bakedMesh = new Mesh();
        AttachBallsToMesh();
    }

    void AttachBallsToMesh()
    {
        Mesh mesh = humanoidModel.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh;

        for (int i = 0; i < numberOfBalls; i++)
        {
            Vector3 randomPointOnMesh = GetRandomPointOnMesh(mesh);
            GameObject ball = Instantiate(ballPrefab, randomPointOnMesh, Quaternion.identity);

            // Parent the ball to the humanoid model
            ball.transform.parent = humanoidModel;
            balls[i] = ball;
        }
    }

    void Update()
    {
        // Update length based on the current positions of pointA and pointB
        Vector3 direction = pointB.transform.position - pointA.transform.position;
        float length = direction.magnitude;

        Vector3 directionCD = pointD.transform.position - pointC.transform.position;
        float lengthCD = directionCD.magnitude;

        Vector3 directionEF = pointE.transform.position - pointF.transform.position;
        float lengthEF = directionEF.magnitude;


        // Bake the current pose of the skinned mesh into a new mesh
        humanoidModel.GetComponentInChildren<SkinnedMeshRenderer>().BakeMesh(bakedMesh);

        // Calculate overall scale based on lengthCD
        float overallScale = Mathf.Lerp(0.5f, 2f, lengthCD / 5f);

        // Update ball positions and colors based on the baked mesh
        for (int i = 0; i < numberOfBalls; i++)
        {
            if (balls[i] != null)
            {
                Vector3 randomPointOnMesh = GetRandomPointOnMesh(bakedMesh);
                balls[i].transform.position = randomPointOnMesh;

                // Set random size for each ball
                float randomSize = Random.Range(0.1f, 0.6f);
                balls[i].transform.localScale = new Vector3(randomSize * overallScale, randomSize * overallScale, randomSize * overallScale);

                // Set modified pastel color based on the updated length
                Renderer ballRenderer = balls[i].GetComponent<Renderer>();
               
                
               ballRenderer.material.color = GetRandomPastelColor(lengthEF,pointA.transform,pointB.transform,pointE.transform,pointF.transform);
                
                
            }
        }
    }



    Vector3 GetRandomPointOnMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        int randomVertexIndex = Random.Range(0, vertices.Length);

        Vector3 randomPoint = vertices[randomVertexIndex];

        return humanoidModel.TransformPoint(randomPoint);
    }

    Color GetRandomPastelColor(float length, Transform pointA, Transform pointB, Transform pointE, Transform pointF)
    {
        // If the length between pointA and pointB is more than 7, change the color
        if (length > 2.0f && pointA.position.y >= pointE.position.y-0.2f && pointB.position.y >= pointF.position.y - 0.2f)
        {
            // Choose a random modified pastel color from the predefined array
            Color randomColor = pastelColors[Random.Range(0, pastelColors.Length)];

            // Interpolate between gray and the random color over time
            float t = Mathf.Clamp01((length - 2.0f) / 2f); // Adjust the range for fading
            return Color.Lerp(Color.gray, randomColor, t);
        }
        else
        {
            // Return gray color (you can adjust this to any other color you prefer)
            return Color.Lerp(Color.gray, Color.white, 0.2f);
        }
    }

}
