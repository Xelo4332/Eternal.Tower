using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputController : MonoBehaviour
{

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CombatController _combatController;
    [SerializeField] private AudioClip meleeAttackSound;
    private float _horizontal;
    private Animator anim;
    [SerializeField] public float cooldownTime = 1;
    private float nextAttack = 0;
    private void Start()
    {
        anim = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        if (Time.time > nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("COOLDOWN STARTED");
                _combatController.Attack();
                anim.SetTrigger("MeleeAttack");
                SoundManager.instance.PlaySound(meleeAttackSound);
                nextAttack = Time.time + cooldownTime;
            }
        }
    }
    
    private void Update()
    {//Det �r f�r alla keybinds f�r movement, attack, parry och jump och n�gra animationer ligger h�r
        _horizontal = Input.GetAxis("Horizontal");
        _playerMovement.Move(_horizontal);
        _playerMovement.Turn(_horizontal);

        
        
    }

    public void Turn(float moveDirection) //Rotarar v�ran karakt�r Kacper
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
