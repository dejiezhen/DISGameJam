using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockRotate : MonoBehaviour
{
    [Tooltip("how fast the balloons are rotating")]
    public float rotationSpeed = 0;
    private float count = 0;

    void Update()
    {

        count++;
        if (count >= 8)
        {
            rotationSpeed++;
            count = 0;
        }
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);
    }
}
