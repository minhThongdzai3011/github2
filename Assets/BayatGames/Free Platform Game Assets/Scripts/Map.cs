using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public int coin;
    public float speed;
    public float jump;
    public string username;
    public int health;
    public int coinScore1 = 0;
    public int coinScore2 = 0;
    public int coinScore3 = 0;
    public int coinScore4 = 0;
    public int coinScore5 = 0;
    public int coinScore6 = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI namePlayerText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI map1Text;
    public TextMeshProUGUI map2Text;
    public TextMeshProUGUI map3Text;
    public TextMeshProUGUI map4Text;
    public TextMeshProUGUI map5Text;
    public TextMeshProUGUI map6Text;

    void Start()
    {
        
        coin = PlayerPrefs.GetInt("coinSave", 0);
        speed = PlayerPrefs.GetFloat("moveSpeed", 0);
        jump = PlayerPrefs.GetFloat("jumpForce", 0);
        username = PlayerPrefs.GetString("username_");
        health = PlayerPrefs.GetInt("health", 0); 
        coinScore1 = PlayerPrefs.GetInt("coinScore1", 0);
        coinScore2 = PlayerPrefs.GetInt("coinScore2", 0);
        coinScore3 = PlayerPrefs.GetInt("coinScore3", 0);
        coinScore4 = PlayerPrefs.GetInt("coinScore4", 0);
        coinScore5 = PlayerPrefs.GetInt("coinScore5", 0);
        coinScore6 = PlayerPrefs.GetInt("coinScore6", 0);
        Debug.Log("coin1: " + coinScore1 + " coin2: " + coinScore2);

    }


    void Update()
    {
        ShowPlayerInfo();
    }

    public void LoadMap1()
    {
        SceneManager.LoadScene("Map1");
    }
    public void LoadMap2()
    {
        SceneManager.LoadScene("Map2");
    }
    public void LoadMap3()
    {
        SceneManager.LoadScene("Map3");
    }
    public void LoadMap4()
    {
        SceneManager.LoadScene("Map4");
    }
    public void LoadMap5()
    {
        SceneManager.LoadScene("Map5");
    }
    public void LoadMap6()
    {
        SceneManager.LoadScene("Map6");
    }
    public void Logout()
    {
        SceneManager.LoadScene("LoginPlayer");
    }
    public void ShowPlayerInfo()
    {
        coinText.text = "Coin: " + coin + " $";
        speedText.text = "Speed: " + speed;
        jumpText.text = "Jump: " + jump;
        namePlayerText.text = "Username: " + username;
        healthText.text = "Health: " + health;
        map1Text.text = "Tien trinh: " + coinScore1 + " /15";
        map2Text.text = "Tien trinh: " + coinScore2 + " /15";
        map3Text.text = "Tien trinh: " + coinScore3 + " /15";
        map4Text.text = "Tien trinh: " + coinScore4 + " /15";
        map5Text.text = "Tien trinh: " + coinScore5 + " /15";
        map6Text.text = "Tien trinh: " + coinScore6 + " /15";
    }

    public void SavePlayerData()
    {

        SceneManager.LoadScene("Map");
        PlayerPrefs.SetInt("coinSave", coin);
        PlayerPrefs.SetFloat("moveSpeed", speed);
        PlayerPrefs.SetFloat("jumpForce", jump);
        PlayerPrefs.SetString("username_", username);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }

    public void BtnShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
