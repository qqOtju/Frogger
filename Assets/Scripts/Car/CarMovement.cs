using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve animationCurve;
    public Vector3 EndPos { get; set; }
    
    private Transform _transform;
    private Rigidbody2D _rb;
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
        _rb.DOMove(EndPos, 10 / speed + Random.Range(-0.5f, 0.6f)).SetEase(animationCurve);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Finish"))
            gameObject.SetActive(false);
    }
}
