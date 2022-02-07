using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed;
    public float stop;
    public float retret;
   
    private Transform target;

     public Rigidbody2D projectile;
     public Transform barrelEnd;
     public Transform anotherBEnd;
     public Transform newBEnd;

    public Transform missileSpawner1;
    public Transform missileSpawner2;
    public Transform missileSpawner3;

    public GameObject bomb;
    public GameObject missile;
    private float timeBtwshots;
    public float startTimeShots;

    public GameObject spawnEffect;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBtwshots = startTimeShots;

    }

    // Update is called once per frame
    void Update()
    {
       // follow();
        Invoke("follow",30);
    }

    public void follow(){
      if(Vector2.Distance(transform.position, target.position) > stop) {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        
       // Debug.Log("first");
      }
      else if(Vector2.Distance(transform.position, target.position) < stop && Vector2.Distance(transform.position, target.position) > retret) {
        transform.position = this.transform.position;
        //Debug.Log("second");
      }
      else if(Vector2.Distance(transform.position, target.position) < retret){

            if(timeBtwshots <= 0) {
              Instantiate(spawnEffect, transform.position, transform.rotation);
            
            //  Instantiate(bomb, barrelEnd.position, Quaternion.identity);
            //  Instantiate(bomb, anotherBEnd.position, Quaternion.identity);
            //  Instantiate(bomb, newBEnd.position, Quaternion.identity);
             Rigidbody2D projectileInstance;
             projectileInstance = Instantiate(projectile,barrelEnd.position,barrelEnd.rotation) as Rigidbody2D;
             projectileInstance.AddForce(barrelEnd.up * 50f);

            projectileInstance = Instantiate(projectile,anotherBEnd.position,barrelEnd.rotation) as Rigidbody2D;
            projectileInstance.AddForce(anotherBEnd.up * 50f);

            projectileInstance = Instantiate(projectile,newBEnd.position,barrelEnd.rotation) as Rigidbody2D;
            projectileInstance.AddForce(newBEnd.up * 50f);

             StartCoroutine(MissileSpawn());


            timeBtwshots = startTimeShots;
          } else {
            timeBtwshots -= Time.deltaTime;
          }

         
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
      }

      
    }


    
    IEnumerator MissileSpawn()
    {
      while (true)
      {
        yield return new WaitForSeconds(Random.Range(5,10));

        Instantiate(missile, missileSpawner1.position, Quaternion.identity);
        Instantiate(missile, missileSpawner2.position, Quaternion.identity);
        Instantiate(missile, missileSpawner3.position, Quaternion.identity);
        SoundScript.PlaySound("missilecome");
      }
    }



}























