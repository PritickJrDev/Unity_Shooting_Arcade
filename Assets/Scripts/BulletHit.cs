using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    public GameObject hitEffect;

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.CompareTag("Enemy1") || other.gameObject.CompareTag("Enemy2") || other.gameObject.CompareTag("Enemy3") || other.gameObject.CompareTag("Missile")) {
           Instantiate(hitEffect, transform.position, transform.rotation);
           Destroy(other.gameObject);
           Destroy(gameObject);
           SoundScript.PlaySound("enemyhit");
       }
        
   }

}
