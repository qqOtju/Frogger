using System;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private ParticleSystem[] jumpEffect;
    
    private readonly StateMachine _stateMachine = new();
    public JumpState jumpState { private set; get; }
    public StandingState standingState { private set; get; }
    public GameObject actor;
    private float distance = 1.75f;
    private Command _keyW, _keyA, _keyS, _keyD;
    private bool _isMoving;
    private GameStatus _status;
    private int _xAxisLimiter;
    private int _yAxisLimiter;
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

    void Start()
    {
        //jumpState = new JumpState(this, _stateMachine);
        //standingState = new StandingState(this, _stateMachine);
        _keyW = new Commands.MoveWithEffects(actor, animationCurve,0,  distance, jumpEffect);
        _keyA = new Commands.MoveWithEffects(actor, animationCurve,-distance, 0, jumpEffect);
        _keyS = new Commands.MoveWithEffects(actor, animationCurve,0, -distance, jumpEffect);
        _keyD = new Commands.MoveWithEffects(actor, animationCurve,distance,  0, jumpEffect);
        _stateMachine.Initialize(standingState);
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
            _xAxisLimiter++;
            _isMoving = true;
            _keyW.Execute();
        }
        if (!_isMoving && Input.GetKeyDown(KeyCode.A)) {
            _isMoving = true;
            _keyA.Execute(); 
        }
        if (!_isMoving && _xAxisLimiter - 1 >= 0 && Input.GetKeyDown(KeyCode.S))
        {
            _xAxisLimiter--;
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
