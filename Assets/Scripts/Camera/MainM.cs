using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainM : MonoBehaviour
{
    //Loader våran spel scene julian
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    //Loader våran options scene julian
    public void Instruct()
    {
        SceneManager.LoadScene("Instruct");
    }
    //Gör att man gå från spelet, men Scripten är inte helt klart Julian
    public void QuitGame()
    {
        Application.Quit();
    }
}
