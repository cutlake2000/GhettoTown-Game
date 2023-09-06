using System;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    // [SerializeField]
    // private SpriteRenderer armRenderer;

    // [SerializeField]
    // private Transform armPivot;

    [SerializeField]
    private SpriteRenderer characterRenderer;
    private Animator animator;
    private TopDownCharacterController topDownCharacterController;
    private int direction;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        topDownCharacterController = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        topDownCharacterController.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        SetLookingAnimation(newAimDirection);
    }

    void SetLookingAnimation(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GetAimDirectionToFloat(rotZ);

        // armRenderer.flipX = Mathf.Abs(rotZ) < 90f;
        // characterRenderer.flipX = armRenderer.flipY;
        // armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void GetAimDirectionToFloat(float rotZ)
    {
        // 정면
        if (-135 < rotZ && rotZ <= -45)
        {
            if (direction != 0)
            {
                animator.SetTrigger("Direction 0");
                direction = 0;
            }
        }
        // 왼쪽
        else if (135 <= Mathf.Abs(rotZ) && Mathf.Abs(rotZ) <= 180)
        {
            if (direction != -1)
            {
                animator.SetTrigger("Direction 1");
                characterRenderer.flipX = false;
                direction = -1;
            }
        }
        // 오른쪽
        else if (-45 < rotZ && rotZ <= 45)
        {
            if (direction != 1)
            {
                animator.SetTrigger("Direction 1");
                characterRenderer.flipX = true;
                direction = 1;
            }
        }
        // 뒷면
        else if (45 < rotZ && rotZ <= 135)
        {
            if (direction != 2)
            {
                animator.SetTrigger("Direction 2");
                direction = 2;
            }
        }
    }
}
