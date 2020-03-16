using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameHandle : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform playerTransform;
    void Start()
    {
        cameraFollow.Setup(() => playerTransform.position);
    }

    void Update()
    {
        
    }
}
