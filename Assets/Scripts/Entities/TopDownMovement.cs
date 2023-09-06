using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController topDownCharacterController;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        topDownCharacterController = GetComponent<TopDownCharacterController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        topDownCharacterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;

        SetWalkingAnimation(direction);
    }

    private void SetWalkingAnimation(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= 5;
        rigidbody2D.velocity = direction;
    }
}
