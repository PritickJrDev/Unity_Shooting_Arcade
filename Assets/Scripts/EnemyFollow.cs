using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Enemy();
    }

    void Enemy() {
        speed = 5f;
        if(target != null) {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
       // GameObject.Find("Enemy1").transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
      //  speed = 2f;
    }

//    void OnCollisionEnter2D(Collision2D collisionInfo)
//    {
//        if(collisionInfo.gameObject.CompareTag("Player")) {
//            Destroy(gameObject);
//            Debug.Log("object destoyed");
//        }
//    }

}
