using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingTheGame : MonoBehaviour
{
    //Changing scene Julian
    public void ChangeScene()
    {
        SceneManager.LoadScene("Intro");
    }
}

