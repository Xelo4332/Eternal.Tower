using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
    //Deni
{
    
    //Does not destroying Object
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
