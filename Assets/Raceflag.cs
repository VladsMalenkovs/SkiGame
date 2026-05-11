using UnityEngine;

public class Raceflag : MonoBehaviour
{
    private bool flagPassed = false;
    private enum Direction { Left, Right }
    [SerializeField] private Direction flagDirection;
    public static event GameManager.TimerEvent racePenality;

    [SerializeField] private Material goodColor, badColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.playerPos != null && PlayerController.playerPos.position.z < transform.position.z && !flagPassed)
        {
            flagPassed = true;
            Direction passingDirection = Direction.Right;
            if (PlayerController.playerPos.position.x < transform.position.x)
                passingDirection = Direction.Left;
                MeshRenderer rendered = GetComponent<MeshRenderer>();
            if (passingDirection == flagDirection)
            { 
                rendered.material = goodColor;
            }
            else 
            {
                rendered.material = badColor;
                racePenality.Invoke(); 
            }

            flagPassed = true;
            Debug.Log("pupu");
            
        }
    }
}
