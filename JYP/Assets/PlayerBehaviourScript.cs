using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.1f;

    private Rigidbody2D rb;
    private Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // groundCheck 자동 생성 (플레이어 하단에)
        GameObject gc = new GameObject("GroundCheck");
        gc.transform.parent = transform;
        gc.transform.localPosition = new Vector3(0f, -0.5f, 0f);
        groundCheck = gc.transform;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        // 바닥 레이어 없이 Raycast로 땅과의 거리 체크
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance);
        return hit.collider != null;
    }
}