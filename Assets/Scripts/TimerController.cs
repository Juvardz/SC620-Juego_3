using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    float maxtime;

    [SerializeField]
    Image fillTimer;

    private float _currentTime;
    private CharacterController2D _player;


    private void Start()
    {
        _currentTime = maxtime;
    }
    private void Awake()
    {
        _player = FindObjectOfType<CharacterController2D>();
        
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime; 
        if (_currentTime <= 0.0F)
        {
            _player.Die();
            enabled = false;
            return;
        }

        fillTimer.fillAmount = _currentTime/maxtime;
    }
}
