using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer 0.2 seconds
        // if (isDead) {
            //character.resetLevel()
        //}
    }
    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("inside OnCOllision");
        Character character = other.GetComponent<Character>();
        if (character != null) {
            //set timer up
            // animator for spikes or change the image to the spikes out

            character.resetLevel();
            
        }
    }
}
