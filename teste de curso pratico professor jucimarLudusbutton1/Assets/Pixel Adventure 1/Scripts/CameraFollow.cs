using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPositionFunc;
    

    public void Setup(Func<Vector3> GetcameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetcameraFollowPositionFunc;
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;
        cameraFollowPosition.x = transform.position.x;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 4f;
        transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

    }
}
