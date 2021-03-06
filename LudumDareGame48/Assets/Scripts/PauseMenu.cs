using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseUI;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Paused) {
                Resume();
            }
            else {
                Pause ();
            }
        }
    }

    public void Resume () {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Pause () {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        GlobalVariables.timeInAudio = audioSource.time;
        SceneManager.LoadScene(0);
    }
}
