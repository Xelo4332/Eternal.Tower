using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashManager : MonoBehaviour
{
    [Header("Cooldown")]
    [SerializeField] private float dashCooldown;
    [Header("Force")]
    [SerializeField] private float dashForce;

    //We need InputController because in this script in Update function every frame change rb.velocity Julian
    private InputController inputController;

    //It's 'true' if dash is cooldown
    private bool isDashCooldown;
    private Rigidbody2D rb;

    private void Start()
    {
        inputController = GetComponent<InputController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Dash();
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //If dash is cooldown then we exit from this function Julian
            if (isDashCooldown)
            {
                return;
            }

            //We need disable InputController before Dash, because in this script change rb.velocity in Update function Deni
            inputController.enabled = false;

            //We calculate dashDirection, Mathf.Sign help us to get math symbol of transform.localScale.x (it's + or -) Julian
            Vector2 dashDirection = new Vector2(Mathf.Sign(transform.localScale.x) * dashForce, 0);
            //We use AddForce to push our player, and we use ForceMode2D.Impulse for impulse after push Julian
            rb.AddForce(dashDirection, ForceMode2D.Impulse);

            //This coroutine enable InputController after 0.5 seconds Deni
            StartCoroutine(ActiveInputController());

            isDashCooldown = true;
            StartCoroutine(DashCooldown());
        }
    }

    private IEnumerator DashCooldown() //Cooldown for dash Julian
    {
        //If dash is not cooldown then we exit from this Coroutine
        if (!isDashCooldown)
        {
            yield break;
        }

        yield return new WaitForSeconds(dashCooldown);
        isDashCooldown = false;
    }

    private IEnumerator ActiveInputController() //Activating Inpurtcontroller script
    {
        yield return new WaitForSeconds(0.5f);
        inputController.enabled = true;
    }
}