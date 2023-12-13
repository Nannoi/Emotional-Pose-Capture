using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private float length;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between pointA and pointB
        length = Vector3.Distance(pointA.transform.position, pointB.transform.position);

        // Calculate the new scale based on the distance
        float scaleValue = length * 3f;

        // Set the local scale of the object
        this.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}
