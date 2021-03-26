using UnityEngine.SceneManagement;
using UnityEngine;

public class SpikeDetector : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnPoint;

    private Rigidbody2D rb;
    [SerializeField]
    private LayerMask spike;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(rb.IsTouchingLayers(spike))
        {
            FindObjectOfType<AudioManager>().Play("die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
