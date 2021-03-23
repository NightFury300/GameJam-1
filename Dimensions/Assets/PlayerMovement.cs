using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnim;
    private enum State { idle,running}
    private State state = State.idle;


    [SerializeField] private float speed = 3f;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        move();
        playerState();
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
        playerAnim.SetInteger("State", (int)state);
    }

    public void playerState()
    {
        if(Mathf.Abs(rb.velocity.x) > 1.5f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
     
}
