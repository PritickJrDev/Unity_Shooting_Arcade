using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyF2 : MonoBehaviour
{

    private Transform target;
    public float speed=2;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    void Update()
    {
        if(target != null)
        transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
    }

//     void OnCollisionEnter2D(Collision2D collisionInfo)
//    {
//        if(collisionInfo.gameObject.CompareTag("Player")) {
//            Destroy(gameObject);
//            Debug.Log("object destoyed");
//        }
//    }
}
