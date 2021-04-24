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
    public LayerMask wall;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, walkSpeed * Time.deltaTime);

        Timer(ref moving, ref movingTimer);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && !moving){
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, wall)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    moving = true;
                    movingTimer = 0.6f;
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, wall)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    moving = true;
                    movingTimer = 0.6f;
                }
            }
        }
    }

    void FixedUpdate() {
        
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
