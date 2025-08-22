using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContrller : MonoBehaviour
{
    float horizontalInput;
    private Rigidbody2D rb;
    public AudioClip coinSound;

    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private bool isGrounded;
    private bool canDoubleJump;
    private bool isJump = true;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private float groundCheckRadius = 0.2f;

    private int countCoin;

    public TextMeshProUGUI coinText;
    public Image winImage;
    public Image loseImage;
    public Image menuImage;
    public TextMeshProUGUI yourCoinText;
    public Button continueGame;

    private Animator anim;
    private bool isRunning = false;
    public int coinSave = 0;
    public bool isGameOver = true;


    public static int coinScore1 = 0;
    public static int coinScore2 = 0;
    public static int coinScore3 = 0;
    public static int coinScore4 = 0;
    public static int coinScore5 = 0;
    public static int coinScore6 = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        PlayerPrefs.DeleteKey("countCoin");
        Debug.Log("CountCoin: "+ countCoin);
        coinSave = PlayerPrefs.GetInt("coinSave", 0);
        moveSpeed = PlayerPrefs.GetFloat("moveSpeed", 5f);
        jumpForce = PlayerPrefs.GetFloat("jumpForce", 5f);
        Debug.Log("Coin Save: " + coinSave + " countCoin " + countCoin);
        Debug.Log("Move Speed: " + moveSpeed + " Jump Force: " + jumpForce);
        PlayerPrefs.SetFloat("moveSpeed", moveSpeed);
        PlayerPrefs.SetFloat("jumpForce", jumpForce);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
            canDoubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            Jump();
            canDoubleJump = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isRight", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isJump", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", true);
            anim.SetBool("isJump", false);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
        }
        else
        {
            isRunning = false;
            anim.SetBool("isRunning", isRunning);
        }
        anim.SetBool("isJump", !isGrounded);

        ScoreMap();
    }
    private void Jump()
    {
        if (isJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            countCoin++;
            coinText.text = "Coins: " + countCoin;
            Debug.Log("Coin collected: " + countCoin);
            coinSound = Resources.Load<AudioClip>("coinSound");
        }
        else if (collision.CompareTag("win"))
        {
            menuImage.gameObject.SetActive(true);
            winImage.gameObject.SetActive(true);
            yourCoinText.gameObject.SetActive(true);
            continueGame.gameObject.SetActive(false);
            yourCoinText.text = "Your Coins: " + countCoin;
            moveSpeed = 0f;
            isJump = false;
            coinSave += countCoin;
            PlayerPrefs.SetInt("coinSave", coinSave);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("coinSave", coinSave);
            PlayerPrefs.Save();
        }
        else if (collision.CompareTag("Monster"))
        {
            if (isGameOver)
            {
                Debug.Log($"You hit the monster!");
                menuImage.gameObject.SetActive(true);
                loseImage.gameObject.SetActive(true);
                yourCoinText.gameObject.SetActive(true);
                continueGame.gameObject.SetActive(false);
                yourCoinText.text = "Your Coins: " + countCoin;
                moveSpeed = 0f;
                isJump = false;
                coinSave += countCoin;
                PlayerPrefs.SetInt("coinSave", coinSave);
                PlayerPrefs.Save();
                isGameOver = false;
                Destroy(gameObject);
            }
        }
    }

    public void ScoreMap()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Map1")
        {
            if (countCoin > coinScore1)
            {
                coinScore1 = countCoin;
                PlayerPrefs.SetInt("coinScore1", coinScore1);
                PlayerPrefs.Save();
            }
        }
        else if (scene.name == "Map2")
        {
            if (countCoin > coinScore2)
            {
                coinScore2 = countCoin;
                PlayerPrefs.SetInt("coinScore2", coinScore2);
                PlayerPrefs.Save();
            }
        }
        else if (scene.name == "Map3")
        {
            if (countCoin > coinScore3)
            {
                coinScore3 = countCoin;
                PlayerPrefs.SetInt("coinScore3", coinScore3);
                PlayerPrefs.Save();
            }
        }
        else if (scene.name == "Map4")
        {
            if (countCoin > coinScore4)
            {
                coinScore4 = countCoin;
                PlayerPrefs.SetInt("coinScore4", coinScore4);
                PlayerPrefs.Save();
            }
        }
        else if (scene.name == "Map5")
        {
            if (countCoin > coinScore5)
            {
                coinScore5 = countCoin;
                PlayerPrefs.SetInt("coinScore5", coinScore5);
                PlayerPrefs.Save();
            }
        }
        else if (scene.name == "Map6")
        {
            if (countCoin > coinScore6)
            {
                coinScore6 = countCoin;
                PlayerPrefs.SetInt("coinScore6", coinScore6);
                PlayerPrefs.Save();
            }
        }
    }
}
