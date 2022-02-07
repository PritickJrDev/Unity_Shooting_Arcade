using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 tempPos;
    private Transform playerPos;

    void Start(){
        playerPos = GameObject.FindWithTag("Player").transform; 
    }

    void LateUpdate(){

       tempPos = transform.position;
       tempPos.x = playerPos.position.x;
       transform.position = tempPos;
   }
}
