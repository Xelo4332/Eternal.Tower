using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Script for camera player follow Kacper
    void Update()
    {
        transform.position = PlayerMove.transform.position + new Vector3(0, 0, -10);
    }
}
