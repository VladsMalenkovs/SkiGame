using UnityEngine;

public class ExplosionObstacle : Obstacle
{
    internal virtual void OnCollision(Collision collision)
    {
        base.OnCollision(collision);
        Destroy(gameObject);

    }
}
