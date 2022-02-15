using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Health _playerHealth;
    [SerializeField] private Text _timerLabel;
    private int _time;

    private void Start()
    {
        _playerHealth = FindObjectOfType<Health>();
        _playerHealth.PlayerIsDead += Save;
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            _time++;
            yield return new WaitForSeconds(1);
            _timerLabel.text = _time.ToString();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("record", _time);
    }

    private void OnDestroy()
    {
        _playerHealth.PlayerIsDead -= Save;
    }
}