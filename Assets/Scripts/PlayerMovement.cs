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

        // flipX ����: ���������� �̵��� ���� ������
        if (input.x > 0f)
            sr.flipX = true;    // ������ �� ����� ���� ��
        else if (input.x < 0f)
            sr.flipX = false;   // ����  �� ���� �״��
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }
}
