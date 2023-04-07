using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{

    // get player animator
    public PlayerAnimationController animController;
    // get the player right hand
    public GameObject playerRightHand;


    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    public int damage = 10;
                           

    float timer = 0;
    float effectsDisplayTime = 0.2f;
    void Awake()
    {
        // set the sword to the right hand
        transform.parent = playerRightHand.transform;
        // position: -0.493, 0.066, -0.13
        // rotation: 49.5, -28.7, 150.7
        transform.localPosition = new Vector3(-0.493f, 0.066f, -0.13f);
        transform.localRotation = Quaternion.Euler(49.5f, -28.7f, 150.7f);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.parent = playerRightHand.transform;
        // position: -0.493, 0.066, -0.13
        // rotation: 49.5, -28.7, 150.7
        transform.localPosition = new Vector3(-0.493f, 0.066f, -0.13f);
        transform.localRotation = Quaternion.Euler(49.5f, -28.7f, 150.7f);


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

        if (timer >= attackCooldown * effectsDisplayTime)
        {
            DisableEffects();
        }

    }

    void DisableEffects(){
        // gun line
    }
    void Attack(){
        print("attack!");
        // set is attacking to true
        animController.SetIsAttacking(true);

        timer = 0;
    }

    void ResetAttack(){
        animController.SetIsAttacking(false);
        // turn off line renderer

    }

    // TODO: handle collisions for damaging enemies
}
