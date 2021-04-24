using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;

    public LayerMask whatStops;

    void Update()
    {
        if(Physics2D.OverlapCircle(movePoint.position + new Vector3(moveSpeed, 0f, 0f), .5f, whatStops)){
            moveSpeed = moveSpeed * -1;
        }

    movePoint.position += new Vector3(moveSpeed, 0f, 0f);
    }
}
