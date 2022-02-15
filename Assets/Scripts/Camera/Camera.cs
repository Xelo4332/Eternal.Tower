using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform _player;
    private Vector3 _offset;
    // Start is called before the first frame update
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
