using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Character : MonoBehaviour
{
    //public Cinemachine.CinemachineVirtualCamera playerCamera;

    enum direction {
        up, down, right, left
    }

    public Animator Animator;
    Rigidbody2D rigidBody2D;
    public Transform movePoint;
    Vector2 input;
    Vector3 startPos;
    Vector3 endPos;
    bool isAllowedToMove = true;
    bool idk = true;
    float idkTimer = 0.5f;
    public bool moving = false;
    float movingTimer;
    public float walkSpeed = 3f;
    float t = 0;
    public LayerMask wall;
    public LayerMask enemies;
    public List<Vector2> inputsArray;
    public int currentIndex = 0;
    public MoveListUI moveListUI;
    public ParticleSystem bubblesEffect;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
        inputsArray = new List<Vector2>();
        bubblesEffect.enableEmission = false;
        audioSource.time = GlobalVariables.timeInAudio;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, walkSpeed * Time.deltaTime);

        GlobalVariables.Timer(ref moving, ref movingTimer);
        GlobalVariables.Timer(ref idk, ref idkTimer);

        input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && !moving && isAllowedToMove){
            if (Mathf.Abs(input.x) == 1f || Mathf.Abs(input.y) == 1f) {
                currentIndex = 0;
                inputsArray.Add(input);
                moving = true;
                movingTimer = 0.5f * (inputsArray.Count);
                isAllowedToMove = false;
                idk = false;
                movementHelper();
            }
        }
        if (currentIndex > 0) {
            movementHelper();
        }
        if (Input.GetAxisRaw("Jump") == 1f) {
            resetLevel();
        }

        if (!moving) {
            bubblesEffect.enableEmission = false;

            //Change animations back to idle
            Animator.SetBool("moveLeft", false);

            Animator.SetBool("moveRight", false);

            Animator.SetBool("moveUp", false);

            Animator.SetBool("moveDown", false);
            Debug.Log("Turned off bools");

        }
    }

    void FixedUpdate() {
        
    }

    void movementHelper() {
        if (!idk) {
            if (currentIndex != inputsArray.Count) {
                movement(inputsArray[currentIndex]);
                moveListUI.MoveListUIHandler(inputsArray, currentIndex);
                currentIndex++;
                idk = true;
                idkTimer = 0.5f;
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

        //Change animations back to idle
        Animator.SetBool("moveLeft", false);

        Animator.SetBool("moveRight", false);

        Animator.SetBool("moveUp", false);

        Animator.SetBool("moveDown", false);
        Debug.Log("Turned off bools");

        if (Mathf.Abs(input.x) == 1f) {

            //Movement animation
            if (input.x == -1f)
            {
                Debug.Log("Got to left");
                Animator.SetBool("moveLeft", true);
                Animator.SetBool("moveLeft", true);
            } else if (input.x == 1f)
            {
                Debug.Log("Got to right");
                Animator.SetBool("moveRight", true);
            }
            //END Movement animation

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(input.x, 0f, 0f), .2f, wall)) {
                movePoint.position += new Vector3(inputsArray[currentIndex].x, 0f, 0f);
                bubblesEffect.enableEmission = true;
            }
        }
        else if (Mathf.Abs(input.y) == 1f) {

            //Movement animation
            if (input.y == -1f)
            {
                Debug.Log("Got to down");
                Animator.SetBool("moveDown", true);
            }
            else if (input.y == 1f)
            {
                Debug.Log("Got to up");
                Animator.SetBool("moveUp", true);
            }
            //END Movement animation

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, input.y, 0f), .2f, wall)) {
                movePoint.position += new Vector3(0f, inputsArray[currentIndex].y, 0f);
                bubblesEffect.enableEmission = true;
            }
        }

    }

    public void resetLevel() {
        GlobalVariables.timeInAudio = audioSource.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void goToNextLevel() {
        GlobalVariables.timeInAudio = audioSource.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
