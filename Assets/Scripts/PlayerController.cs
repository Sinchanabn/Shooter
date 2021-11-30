using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public GameObject GameManagerGo;//ref to game manager script


    //To store the player movment
    Rigidbody2D rb;
    public float speed;


    //Player  prefab game obj
    public GameObject playerBullet;
    public GameObject bulletPosition1;
    public GameObject bulletPosition2;
    public GameObject bulletPosition3;

    //to store the explosion prefab
    public GameObject explosionGo;

    //Reference to the lives uI text
    public Text LivesUIText;

    const int MaxLives = 3;//Max player lives
    int Lives;//current player lives

    public void Init()
    {
        Lives = MaxLives;

        //Updating the lives UI text
        LivesUIText.text = Lives.ToString();

        //set this player game object to active
        gameObject.SetActive(true);

    }

    // Start is called before the first frame update*/
    void Start()
    {
        InvokeRepeating("Shoot", 1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

        //Calling the bullet functon for every 30 secs
        


        //Accessing the Axis
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        Vector2 direction = new Vector2(x, y).normalized;

        //Calling the move function to compute players position
        Move(direction);
    }

    //Method to move the player with in camera bonds.
    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        //Setting up the Max and Min values for player horizontal movment

        max.x = max.x -1.5f;
        min.x = min.x +1.5f;

        // //Setting up the Max and Min values for player Vertical movment
        max.y = max.y - 1.5f;
        min.y = min.y + 1.5f;

        //
        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        //Clamping the player position
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

    }

    void OnTriggerEnter2D(Collider2D col)

    {

        //Detecting the collition of enemy and enemy bullet
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExlosion();

            Lives--;//Substracting one lives
            LivesUIText.text = Lives.ToString();//Updating the lives UI text

            if(Lives==0)//If over player is dead
            {
                //chnage the Game Manager State to game over state

                GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                //hide the player
                gameObject.SetActive(false);
            }

            
           
        }

    }
    void Shoot()
    {
        //Instantiating the first bullet
        GameObject bullet01 = (GameObject)Instantiate(playerBullet);
        bullet01.transform.position = bulletPosition1.transform.position;
        bullet01.transform.rotation = bulletPosition1.transform.rotation;//Set the bullet position

        //Instantiating the Second bullet
        GameObject bullet02 = (GameObject)Instantiate(playerBullet);
        bullet02.transform.position = bulletPosition2.transform.position;//Set the bullet position

        //Instantiating the Third bullet
        GameObject bullet03 = (GameObject)Instantiate(playerBullet);
        bullet03.transform.position = bulletPosition3.transform.position;//Set the bullet position

    }
    //Method to Instantite an Explosion
    void PlayExlosion()
    {
        //Instatiating the explosion
        GameObject explosion= (GameObject)Instantiate(explosionGo);

        explosion.transform.position = transform.position;
    }

    


}