using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
   public static AudioClip fireSound, explodeSound, gameSound, enemyHitSound, damageSound, auraSound, missleExpSound, missileIncoming,ballFire,ballRoll;
   static AudioSource audio;
   
   void Start(){
       fireSound = Resources.Load<AudioClip>("retro_shoot");
       gameSound = Resources.Load<AudioClip>("game");
       explodeSound = Resources.Load<AudioClip>("explode");
       enemyHitSound = Resources.Load<AudioClip>("hit");
       damageSound = Resources.Load<AudioClip>("damage");
       auraSound = Resources.Load<AudioClip>("saiyan");
       missleExpSound = Resources.Load<AudioClip>("missileExpl");
       missileIncoming = Resources.Load<AudioClip>("missileComing");
       ballFire = Resources.Load<AudioClip>("campfire");
       ballRoll = Resources.Load<AudioClip>("bowling_roll");
       

       audio = GetComponent<AudioSource>();
   }

   public static void PlaySound(string clip){
       switch (clip)
       {
           case "fire":
               audio.PlayOneShot(fireSound);
               break;
           case "playerhit":
                audio.PlayOneShot(explodeSound);
               break;
            case "game":
                audio.PlayOneShot(gameSound);
                break;
            case "enemyhit":
                audio.PlayOneShot(enemyHitSound);
                break;
            case "damagehit":
                audio.PlayOneShot(damageSound);
                break;
            case "saiyan":
                audio.PlayOneShot(auraSound);
                break;
            case "missilehit":
                audio.PlayOneShot(missleExpSound);
                break;
            case "missilecome":
                audio.PlayOneShot(missileIncoming);
                break;
            case "ballcome":
                audio.PlayOneShot(ballRoll);
                break;
            case "ballfire":
                audio.PlayOneShot(ballFire);
                break;
       }
       
   }
}
