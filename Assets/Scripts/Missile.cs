using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public GameObject explosionEffect;

    private Player p;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void FixedUpdate() //whenever u want to messed with physics then use fixed update
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        SoundScript.PlaySound("missilehit");
        if(other.tag == "Player") {
            p.TakeDamage(20);
        }
    }
  
}
