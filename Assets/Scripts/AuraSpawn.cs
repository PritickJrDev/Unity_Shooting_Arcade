using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AuraSpawn : MonoBehaviour
{
    public GameObject aura;

    private bool activeAura;

    private Player p;

    public GameObject auraEffect;


    void Start()
    {
        p = GetComponent<Player>();
        activeAura = false;
        aura.SetActive(false);
    }

    
    public void Update()
    {
        if(Input.GetButtonDown("Fire2") || Input.GetButtonUp("Fire2")) {
            aura.SetActive(false);
        }
        
        if(Input.GetMouseButton(1) && p.currentMana > 5) {
            p.DrainMana(1);
            if(!activeAura) {
                aura.SetActive(true);
                activeAura = true;
            }
            else {
                aura.SetActive(false);
                activeAura = false;
            }
        }

        // if (Input.touchCount > 0 && p.currentMana > 5)
        // {
        //     Touch first = Input.GetTouch (0);
        //     if (first.phase == TouchPhase.Stationary) 
        //     {
        //         p.DrainMana(1);
        //         if(!activeAura) {
        //             aura.SetActive(true);
        //             activeAura = true;
        //         }
        //         else {
        //             aura.SetActive(false);
        //             activeAura = false;
        //         }
        //     }
        // }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(activeAura) {
            if(other.tag == "Enemy1" || other.tag == "Enemy2" || other.tag == "Enemy3" || other.tag == "Missile" || other.tag == "Orb") {
                Destroy(other.gameObject);
                Instantiate(auraEffect, transform.position, transform.rotation);
            }
        }    
    }

}
