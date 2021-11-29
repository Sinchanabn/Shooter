using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    //Eneny bullet prefab
    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireenemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Method to fire enemy bullet
    void FireenemyBullet()
    {
        //Get the ref to player
        GameObject playerShip = GameObject.Find("Player");

        if(playerShip!=null)//If player is not dead
        {
            //instaniate enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            //Set the bullet instant position
            bullet.transform.position = transform.position;

            //Computing the bullet direction towards player
           Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Set the bullet direction
            bullet.GetComponent<EnemyBullet>().SetDirection(-direction);



        }


    }
}
