using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathBox : MonoBehaviour
{
    private Health playerhealth;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            print("bruh");
            SceneManager.LoadScene("GameOver");

        }
    }
}