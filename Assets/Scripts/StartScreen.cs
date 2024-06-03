using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject startscreen;
    [SerializeField] GameObject endscreen;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        startscreen.SetActive(true);
        Time.timeScale = 0f;
        playerController.FreezeControls = true;
    }

    public void PlayGame()
    {
        startscreen.SetActive(false);
        Time.timeScale = 1f;
        playerController.FreezeControls = false;
    }

    public void EndGame()
    {
        endscreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
