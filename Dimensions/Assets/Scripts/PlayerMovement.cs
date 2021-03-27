using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnim;
    Vector2 movement = Vector2.zero;
    private enum State { idle,running,jumping,falling}
    private State state = State.idle;
    private ItemHolder inventory;

    [SerializeField] private GameObject pauseMenu;


    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float jumpForce = 15f;

    [SerializeField]private LayerMask ground;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        inventory = GetComponent<ItemHolder>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    private void FixedUpdate()
    {
        PlayerState();
        move();
    }

    private void move()
    {
        float mDirection = Input.GetAxis("Horizontal");
        movement = Vector2.zero;

        if (mDirection > 0)
        {
            movement.x += 1;         
            transform.localScale = new Vector2(0.14332f, transform.localScale.y);
        }
        else if (mDirection < -0)
        {
            movement.x -= 1;           
            transform.localScale = new Vector2(-0.14332f, transform.localScale.y);
        }

        if (Input.GetButtonDown("Jump") && state != State.jumping && state != State.falling && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            Jump();
        }
        playerAnim.SetInteger("State", (int)state);
        rb.velocity = new Vector2(movement.x * Time.fixedDeltaTime * speed, rb.velocity.y);
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
        else if(Mathf.Abs(rb.velocity.x) > 0.1f)
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
        if(item.gameObject.tag == "enlargeball")
        {
            inventory.AddItemToInventory(0);
        }
        else if(item.gameObject.tag == "shrinkball")
        {
            inventory.AddItemToInventory(1);
        }
        Destroy(item.gameObject);      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            state = State.idle;
        }
    }
}
