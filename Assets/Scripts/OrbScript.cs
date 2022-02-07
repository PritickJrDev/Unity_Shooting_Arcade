using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    private Player p;

    void Start(){
            p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Update()
    {
       sr.GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    //  void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")) {
    //         Destroy(gameObject);
    //     }    
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
 
            if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player")) {
                Destroy(gameObject);
            } 

            if(other.gameObject.CompareTag("Player")) {
                    p.TakeDamage(10);
            } 
    }
}
