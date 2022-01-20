using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainM : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    
    public void Instruct ()
    {
        SceneManager.LoadScene("Instruct");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
