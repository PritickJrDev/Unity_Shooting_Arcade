using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BombBlast : MonoBehaviour
{

    private bool isTrue;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    public LayerMask layer;

    Player blastDamage;

    void Start(){

        blastDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(Blast());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")){
            //Destroy(gameObject);
            isTrue = true;
        }
    }

    IEnumerator Blast()
    {
        yield return new WaitForSeconds(3);
        if(isTrue) {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundScript.PlaySound("playerhit");
            CameraShaker.Instance.ShakeOnce(4,4,0.1f,1f);
           
           Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layer);
           
           foreach(Collider2D obj in colliders) { //all the collider game objects inside blast radius to be affected
               Vector2 direction = obj.transform.position - transform.position;
               obj.GetComponent<Rigidbody2D>().AddForce(direction * force);

               blastDamage.TakeDamage(40);
           }
          
            Destroy(gameObject);
            isTrue = false;
        }

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);    
    }
}
