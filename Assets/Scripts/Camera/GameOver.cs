using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Changing the scene 
    public void ChangeScene ()
    {
        SceneManager.LoadScene("MainM");
    }

    
}
