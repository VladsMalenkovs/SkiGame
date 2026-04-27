using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void OnPlayerAction();
    public static event OnPlayerAction OnPlayerHit;
    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
    internal virtual void OnCollision(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Bolno");
        }
        OnPlayerHit.Invoke();
    }
}
