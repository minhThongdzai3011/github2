using UnityEngine;

public class Raycast : MonoBehaviour
{
    private bool _grounded;
    Test test = new Test();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        test.testString = "Hello World";
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();

        if (!_grounded)
        {
           gameObject.transform.position -= new Vector3(0, 5 * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
           gameObject.transform.position += new Vector3(0, 5 , 0);
        }
    }
    public LayerMask layerMask;
    private void CheckGround()
    {
        RaycastHit2D boxResult;
        boxResult = Physics2D.BoxCast(gameObject.transform.position, new Vector2(1, 0.5f), 0f, new Vector2(0, -1), 0.25f, layerMask);
        //boxResult = Physics.BoxCast(m_Collider.bounds.center, transform.localScale * 0.5f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        if (boxResult.collider != null)
        {
            Debug.Log("Grounded: " + boxResult.collider.name);
            _grounded = true;
        }
        else
        {
            Debug.Log("Not Grounded");
            _grounded = false;
        }  
    }
}
        public class Test
            {
            internal string testString = "Test String";
        }
