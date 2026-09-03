using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadePanel;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private TMP_Text bestScoreText;

    [SerializeField] private GameObject characterSelectPanel;

    private void Start()
    {
        bestScoreText.text = "best: " + PlayerPrefs.GetInt("highScore", 0).ToString("D4");
    }
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

    public void OpenChar()
    {
        characterSelectPanel.SetActive(true);
    }

    public void CloseChar()
    {
        characterSelectPanel.SetActive(false);
    }
}
