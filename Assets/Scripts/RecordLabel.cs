using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordLabel : MonoBehaviour
{
    [SerializeField] private Text _recordLabel;

    private void Start()
    {
        int record = PlayerPrefs.GetInt("record");
        _recordLabel.text = record.ToString();
    }

}

