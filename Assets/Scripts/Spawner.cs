using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemiesRef;
    
    private GameObject spawnEnemies;
    public Transform topLeft, topRight, middle;
    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {

        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(1,3));

            randomIndex = Random.Range(0,enemiesRef.Length); //random spawn of enemies
            randomSide = Random.Range(0,2);

            spawnEnemies = Instantiate(enemiesRef[randomIndex]);

            if(randomSide == 0) {
                spawnEnemies.transform.position = topLeft.position;
            }
            else if(randomSide == 1) {
                spawnEnemies.transform.position = topRight.position;
            }
            else {
                spawnEnemies.transform.position = middle.position;
            //  spawnEnemies.transform.localScale = new Vector3(-5,5f,0f);
            }
        }

    }
   
}
