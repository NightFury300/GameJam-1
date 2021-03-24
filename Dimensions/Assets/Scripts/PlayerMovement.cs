using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnim;
    private enum State { idle,running,jumping,falling}
    private State state = State.idle;


    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;

    [SerializeField]private LayerMask ground;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        move();
        PlayerState();
    }

    private void move()
    {
        float mDirection = Input.GetAxis("Horizontal");

        if (mDirection > 0.1f)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(0.14332f, transform.localScale.y);
        }
        else if (mDirection < -0.1f)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-0.14332f, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump") && state != State.jumping && state != State.falling)
        {
            Jump();
        }
        playerAnim.SetInteger("State", (int)state);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void PlayerState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(rb.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 1.5f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        Destroy(item.gameObject);
    }
     
}
