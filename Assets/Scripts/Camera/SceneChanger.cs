using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenechanger : MonoBehaviour
{
    //TEST CODE, Sama codes som portal
   void OnTriggerEnter(Collider ChangeScene)
    {
      if (ChangeScene.gameObject.CompareTag("Player"))
      {
            SceneManager.LoadScene("Ending");
      }
    }
}

