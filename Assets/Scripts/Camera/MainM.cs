using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainM : MonoBehaviour
{
    //Loader v�ran spel scene julian
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    //Loader v�ran options scene julian
    public void Instruct()
    {
        SceneManager.LoadScene("Instruct");
    }
    //G�r att man g� fr�n spelet, men Scripten �r inte helt klart Julian
    public void QuitGame()
    {
        Application.Quit();
    }
}
