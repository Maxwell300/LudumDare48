using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update 
    public AudioSource audioSource;
    public void playLevel(int index) {
        GlobalVariables.timeInAudio = audioSource.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
