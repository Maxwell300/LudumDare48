using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask whatStops;
    public Transform newPoint;
    int direction = 1;

    void Start(){
        newPoint.parent = null;
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, newPoint.position, moveSpeed * Time.deltaTime);
    }

    public void move(){
        if(Physics2D.OverlapCircle(transform.position + new Vector3(1f*direction, 0f, 0f), .2f, whatStops)){
            direction *= -1;
        }
        newPoint.position = transform.position + new Vector3(1f*direction, 0f, 0f);
    }
}
