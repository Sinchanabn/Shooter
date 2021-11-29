using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    float bulSpreed;


    // Start is called before the first frame update
    void Start()
    {
        bulSpreed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the bullet position
        Vector2 position = transform.position;

        //computing te bullet new position
        position = new Vector2(position.x, position.y + bulSpreed * Time.deltaTime);

        //updating the bullet position
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //If the bullet went outside the camera it should destroy
        if(transform.position.y>max.y)
        {
            Destroy(gameObject);

        }





    }
}
