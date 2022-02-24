using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryPortal : MonoBehaviour
{
    //TEST CODE, Sama codes som portal

    //Om man taggar collider så bytter man scene
    void OnTriggerEnter(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
