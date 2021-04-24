using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
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
    bool isAllowedToMove = true;
    bool idk = true;
    float idkTimer = 0.6f;
    public bool moving = false;
    float movingTimer;
    public float walkSpeed = 3f;
    float t = 0;
    public LayerMask wall;

    public List<Vector2> inputsArray;
    public int currentIndex = 0;
    public UnityEvent movedEvent;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        inputsArray = new List<Vector2>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, walkSpeed * Time.deltaTime);

        GlobalVariables.Timer(ref moving, ref movingTimer);
        GlobalVariables.Timer(ref idk, ref idkTimer);

        foreach (Vector2 i in inputsArray) {
            //Debug.Log(i.x + ", " + i.y);
        }
        input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && !moving && isAllowedToMove){
            if (Mathf.Abs(input.x) == 1f || Mathf.Abs(input.y) == 1f) {
                currentIndex = 0;
                inputsArray.Add(input);
                moving = true;
                movingTimer = 0.6f * (inputsArray.Count + 1);
                isAllowedToMove = false;
                idk = false;
                movementHelper();
            }
        }
        if (currentIndex > 0) {
            movementHelper();
        }
    }

    void FixedUpdate() {
        
    }

    void movementHelper() {
        if (!idk) {
            if (currentIndex != inputsArray.Count) {
                movement(inputsArray[currentIndex]);
                currentIndex++;
                idk = true;
                idkTimer = 0.6f;
                movedEvent.Invoke();
            } 
            else if ( currentIndex == inputsArray.Count) {
                isAllowedToMove = true;
                idk = false;
            }
            else {
                idk = false;
            }
        }
    }
    void movement (Vector2 input) {
        if (Mathf.Abs(input.x) == 1f) {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(input.x, 0f, 0f), .2f, wall)) {
                movePoint.position += new Vector3(inputsArray[currentIndex].x, 0f, 0f);
            }
        }
        else if (Mathf.Abs(input.y) == 1f) {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, input.y, 0f), .2f, wall)) {
                movePoint.position += new Vector3(0f, inputsArray[currentIndex].y, 0f);
            }
        }
    }
}
