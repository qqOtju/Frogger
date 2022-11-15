using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement
{
    public Action onMoveEnd;
    public void MoveObj(Transform transform, AnimationCurve animationCurve, float x, float y, float z)
    {
        Vector3 position = transform.position;
        Vector3 newPos = new Vector3(position.x + x, position.y + y, position.z + z);
        Vector3 dir = newPos - position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
        transform.DOMove(newPos, 0.2f).SetEase(animationCurve).OnComplete(() =>
        {
            onMoveEnd?.Invoke();
        });
    }
}
