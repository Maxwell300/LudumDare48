using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update 
    public void playLevel(int index) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
