using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    float speed = 50f;
    void Start()
    {
        
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * -horizontalInput);
    }
}
