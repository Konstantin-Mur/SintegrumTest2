using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 10f;
    private bool isFacingRight = true;
    private Rigidbody2D rigidbody2D;
    private bool _isJump = false;
    private bool _isGround = false;
    public Transform groundDetect;
    private void Jump()
    {
        if (_isGround == true)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            _isJump = false;
        }
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGround = Physics2D.Linecast(groundDetect.position, new Vector2(groundDetect.position.x, groundDetect.position.y - 1f), 1 << LayerMask.NameToLayer("Ground"));
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");


        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();

        if (Input.GetKey(KeyCode.Space) & _isGround == true)
        {
            _isJump = true;
            Jump();
        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}