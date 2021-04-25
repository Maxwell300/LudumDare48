using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public void Start() {
        audioSource.time = GlobalVariables.timeInAudio;
    }
    public void PlayGame() {
        GlobalVariables.timeInAudio = audioSource.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
