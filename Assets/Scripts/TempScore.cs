using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempScore : MonoBehaviour
{
   public Text tempScore;
   
   private Score score;
   private Player player;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void Update(){
        if(player.currentHealth > 0) {
            tempScore.text = "Current " + score.scoreText.text; 
        }
         if(player.currentHealth <= 0) {
            tempScore.text = "Highest " + score.scoreText.text; 
            Time.timeScale = 0f;
        }
    }   
  
}
