using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Vector3 rotation = new Vector3(45, 0, 0);

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
