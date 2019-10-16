using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //For UI elements
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper sk;
    public Text scoreText;

    void Awake(){
        //If there's another, this one shouldn't exist
        if(sk != null)
            Destroy(sk);
        //Otherwise, become the one
        sk = this;
    }
    
    void Start(){
        setText();
    }

    int score = 0;
    
    //Adding to the score
    public void addScore(int s){
        score += s;
        setText();
    }

    void setText(){
        scoreText.text = "Score: " + score.ToString();
    }


}
