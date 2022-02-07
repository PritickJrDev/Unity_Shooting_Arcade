using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D projectile;

    public Transform barrelEnd;


    Player obj;

    void Start(){
        obj = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            SoundScript.PlaySound("fire");
            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(projectile,barrelEnd.position,barrelEnd.rotation) as Rigidbody2D;
            projectileInstance.AddForce(barrelEnd.up * 350f);
        }

        // if(Input.GetButtonDown("Fire2")) {
           
        //     obj.DrainMana(20);
        // }
    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if(collision.gameObject.CompareTag("Ground")) {
    //         Destroy(gameObject);
    //     }
    // }


}
