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
    [SerializeField]public float cooldownTime = 1;
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
    //Det är för alla keybinds för movement, attack, parry och jump och några animationer ligger här
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _playerMovement.Move(_horizontal);
        
        //Rotarar våran karaktär Kacper
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
    }



}
