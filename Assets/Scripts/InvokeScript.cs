using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeScript : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
       // Invoke("SpawnObject",2); //spawn single object
        InvokeRepeating("SpawnObject",2,1); // spawn multiple objects, use it for making rain like scene 
        //CancelInvoke();
    }

    void SpawnObject(){
        float x = Random.Range(-20f, 20f);
        Instantiate(target,new Vector3(x, 10f, 0f), Quaternion.identity);
    }
   
}
