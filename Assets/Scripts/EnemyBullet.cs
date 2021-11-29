 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    float speed;
    Vector2 _direction;
    bool isReady;

     void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    //Function to set the bullets direction
    public void SetDirection(Vector2 direction)
    {
        //set the direction normalized , to get an unit vector
        _direction = direction.normalized;
        isReady = true;//set the flag to true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            //get the bullets current position 
            Vector2 position = transform.position;

            //compute the bullets new position
            position += -_direction * speed * Time.deltaTime;

            //update the bullets position
            transform.position = position;

            //removing the bullet when it goes out of the screen

            //button left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            ////top-right poit of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //If the bullet goes out side the screen then destroy
            if((transform.position.x<min.x)||(transform.position.x > max.x)||
                    (transform.position.y < min.y)|| (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }


        }
    }
}
