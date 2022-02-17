using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Martin
public class Dialogue
{
    public string name;
    //Aray för att skapa sting, max och min
    [TextArea(3,10)]
    public string[] sentences;


}
