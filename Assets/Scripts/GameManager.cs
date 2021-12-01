using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Reference to our Game objet
    public GameObject playButton;
    public GameObject playerShip;//ref to player spawner
    public GameObject enemySpawner;//ref to enemy spawnerover 
    public GameObject gameOver;//Ref to Game over
    public GameObject scoreUIText;//ref to score text

    //public GameObject PlayerBulletSpawner;// ref to bullets




    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
        
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                //hide game over
                gameOver.SetActive(false);
                //set play button visible(active)
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                //Reset the score
                scoreUIText.GetComponent<GameScore>().Score = 0;

                //hiding the button on game play state;
                playButton.SetActive(false);

                //set the player visible and init the player lives
                playerShip.GetComponent<PlayerController>().Init();
               // playerShip.GetComponent<PlayerController>().Shoot();

                //Start enemy Spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                break;
            case GameManagerState.GameOver:
                //Stop Enemy Spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //Display game over
                gameOver.SetActive(true);

                //Change game manager state to operating state after 8 seconds
                Invoke("ChnageToOperatingState", 1f);


                break;
        }
    }

    //Method to set game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();

    }
    //Our Play butom will call this function
    //when the user clcks the buttom

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
    
    //Method to set game manager state to operating state
    public void ChnageToOperatingState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

}
