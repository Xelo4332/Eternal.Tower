using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Casper
public class Camera : MonoBehaviour
{

   
    //Variables for our transform
    private Transform _player;
    private Vector3 _offset;
    
    void Start()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _offset = transform.position - _player.position;
    }

    //Script for camera player follow
    private void LateUpdate()
    {
       
        transform.position = _player.position + _offset;
    }

    
}
