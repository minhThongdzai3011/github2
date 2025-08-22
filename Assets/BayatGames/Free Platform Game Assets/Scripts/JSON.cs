using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int playerLevel;
    public float playerHealth;
}
public class JSON : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PlayerData playerData = new PlayerData();
        //playerData.playerName = "minhthong";
        //playerData.playerLevel = 1;
        //playerData.playerHealth = 100f;

        //string jsonString = JsonUtility.ToJson(playerData);

        //string filePath = Path.Combine(Application.streamingAssetsPath, "D:\\Create with code\\Make a 2D Platformer Basics\\2D Platformer Tutorial\\Assets\\BayatGames\\Free Platform Game Assets\\Json\\playerData.json");

        //File.WriteAllText(filePath, jsonString);

        //Debug.Log("Data saved to: " + filePath);




        string filePath = Path.Combine(Application.streamingAssetsPath, "D:\\Create with code\\Make a 2D Platformer Basics\\2D Platformer Tutorial\\Assets\\BayatGames\\Free Platform Game Assets\\Json\\playerData.json");

        string jsonString = File.ReadAllText(filePath);

        PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonString);

        Debug.Log("Player Name: " + playerData.playerName);
        Debug.Log("Player Level: " + playerData.playerLevel);
        Debug.Log("Player Health: " + playerData.playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
