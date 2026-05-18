using UnityEngine;

public class Gamedata : MonoBehaviour
{
    private static Gamedata instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
     
    }
}
