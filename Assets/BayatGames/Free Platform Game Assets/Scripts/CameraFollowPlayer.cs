using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public Vector2 offset = new Vector3(0,0); // Offset from the player position
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Update the camera position to follow the player with the specified offset
            transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
        }
        else
        {
            Debug.LogWarning("Player GameObject is not assigned in CameraFollowPlayer script.");
        }

    }
}
