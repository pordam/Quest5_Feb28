using UnityEngine;
using UnityEngine.InputSystem;

public class _PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Called by the Input System when using PlayerInput with "Send Messages"
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (rb == null)
            return;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (animator == null)
            return;

        if (movement != Vector2.zero)
        {
            animator.SetFloat("X Pos", movement.x);
            animator.SetFloat("Y Pos", movement.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
