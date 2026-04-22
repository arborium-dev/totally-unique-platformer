using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class movment : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 boxSize;
    InputAction moveAction;
    InputAction jumpAction;
    public float distance;
    public LayerMask groundLayer;

    public Rigidbody2D _rb;
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        _rb = GetComponent<Rigidbody2D>();
    }

    public bool isGrounded() 
    { 
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, distance, groundLayer))
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position -transform.up * distance, boxSize);
    }
    void Update()
    {
        
        
        

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        _rb.linearVelocity = new Vector2(moveValue.x * speed, _rb.linearVelocity.y);

        
        if (jumpAction.IsPressed()&& isGrounded())
        {
            _rb.AddForce(transform.up * jumpForce);
        }
        
    }
}
