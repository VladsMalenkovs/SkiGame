using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    private AudioSource audiosource;
    [SerializeField] private AudioClip obstacleGitSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += PlayObstacleHitSound;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= PlayObstacleHitSound;
    }
    // Update is called once per frame
    public void PlayObstacleHitSound()
    {
        audiosource.PlayOneShot(obstacleGitSound);
    }
}
