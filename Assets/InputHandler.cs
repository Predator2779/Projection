using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class InputHandler : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private PlayerInputActions _inputActions;
    private CharacterController _characterController;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        // _inputActions.Player.Move.started += OnMove;
    }

    private void Update()
    {
        _characterController.Move(_inputActions.Player.Move.ReadValue<Vector2>() * _speed);
    }

    private void FixedUpdate()
    {
        _characterController.Move(Vector3.down * 0.05f);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputDirection = context.ReadValue<Vector2>();
        _characterController.Move(inputDirection * Time.deltaTime);
    }
}