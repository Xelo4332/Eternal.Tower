using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] private Vector3 _playerStartPosition;
    private void Start()
    {

    }

    private void SetPlayerPosition()
    {
        Health player = FindObjectOfType<Health>();
        player.transform.position = _playerStartPosition;
    }
}
