using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> targets;
    public int HP;
    private SpriteRenderer _spriteRenderer;
    private Color standartColor;
    private RaycastHit2D hit;
    [SerializeField] private Transform wallDetection;
    bool isCallRotate = false;

    public float speed = 5f;

    const string LEFT = "left";
    const string RIGHT = "right";

    [SerializeField] Transform castPos;

    [SerializeField] float baseCastDist;

    string facingDirection;

    Vector3 baseScale;

    private Rigidbody2D rb;


    private void FixedUpdate()
    {
        Move();
    }
    private void Start()
    {
        baseScale = transform.localScale;

        facingDirection = RIGHT;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckingTheEnvironment();
    }

    public void Move()
    {
        float vX = speed;

        if (facingDirection == LEFT)
        {
            vX = -speed;
        }

        rb.velocity = new Vector2(vX, rb.velocity.y);

        if (IsHittingWall() || IsNearEdge())
        {
            if (facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if (facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;
        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }

        else if (newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection = newDirection;
    }

    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;

        if (facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }

        else
        {
            castDist = baseCastDist;
        }

        Vector3 targetPos = castPos.position;

        targetPos.x += castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }

        else
        {
            val = false;
        }
        return val;
    }

    bool IsNearEdge()
    {
        bool val = true;

        float castDist = baseCastDist;

        Vector3 targetPos = castPos.position;

        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.blue);
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }

        else
        {
            val = true;
        }
        return val;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventAgregator.playerGetDamage.Invoke();
            EventAgregator.UpdateUI.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            EventAgregator.playerLostCoin.Invoke();

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Key"))
        {
            EventAgregator.playerLostKey.Invoke();

            Destroy(collision.gameObject);
        }
    }


    public void CheckingTheEnvironment()
    {
        hit = Physics2D.CircleCast(new Vector2(wallDetection.position.x, wallDetection.position.y), 1f, Vector2.left);
        var hit2 = Physics2D.Linecast(new Vector2(wallDetection.position.x, wallDetection.position.y), new Vector2(wallDetection.position.x + 1f, wallDetection.position.y));
        Debug.DrawLine(hit.transform.position, new Vector2(wallDetection.position.x + 1f, wallDetection.position.y), Color.red);
    }
}
