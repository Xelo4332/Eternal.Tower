using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Martin
public class HealthBar : MonoBehaviour
{
    //Skapar Field s� vi l�gga v�ra current, total health UI och field s� vi kan l�gga v�ran health script i denna UI 
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    //Bereonde p� hur mycket vi valde p� starting health, s� kommer den fillas av hur mycket starting health v�de har 
    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

}
