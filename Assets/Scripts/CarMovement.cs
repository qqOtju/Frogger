using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarMovement : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rb;
    
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve _animationCurve;
    public Vector3 EndPos { get; set; }
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    private void Start()
    {
        Move();
        _transform.right = EndPos - _transform.position;
    }

    private void OnEnable()
    {
        Move();
    }

    private void Move()
    {
        _rb.DOMove(EndPos, 10 / speed + Random.Range(-1,2)).SetEase(_animationCurve);
        /*OnComplete(() =>
        {
            gameObject.SetActive(false);
        })*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
    }
}
