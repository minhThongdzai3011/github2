using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public int coinSave = 0;
    public float speed = 0;
    public float jump = 0;
    public int health = 0;
    public int moneyToBuySpeed = 20;
    public int moneyToBuyJump = 25;
    public int moneyToBuyHealth = 2;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI levelSkill1Text;
    public TextMeshProUGUI levelSkill2Text;
    public TextMeshProUGUI levelSkill3Text;
    public int countSkill1 = 0;
    public int countSkill2 = 0;
    public int countSkill3 = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinSave = PlayerPrefs.GetInt("coinSave", 0);
        speed = PlayerPrefs.GetFloat("moveSpeed", 0);
        jump = PlayerPrefs.GetFloat("jumpForce", 0);
        levelSkill1Text.text = "Level: " + PlayerPrefs.GetInt("countSkill1", 0) + " / 10";
        levelSkill2Text.text = "Level: " + PlayerPrefs.GetInt("countSkill2", 0) + " / 10";
        levelSkill3Text.text = "Level: " + PlayerPrefs.GetInt("countSkill3", 0) + " / 100";
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coin: " + coinSave + " $";
    }

    public void UpdateSpeed(){
        if (coinSave >= moneyToBuySpeed)
        {
            countSkill1 = PlayerPrefs.GetInt("countSkill1", 0);
            if (countSkill1 >= 10)
            {
                errorText.text = "You have reached the maximum level for Speed!";
                ShowError();
                return;
            }
            speed += 0.1f;
            speed = Mathf.Round(speed * 10f) / 10f;
            countSkill1 = PlayerPrefs.GetInt("countSkill1", 0);
            countSkill1++;
            PlayerPrefs.SetInt("countSkill1", countSkill1);
            levelSkill1Text.text = "Level: " + countSkill1 + " / 10";
            PlayerPrefs.SetFloat("moveSpeed", speed);
            coinSave -= moneyToBuySpeed;
            PlayerPrefs.SetInt("coinSave", coinSave);
            PlayerPrefs.Save();
            Debug.Log("Speed updated to: " + speed);
        }
        else
        {
            errorText.gameObject.SetActive(true);
        }
    }

    public void UpdateJump()
    {
        if (coinSave >= moneyToBuyJump)
        {
            countSkill2 = PlayerPrefs.GetInt("countSkill2", 0);
            if (countSkill2 >= 10)
            {
                errorText.text = "You have reached the maximum level for Jump!";
                ShowError();
                return;
            }
            jump += 0.1f;
            jump = Mathf.Round(jump * 10f) / 10f;
            countSkill2 = PlayerPrefs.GetInt("countSkill2", 0);
            countSkill2++;
            PlayerPrefs.SetInt("countSkill2", countSkill2);
            levelSkill2Text.text = "Level: " + countSkill2 + " / 10";
            PlayerPrefs.SetFloat("jumpForce", jump);
            coinSave -= moneyToBuyJump;
            PlayerPrefs.SetInt("coinSave", coinSave);
            PlayerPrefs.Save();
            Debug.Log("Jump updated to: " + jump);

        }
        else
        {
            ShowError();
        }
    }

    public void UpdateHealth()
    {
        if (coinSave >= moneyToBuyHealth)
        {
            countSkill3 = PlayerPrefs.GetInt("countSkill3", 0);
            if (countSkill3 >= 100)
            {
                errorText.text = "You have reached the maximum level for Health!";
                ShowError();
                return;
            }
            health += 1;
            countSkill3 = PlayerPrefs.GetInt("countSkill3", 0); 
            countSkill3++;
            PlayerPrefs.SetInt("countSkill3", countSkill3);
            levelSkill3Text.text = "Level: " + countSkill3 + " / 100";
            PlayerPrefs.SetInt("health", health);
            coinSave -= moneyToBuyHealth;
            PlayerPrefs.SetInt("coinSave", coinSave);
            PlayerPrefs.Save();
            Debug.Log("Health updated to: " + health);

        }
        else
        {
            ShowError();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Map");
    }

    void ShowError()
    {
        errorText.gameObject.SetActive(true);
        StartCoroutine(HideError());
    }

    IEnumerator HideError()
    {
        yield return new WaitForSeconds(5);
        errorText.gameObject.SetActive(false);
    }   

}
