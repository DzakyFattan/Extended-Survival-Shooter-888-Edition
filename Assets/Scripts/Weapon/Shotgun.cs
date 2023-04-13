using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    public int damage = 10;
                            
    // get player animator
    public PlayerAnimationController animController;
    // get the player right hand
    public GameObject playerRightHand;
    // list of projectiles
    public List<GameObject> projectiles;
    
    // set attack cooldown and damage
    float effectsDisplayTime = 0.2f;
    float timer = 0;
    void Awake()
    {
        // set the weapon to the right hand
        transform.parent = playerRightHand.transform;
    }
    void Start(){
        transform.parent = playerRightHand.transform;
        // position: -0.321, 0.11, -0.074
        // rotation: 34.7, -23.7, 151.4
        transform.localPosition = new Vector3(-0.321f, 0.11f, -0.074f);
        transform.localRotation = Quaternion.Euler(34.7f, -23.7f, 151.4f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.parent = playerRightHand.transform;
        // position: -0.321, 0.11, -0.074
        // rotation: 34.7, -23.7, 151.4
        transform.localPosition = new Vector3(-0.321f, 0.11f, -0.074f);
        transform.localRotation = Quaternion.Euler(34.7f, -23.7f, 151.4f);
        // read input. bad practice, should be in input handler
        // if left mouse button is pressed, attack
        if (Input.GetButton("Fire1") && timer >= attackCooldown)
        {
            Attack();
        }
        if (timer >= attackCooldown * effectsDisplayTime)
        {
            ResetAttack();
        }

        if(timer >= attackCooldown){
            animController.SetIsAttacking(false);
        }
    }
     void Attack(){
        // set is attacking to true
        animController.SetIsAttacking(true);
        // enable projectiles
        foreach(GameObject projectile in projectiles){
            projectile.SetActive(true);
        }
        

        timer = 0;
    }

    void ResetAttack(){
        foreach(GameObject projectile in projectiles){
            projectile.SetActive(false);
        }
    }

}
