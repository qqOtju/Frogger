using System;
using UnityEngine;
using UnityEngine.Events;

public class UIStartGame : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;

    private void Awake()
    {
        onGameStatusChange.Event += OnGameStatusChangeEvent; 
    }

    private void OnGameStatusChangeEvent(GameStatus obj)
    {
        if(obj == GameStatus.Game)
            OnStartGameEvent();
        if (obj == GameStatus.Pause)
            OnLooseEvent();
    }

    private void OnLooseEvent()
    {
        gameObject.SetActive(true);
    }

    private void OnStartGameEvent()
    {
        gameObject.SetActive(false);
    }
    
}