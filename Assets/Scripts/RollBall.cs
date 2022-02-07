using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RollBall : MonoBehaviour
{
    public float speed;

    public GameObject fireEffect;
    
    [SerializeField]
    private Rigidbody2D mybody;

    void Awake(){
        mybody.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        CameraShaker.Instance.ShakeOnce(1,20,0.1f,0.1f);
        Instantiate(fireEffect, transform.position, transform.rotation);
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }
}
