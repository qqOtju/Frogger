using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Status Event", menuName = "Events/Game Status Event")]
public class GameStatusEvent : ScriptableObject
{
    public event Action<GameStatus> Event;

    public void Raise(GameStatus status)
    {
        Event?.Invoke(status);
    }
}