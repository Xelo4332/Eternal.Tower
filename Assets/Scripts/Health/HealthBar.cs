using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Martin
public class HealthBar : MonoBehaviour
{
    //Skapar Field så vi lägga våra current, total health UI och field så vi kan lägga våran health script i denna UI 
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    //Bereonde på hur mycket vi valde på starting health, så kommer den fillas av hur mycket starting health väde har 
    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

}
