using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjectile : MonoBehaviour
{

    [SerializeField]
    private Transform left, right;

    private GameObject spawnedBall;
    public GameObject rollingBall;
 
    private int randomSide;

    private IEnumerator coroutine;

    

    void Start()
    {
        // StartCoroutine(SpawnMonsters());

         coroutine = SpawnMonsters();
         StartCoroutine(coroutine);
    }

    void Update(){
       if (Time.time >= 30f) {
           StopCoroutine(coroutine);
         }
    }

    IEnumerator SpawnMonsters()
    {
      while (true)
      {
        yield return new WaitForSeconds(5);
    
       
        randomSide = Random.Range(0,1);

        spawnedBall = Instantiate(rollingBall);

        if(randomSide == 0) {
            spawnedBall.transform.position = left.position;
            spawnedBall.GetComponent<RollBall>().speed = Random.Range(4,10); //monsters approaching from left side
        }
        // else {
        //     spawnedBall.transform.position = right.position;
        //     spawnedBall.GetComponent<RollBall>().speed = -Random.Range(4,10); //monsters approching from right side
        //     spawnedBall.transform.localScale = new Vector3(-1f, 1f, 1f);
        // }
      }
    }
    
}
