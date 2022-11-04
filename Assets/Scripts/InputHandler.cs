using System;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private AnimationCurve animationCurve;
    public GameObject actor;
    private float distance = 1.75f;
    private Command _keyW, _keyA, _keyS, _keyD;
    private bool _isMoving;
    private GameStatus _status;

    private void Awake()
    {
        onGameStatusChange.Event += status =>
        {
            _status = status switch
            {
                GameStatus.Game => GameStatus.Game,
                GameStatus.Pause => GameStatus.Pause,
                _ => _status
            };
        };
    }

    void Start() {
        _keyW = new Commands.Move(actor, animationCurve ,0,  distance);
        _keyA = new Commands.Move(actor, animationCurve ,-distance, 0);
        _keyS = new Commands.Move(actor, animationCurve ,0, -distance);
        _keyD = new Commands.Move(actor, animationCurve ,distance,  0);
        _keyW.onCommandEnd += SetFalse;
        _keyA.onCommandEnd += SetFalse;
        _keyS.onCommandEnd += SetFalse;
        _keyD.onCommandEnd += SetFalse;
    }
    void Update() {
        if(_status == GameStatus.Pause)
            return;
        if (!_isMoving && Input.GetKeyDown(KeyCode.W))
        {
            _isMoving = true;
            _keyW.Execute();
        }
        if (!_isMoving && Input.GetKeyDown(KeyCode.A)) {
            _isMoving = true;
            _keyA.Execute(); 
        }
        if (!_isMoving && Input.GetKeyDown(KeyCode.S)) {
            _isMoving = true;
            _keyS.Execute(); 
        }
        if (!_isMoving && Input.GetKeyDown(KeyCode.D)) {
            _isMoving = true;
            _keyD.Execute(); 
        }
    }

    private void SetFalse()
    {
        _isMoving = false;
    }
}
