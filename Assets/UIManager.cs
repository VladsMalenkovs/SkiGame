using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup overlay;
    [SerializeField] private float fadespeed = 0.5f;
    [SerializeField] private GameObject screen;
    [SerializeField] private int NextLevelIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        overlay.gameObject.SetActive(true);
        screen.SetActive(false);
        StartCoroutine(FadeOutOverlay());
    }

    private void OnEnable()
    {
        EndGate.FinishRace += FinishRaceUI;
    }

    private void OnDisable()
    {
        EndGate.FinishRace -= FinishRaceUI;

    }

    private void FinishRaceUI()
    {
        screen.SetActive(true);
    }

    private IEnumerator FadeInOverlay()
    {
        while (overlay.alpha < 1.0f)
        {
            overlay.alpha += Time.deltaTime + fadespeed;
            yield return null;
        }
    }

    private IEnumerator FadeOutOverlay()
    {
        while (overlay.alpha > 0f)
        {
            overlay.alpha -= Time.deltaTime + fadespeed;
            yield return null;
        }
    }

    public void Retry()
    {
        StartCoroutine(RetryCoroutine());
    }

    private IEnumerator RetryCoroutine()
    { 
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        Application.Quit();
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(NextLevelIndex);
    }
    public void NextLevel()
    {
        NextLevelCoroutine();
    }

    public void Quit()
    {
        QuitCoroutine();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
