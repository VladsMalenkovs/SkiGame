using UnityEngine;
using System.Collections.Generic;

public class Gamedata : MonoBehaviour
{
    private static Gamedata instance;
    public List <float> bestTime = new List<float>();
    [SerializeField] private string LeaderboardKey = "LeaderboardLVL1-"; 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        loadLeaderboard();


    }

    public void AddLevelTime(float time)
    {
        bestTime.Add(time);
        bestTime.Sort();
        SaveLeaderboard();
    }

    private void loadLeaderboard()
    {
        for (int i = 0; i < 5; i++)
        { 
            float time = PlayerPrefs.GetFloat(LeaderboardKey+i, 999.99f);
            bestTime.Add(time);
        }
        bestTime.Sort();
    }

    private void SaveLeaderboard()
    {

        for (int i = 0; i < 5; i++)
        { 
            PlayerPrefs.SetFloat(LeaderboardKey+i, bestTime[i]);
        }
        PlayerPrefs.Save();
    }

 
    public static Gamedata Instance
        { get { return instance; } }    
}
