using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour
{

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CombatController _combatController;
    private float _horizontal;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _playerMovement.Move(_horizontal);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerMovement.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _combatController.Attack();

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _combatController.Parry();
        }

    }

    
  
}
