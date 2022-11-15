using System;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    [SerializeField] private GameEvent onDeath;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Car"))
        {
            onDeath.Raise();
            gameObject.SetActive(false);
        }
    }
}
