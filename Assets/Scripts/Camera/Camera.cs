using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Kacper
    private Transform _player;
    
    //Hittar player object 

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Script for camera player follow
    private void LateUpdate()
    {
        transform.position = _player.position - new Vector3 (0, 0 , 10);
    }
}
