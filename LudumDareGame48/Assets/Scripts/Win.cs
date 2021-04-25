using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void Start() {
        audioSource.time = GlobalVariables.timeInAudio;
    }
    public void MainMenu() {
        GlobalVariables.timeInAudio = audioSource.time;
        SceneManager.LoadScene(0);
    }
}
