using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        animator.SetBool("IsMoving", input != Vector2.zero);

        // flipX 반전: 오른쪽으로 이동할 때만 뒤집기
        if (input.x > 0f)
            sr.flipX = true;    // 오른쪽 → 뒤집어서 보여 줌
        else if (input.x < 0f)
            sr.flipX = false;   // 왼쪽  → 원본 그대로
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }
}
