using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    //public Cinemachine.CinemachineVirtualCamera playerCamera;

    enum direction {
        up, down, right, left
    }

    Rigidbody2D rigidBody2D;
    public Transform movePoint;
    Vector2 input;
    Vector3 startPos;
    Vector3 endPos;
    bool moving = false;
    float movingTimer;
    public float walkSpeed = 3f;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, walkSpeed * Time.deltaTime);

        Timer(ref moving, ref movingTimer);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.5f && !moving){
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                if (input.x < 0) {
                    input.x *= -1;
                } 
                movePoint.position += new Vector3(0.2f, 0f, 0f);
                moving = true;
                movingTimer = 1f;
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                moving = true;
                movingTimer = 1f;
            }
        }
    }

    public bool Timer(ref bool isChanging, ref float timer) {
        Debug.Log("timer is: " + timer);
        Debug.Log("isChanging: " + isChanging);
        if (isChanging)
        {
            timer -= Time.deltaTime;
            //Debug.Log("after subtraction: " + timer);
            if (timer < 0)
            {
                isChanging = false;
            }
        }
        return isChanging;
    }
}
