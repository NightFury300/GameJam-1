using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 3f;
    // Update is called once per frame
    private void Update()
    {
        move();
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
    }
     
}
