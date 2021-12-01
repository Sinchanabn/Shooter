using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{

    Text scoreTextUI;//Ref variable for text
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTet();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //to get the Text UI component of this game Object
        scoreTextUI = GetComponent<Text>();
        
    }
    void UpdateScoreTet()
    {
        string scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
