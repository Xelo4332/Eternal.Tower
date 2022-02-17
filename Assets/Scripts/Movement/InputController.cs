using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour
{

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CombatController _combatController;
   
    private float _horizontal;




    //This method is for movement to activate Attack, Move and Turn
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _playerMovement.Move(_horizontal);
        _playerMovement.Turn(_horizontal);

  
            
     
       if (Input.GetKeyDown(KeyCode.Space))
       {
     
                _combatController.Attack();

                
       }
    }
    
    //Changing player direction if Movedirection is bigger then 0 or not
    public void Turn(float moveDirection)
    {
        if (moveDirection > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        if (moveDirection < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
           
    }


}
