using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    void Update()
    {
        // Calculate the direction from pointA to pointB
        Vector3 direction = pointB.position - pointA.position;

        // Calculate the rotation quaternion to face the direction
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.position = pointA.position;
        // Set the object's rotation to the target rotation instantly
        transform.rotation = targetRotation;
    }
}