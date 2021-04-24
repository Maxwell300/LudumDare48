using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    void Start() 
    {

    }
    void OnTriggerStay2D (Collider2D other) {
        Debug.Log("inside OnCOllision");
        Character character = other.GetComponent<Character>();
        if (character != null) {
            character.goToNextLevel();
        }
    }
}
