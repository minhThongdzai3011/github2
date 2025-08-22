using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public float minY = -3f; // Minimum Y position
    public float maxY = 2f; // Maximum Y position
    private bool movingUp = true; // Direction of movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= maxY)
            {
                transform.position = new Vector2(transform.position.x, maxY); 
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= minY)
            {
                transform.position = new Vector2(transform.position.x, minY); 
                movingUp = true;
            }
        }
    }
}
