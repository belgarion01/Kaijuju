using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform mainCamera;
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    
    void LateUpdate()
    {
        //transform.LookAt(mainCamera.position, -Vector3.up);
        
    }
}
