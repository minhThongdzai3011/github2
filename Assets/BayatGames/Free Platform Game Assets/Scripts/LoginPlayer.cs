using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class LoginPlayer : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI loginSaveText;
    public string usernameSave;
    public string passwordSave;
    private int accountCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        int count = PlayerPrefs.GetInt("accountCount", 0);
        Debug.Log("Username: " + usernameInput.text + "Password: " + passwordInput.text);
        for (int i = 0; i < count; i++)
        {
            string savedUsername = PlayerPrefs.GetString("username_" + i);
            string savedPassword = PlayerPrefs.GetString("password_" + i);
            if (usernameInput.text == savedUsername && passwordInput.text == savedPassword)
            {
                string tempUsername = usernameInput.text;
                PlayerPrefs.SetString("username_" , tempUsername);
                Debug.Log("Login successful! Welcome, " + savedUsername);
                SceneManager.LoadScene("Map");
                return;
            }
            else
            {
                Debug.Log("Login failed for account " + i + ": Username or Password is incorrect.");
            }
        }


    }



    public void Register()
    {
        accountCount = PlayerPrefs.GetInt("accountCount", 0);
        Debug.Log("Registering with Username: " + usernameInput.text + " and Password: " + passwordInput.text);
        usernameSave = usernameInput.text;
        passwordSave = passwordInput.text;
        PlayerPrefs.SetString("username_" + accountCount, usernameSave);
        PlayerPrefs.SetString("password_" + accountCount, passwordSave);
        accountCount++;
        PlayerPrefs.SetInt("accountCount", accountCount);
        PlayerPrefs.Save();
        Debug.Log("Registration successful! Username_" + accountCount + ": " + usernameSave + ", Password_" + accountCount + ": " + passwordSave);
        usernameInput.text = "";
        passwordInput.text = "";
        Debug.Log("Username and Password fields cleared.");
    }

    public void OutPutLoginPlayer()
    {
        int count = PlayerPrefs.GetInt("accountCount", 0);
        loginSaveText.text = "Danh sach tai khoan:\n";
        for (int i = 0; i < count; i++)
        {
            string user = PlayerPrefs.GetString("username_" + i);
            string pass = PlayerPrefs.GetString("password_" + i);
            loginSaveText.text += $" Account {i + 1}: Username = {user}, Password = {pass}\n";
        }
    }
}
