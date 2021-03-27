using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float helpCameraSize = 7.0f;
    [SerializeField] private float normalCameraSize = 5.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (Camera.main.orthographicSize == helpCameraSize)
            {
                player.position = new Vector2(player.position.x - 5f,player.position.y);
                Camera.main.orthographicSize = normalCameraSize;
            }
            else
            {
                player.position = new Vector2(player.position.x + 5f, player.position.y);
                Camera.main.orthographicSize = helpCameraSize;
            }
        }
    }
}
