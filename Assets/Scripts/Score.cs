using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    //public float pointsIncrease;

    void Start()
    {
        scoreAmount = 0f;   
      //  pm = GameObject.FindGameObjectWithTag("score").GetComponent<PauseMenu>();
    }   

    void Update(){
           
        scoreText.text = "Score: " + (int)scoreAmount;
        scoreAmount += Time.deltaTime;
        //scoreText.text = Time.time.ToString("0");
              
            
    }
}
