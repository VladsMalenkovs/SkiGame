using UnityEngine;

public class EndGate : MonoBehaviour
{
    public static event GameManager.TimerEvent FinishRace;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            FinishRace.Invoke();
        }
    }

}

