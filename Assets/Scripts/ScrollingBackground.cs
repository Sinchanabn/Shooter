using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //Variable to increas or decreas the speed
    public float speed;

    void Start()
    {
        if (speed <= 0)
        {
            speed = 1;

        }
    }

    void Update()
    {
        //moving the BG in Y direction with time and adjustable speed

        transform.position += new Vector3(0, 5 * Time.deltaTime * speed);

        if (transform.position.y > 30)
        {
            transform.position = new Vector3(transform.position.x, 0f);
        }
    }
}
