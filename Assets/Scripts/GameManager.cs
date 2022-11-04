using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private GameEvent onDeath;
    [SerializeField] private GameEvent onStart;
    private GameStatus _status;

    private void Awake()
    {
        onDeath.Event += () =>
        {
            _status = GameStatus.Pause;
            onGameStatusChange.Raise(_status);
        };
        onStart.Event += StartGame;
    }

    public void StartGame()
    {
        _status = GameStatus.Game;
        onGameStatusChange.Raise(_status);
    }
}

