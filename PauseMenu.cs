using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public string menu = "menu";

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
                Debug.Log("Is Paused" + GameIsPaused);

            if (GameIsPaused) {
                Resume();
                Debug.Log("Resume");
            } else {
                Pause();
                Debug.Log("Is Paused" + GameIsPaused);
            }
        }
    }

    public void Resume () {
        FindObjectOfType<AudioManager>().Play("Button");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu () {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(menu);
    }

    public void QuitGame () {
        FindObjectOfType<AudioManager>().Play("Button");
        Debug.Log("Quit menu...");
        Application.Quit();
    }
}
