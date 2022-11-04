using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Events/Basic Event")]
public class GameEvent : ScriptableObject
{
    public event Action Event;

    public void Raise()
    {
        Event?.Invoke();
    }
}