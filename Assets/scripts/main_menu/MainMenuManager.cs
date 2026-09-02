using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadePanel;
    [SerializeField] private float fadeDuration = 0.5f;
    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        fadePanel.blocksRaycasts = true;
        float time = 0f;

        while(time < fadeDuration)
        {
            time += Time.deltaTime;
            fadePanel.alpha = time / fadeDuration;
            yield return null;
        }

        fadePanel.alpha = 1f;
        SceneManager.LoadScene("game");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
