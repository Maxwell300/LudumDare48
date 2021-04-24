using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject player;
    public Transform firePoint;
    public float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        firePoint.parent = null;
    }

   
    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, firePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, firePoint.position) <= 0.05f)
        {

            if (player.GetComponent<Character>().moving)
            {

                firePoint.position += new Vector3(1f, 0f, 0f);

            }
            else
            {

            }//End if else

        }//End If




    }
}
