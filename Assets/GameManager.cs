using UnityEngine;
using System;
using TMPro;


public class GameManager : MonoBehaviour
{
    public delegate void TimerEvent();
    private TimeSpan raceTime;
    private DateTime raceStart;
    private bool racing = false;
    private TimeSpan bestTime;
    private TimeSpan penltyTime;
    [SerializeField] string bestTimeKey = "BestTimeLevel1";
    [SerializeField] public TMP_Text bestTimeText, timerText;
    public static GameManager instance;


    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    { 
        StartGate.StartRace += StartRace;
        EndGate.FinishRace += FinishRace;
        Raceflag.racePenality += AddRacePenlity;

    }

    private void Disable()
    {
        StartGate.StartRace -= StartRace;
        EndGate.FinishRace -= FinishRace;
        Raceflag.racePenality -= AddRacePenlity;

    }
    private void Start()
    {
        int bestTimeInt = PlayerPrefs.GetInt(bestTimeKey, int.MaxValue);
        bestTime = new TimeSpan(bestTimeInt);
        bestTimeText.text = "BEST TIME " + bestTime.ToString("mm\\:ss");
    }
    void AddRacePenlity()
    {
        penltyTime += new TimeSpan(0,0,3);
    }
    void FinishRace()
    {
        Debug.Log("finish race");
        racing = false;
        Gamedata.Instance.AddLevelTime((float)raceTime.TotalMilliseconds / 1000f);
        if (raceTime < bestTime)
        {
            bestTimeText.text = "BEST TIME " + bestTime.ToString("mm\\:ss");
            PlayerPrefs.SetInt(bestTimeKey, (int)raceTime.Ticks);
            PlayerPrefs.Save();


        }
    }
    void StartRace()
    {
        racing = true;
        raceStart = System.DateTime.Now;
        Debug.Log("start race");
    }

    // Update is called once per frame
    void Update()
    {
        if(racing)
         raceTime = DateTime.Now - raceStart + penltyTime;
        timerText.text = "TIME: " + raceTime.ToString("mm\\:ss");
        
        Debug.Log("RaceTime: " + raceTime.ToString("mm\\ss\\ff"));
    }
}
