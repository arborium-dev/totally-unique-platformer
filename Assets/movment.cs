using UnityEngine;
using UnityEngine.InputSystem;

public class movment : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    InputAction moveAction;
    InputAction jumpAction;

    public Rigidbody2D _rb;
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        _rb.linearVelocity = new Vector2(moveValue.x * speed, _rb.linearVelocity.y);

        if (jumpAction.IsPressed())
        {
            _rb.AddForce(transform.up * jumpForce);
        }
    }
}
