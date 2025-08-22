using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image imageMenu;
    public Button continueGame;
    private Button continueGame1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            continueGame.gameObject.SetActive(true);
        }

    }

    public void Map()
    {
        SceneManager.LoadScene("Map");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextMap()
    {
        if (SceneManager.GetActiveScene().name == "Map1")
        {
            SceneManager.LoadScene("Map2");
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            SceneManager.LoadScene("Map3");
        }
        else if (SceneManager.GetActiveScene().name == "Map3")
        {
            SceneManager.LoadScene("Map4");
        }
        else if (SceneManager.GetActiveScene().name == "Map4")
        {
            SceneManager.LoadScene("Map5");
        }
        else if (SceneManager.GetActiveScene().name == "Map5")
        {
            SceneManager.LoadScene("Map6");
        }
        else if (SceneManager.GetActiveScene().name == "Map6")
        {
            SceneManager.LoadScene("Map");
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        imageMenu.gameObject.SetActive(true);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        imageMenu.gameObject.SetActive(false);
    }
}
