using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rbody;
    private PlayerInputActions _inputActions;
    private Vector2 _inputDirection = Vector2.zero;

    public Vector2 InputDirection
    {
        get => _inputDirection;
        set => _inputDirection = value;
    }
    
    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_inputDirection.Equals(Vector2.zero)) return;
        Vector3 direction = (-transform.right * _inputDirection.x + -transform.forward * _inputDirection.y).normalized;
        _rbody.MovePosition(_rbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}