using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Script for camera player follow
    void Update()
    {
        transform.position = PlayerMove.transform.position + new Vector3(0, 0, -10);
    }
}
