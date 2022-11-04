using System;
using UnityEngine;

public abstract class Command
{
    public Action onCommandEnd;
    public abstract void Execute();
}

namespace Commands
{
    public class Move : Command
    {
        private readonly PlayerMovement _playerMovement = new PlayerMovement();
        private readonly AnimationCurve _animationCurve;
        private readonly Transform _transform;
        private readonly float _distanceX;
        private readonly float _distanceY;
        public Move(GameObject actor, AnimationCurve animationCurve ,float distanceX, float distanceY)
        {
            _animationCurve = animationCurve;
            _transform = actor.transform;
            _distanceX = distanceX;
            _distanceY = distanceY;
            _playerMovement.OnMoveEnd += () => { onCommandEnd?.Invoke(); };
        }
        public override void Execute()
        {
            _playerMovement.MoveObj(_transform, _animationCurve, _distanceX, _distanceY, 0);
        }
    }
}
