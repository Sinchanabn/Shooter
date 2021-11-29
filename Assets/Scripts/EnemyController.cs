using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        //To get the Enemy current position
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Updating the enemy position
        transform.position = position;

        //Storing the Button left camera bond position
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Destroying the enemy if the enemy went outside the screen
        if(transform.position.y<min.y)
        {
            Destroy(gameObject);
        }

        
    }
}
