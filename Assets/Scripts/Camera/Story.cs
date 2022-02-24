using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    //Changing scene Julian
    public void ChangeScene()
    {
        SceneManager.LoadScene("Intro");
    }
}
