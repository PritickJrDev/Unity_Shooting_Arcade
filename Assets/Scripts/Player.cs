using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    
    public Rigidbody2D mybody;
  //  public Animator anim;

    private float JumpForce = 11f;
    private float movementX;
    private float moveForce = 7f;
    private bool isGrounded;

    public int maxHealth = 100;
    public int currentHealth;
    public HeathBar healthBar;

    public int maxMana = 100;
    public int currentMana;
    public ManaBar manaBar;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    // [SerializeField] 
    // private Rigidbody2D movePlayer;

     [SerializeField]
     private SpriteRenderer sr;

     public GameObject lifeEffect;

    // [HideInInspector]
    //  public bool playerIsDead;

    void Awake()
    {
        mybody.GetComponent<Rigidbody2D>();
        sr.GetComponent<SpriteRenderer>();   
       // anim.GetComponent<Animator>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerColor();
       // AnimateAura();

    //    if(currentHealth <= 0) {
    //        Destroy(gameObject);
    //        playerIsDead = true;
    //    }
    }

    void FixedUpdate(){
        PlayerJump();
    }

    // void AnimateAura(){
    //     if(Input.GetButtonDown("Fire2")) {
    //         anim.SetBool("aura",true);
    //     } else {
    //         anim.SetBool("aura",false);
    //     }
    // }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Instantiate(lifeEffect, transform.position, transform.rotation);
        SoundScript.PlaySound("damagehit");
    }

    public void DrainMana(int drain) {
        if(currentMana - drain >= 0) {
            currentMana -= drain;
            manaBar.SetMana(currentMana);
            if(regen != null) {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenerateMana());
        }
       
    }

    IEnumerator RegenerateMana()
    {
        yield return new WaitForSeconds(2);

         while(currentMana < maxMana) {
            currentMana += maxMana / 100;
            manaBar.SetMana(currentMana);
            yield return regenTick;
        }
        regen = null;
    
    } 
    

    private void PlayerJump(){
       // float verticalMove = joystick.Vertical; //for joystick jump
        
       // if(verticalMove >= .5f && isGrounded) {
        if(Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, JumpForce) , ForceMode2D.Impulse);
            
        }
    }

    private void PlayerMovement(){
      // movementX = joystick.Horizontal; //joystick movement
        movementX = Input.GetAxisRaw("Horizontal"); 
        transform.position += new Vector3(movementX,0f,0f) * moveForce * Time.deltaTime; 

    }

    private void PlayerColor(){

        sr.GetComponent<SpriteRenderer>().material.color = Color.green;
        
        if(Input.GetKey(KeyCode.A)) {
            sr.GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        if(Input.GetKey(KeyCode.D)) {
            sr.GetComponent<SpriteRenderer>().material.color = Color.blue;
        }
        //random color
        //sr.GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
       
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
        if(collisionInfo.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
        
        // if(collisionInfo.gameObject.CompareTag("Orb")) {
        //    TakeDamage(50);
        //   // Instantiate(lifeEffect, transform.position, transform.rotation);
        //    // Destroy(gameObject);
        // } 
        if(collisionInfo.gameObject.CompareTag("Enemy1") || collisionInfo.gameObject.CompareTag("Enemy2") || collisionInfo.gameObject.CompareTag("Enemy3")) {
            Destroy(collisionInfo.gameObject);
            TakeDamage(10);
        //    Instantiate(lifeEffect, transform.position, transform.rotation);
        }
         if(collisionInfo.gameObject.CompareTag("RollingBall")) {
            Destroy(collisionInfo.gameObject);
            TakeDamage(50);
        //    Instantiate(lifeEffect, transform.position, transform.rotation);
        }  

    }
    
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.gameObject.CompareTag("Orb")) {
    //         TakeDamage(30);
    //     }    
    // }

}
