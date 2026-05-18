using UnityEngine;
using System.Collections.Generic;

public class Gamedata : MonoBehaviour
{
    private static Gamedata instance;
    public List <float> bestTime = new List<float>();

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
     
    }

    public void AddLevelTime(float time)
    {
        bestTimes.Add(time);
    }
    public static Gamedata Instance
        { get { return instance; } }    
}
