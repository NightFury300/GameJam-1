using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 3f, transform.position.z);
    }
}
