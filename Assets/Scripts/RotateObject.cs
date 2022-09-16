using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationAngle;

    private void Update()
    {
        transform.Rotate(transform.up, rotationAngle * Time.deltaTime * rotationSpeed);
    }
}
