
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			FindObjectOfType<AudioManager>().Play("Music");
        }
    }
}
