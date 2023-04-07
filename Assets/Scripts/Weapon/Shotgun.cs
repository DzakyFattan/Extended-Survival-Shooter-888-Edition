using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    // get player animator
    public PlayerAnimationController animController;
    // get the player right hand
    public GameObject playerRightHand;

    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    public int damage = 10;
                            

    float timer = 0;
    void Awake()
    {
           // set the sword to the right hand
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
        if (timer >= attackCooldown)
        {
            ResetAttack();
        }
    }
    void Attack(){
        print("attack!");
        // set is attacking to true
        animController.SetIsAttacking(true);
        // set weapon type to sword
        // set is attacking to false after attack cooldown
            
        timer = 0;
    }

    void ResetAttack(){
        animController.SetIsAttacking(false);
    }

    // TODO: handle collisions for damaging enemies
}
