using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    public delegate void TimerEvent();
    private TimeSpan raceTime;
    private DateTime raceStart;
    private bool racing = false;

    private void OnEnable()
    { 
        StartGate.StartRace += StartRace;
        EndGate.FinishRace += FinishRace;

    }
    void FinishRace()
    {
        Debug.Log("finish race");
        racing = false;
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
        TimeSpan raceTime = DateTime.Now - raceStart;
        Debug.Log("RaceTime: " + raceTime.ToString("mm:ss:ff"));
    }
}
