
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            optionsMenu.SetActive(true);
            collision.collider.transform.position = new Vector2(collision.collider.transform.position.x + 5.0f, collision.collider.transform.position.y);
            Time.timeScale = 0.0f;
        }
    }
}

