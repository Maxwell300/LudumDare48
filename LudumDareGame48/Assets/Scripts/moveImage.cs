using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveImage : MonoBehaviour
{

    public float rotation = 30;
    public float velocityX;
    public float velocityY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);

        Vector2 position = transform.position;
        position.x = position.x + velocityX * Time.deltaTime;
        position.y = position.y + velocityY * Time.deltaTime;
        transform.position = position;
    }
}
