using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool gameIsPaused = false;
   public GameObject pauseMenuUI;

   private Player ply;

   void Start(){
       ply = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
   }
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || ply.currentHealth <= 0) {
            if(gameIsPaused && ply.currentHealth > 0) {
                Resume();
            } else {               
                Pause();
            }
        }
        Time.timeScale = 1f;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Restart(){
        
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

       // Application.LoadLevel("SampleScene");
        
    }

    public void QuitGame(){
        Application.Quit();
    }
}
