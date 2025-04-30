using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rbody;
    private PlayerInputActions _inputActions;
    private Vector2 _direction = Vector2.zero;

    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    
    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_direction.Equals(Vector2.zero)) return;
        _rbody.linearVelocity += Direction.x * transform.right * _speed * -1 * Time.deltaTime;
    }
}