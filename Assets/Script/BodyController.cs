using UnityEngine;

public class BodyController : MonoBehaviour
{
    // Reference to your rigged humanoid model
    public GameObject humanoidModel;

    // Array to store the transforms of bones in the humanoid model
    public Transform[] boneTransforms;

    // Array to store the point landmarks
    public Transform[] pointLandmarks;

    public int[,] landmarkConnections = new int[,]
   {
    //{2, 3},
    //{6, 5},
    // {0,1}
    //{1, 2}, 
    //{3, 7},
    //{0, 0},
    //{5, 4},   
    //{6, 8},
    {3, 6},
    {9, 10},
    //{11, 23},
    //{11, 13},
    //{13, 15},
    {12, 11},
    //{12, 24},
    //{12, 14},
    //{14, 16},
    //{15, 17},
    //{15, 19},
    //{15, 21},
    //{16, 18},
    //{16, 20},
    //{18, 20},
    //{16, 22},
    //{17, 19},
    {23, 24},
    //{23, 25},
    //{25, 27},
    //{27, 29},
    //{27, 31},
    //{29, 31},
    //{24, 26},
    //{26, 28},
    //{28, 30},
    //{28, 32},
    //{30, 32}// Connect landmark at index 1 to landmark at index 2
            // Add more connections as needed
   };

    void Update()
    {
        // Update bone positions based on the connections between point landmarks
        for (int i = 0; i < landmarkConnections.GetLength(0); i++)
        {
            int pointIndexA = landmarkConnections[i, 0];
            int pointIndexB = landmarkConnections[i, 1];

            Transform boneTransform = boneTransforms[i];
            
            Transform pointA = pointLandmarks[pointIndexA];
            Transform pointB = pointLandmarks[pointIndexB];

            // Update the bone position based on the average position of the connected landmarks
            if (boneTransform != null && pointA != null && pointB != null)
            {
               
                // Set the bone position to the position of pointA
                boneTransform.position = (pointA.position+pointB.position)/2f;
                if (i > 0)
                {
                    Transform nextboneTransform = pointLandmarks[i - 1];
                    // Calculate the direction from pointA to pointB
                    Vector3 direction = boneTransform.position - nextboneTransform.position;

                    // Rotate the bone to align with the direction vector
                    boneTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);

                    // Alternatively, if you want to keep the Up vector of the bone constant
                    //boneTransform.rotation = Quaternion.LookRotation(direction, boneTransform.up);
                }
                else if (i==0)
                {
                    Transform beforeboneTransform = pointLandmarks[i + 1];
                    // Calculate the direction from pointA to pointB
                    Vector3 direction = beforeboneTransform.position - boneTransform.position;

                    // Rotate the bone to align with the direction vector
                    boneTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);

                    // Alternatively, if you want to keep the Up vector of the bone constant
                    //boneTransform.rotation = Quaternion.LookRotation(direction, boneTransform.up);
                }
            }
        }
    }
}
