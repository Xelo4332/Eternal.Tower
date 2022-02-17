using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deni
public class BossFightManager : MonoBehaviour
{
    [SerializeField] private Vector3 _playerStartPosition;

    //Activates method
    private void Start()
    {
        SetPlayerPosition();
    }

    //Spawning poistion and searching health component
    private void SetPlayerPosition()
    {
        Health player = FindObjectOfType<Health>();
        player.transform.position = _playerStartPosition;
    }
}
