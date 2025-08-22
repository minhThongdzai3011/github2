using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    private bool movingLeft = true; // Direction of movement
    public float min = 80f;
    public float max = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
        {
            if (movingLeft)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);

                if (transform.position.x <= min)
                {
                    transform.position = new Vector2(min, transform.position.y); 
                    movingLeft = false;
                }
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);

                if (transform.position.x >= max)
                {
                    transform.position = new Vector2(  max, transform.position.y); 
                    movingLeft = true;
                }
            }
        }
}
