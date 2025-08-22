using UnityEngine;


public class Testing : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float speed = 0.0001f;
    public float speedPlayer = 2f;
    public float inputHorizontal;
    public float inputVertical;
    private bool isMoving = false;
    public Vector3 helo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //line.SetUpLine(points);
        var textFile = Resources.Load<TextAsset>("Text/textFile01");
        Debug.Log(textFile);
    }

    // Update is called once per frame
    void Update()
    {
        //OnMouseDown();
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * inputHorizontal * speedPlayer * Time.deltaTime);
        transform.Translate(Vector3.up * inputVertical * speedPlayer * Time.deltaTime);
    }

    //private void FixedUpdate()
    //{
    //    this.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    this.worldPosition.z = 0f; 
    //    Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.speed);
    //    transform.position = newPos;
    //}


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
           isMoving = !isMoving;
            this.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.worldPosition.z = 0f;

        }
        if (isMoving)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, worldPosition, this.speed * Time.deltaTime);
            transform.position = newPos;
            if (Vector3.Distance(transform.position, worldPosition) < 0.01f)
            {
                isMoving = false; 
            }
        }
    }
           
}
