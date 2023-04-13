using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{

    // get player animator
    public PlayerAnimationController animController;
    // get the player right hand
    public GameObject playerRightHand;
    public GameObject projectile;

    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    float effectsDisplayTime = 0.2f;
                           

    float timer = 0;
    void Awake()
    {
        // set the sword to the right hand
        transform.parent = playerRightHand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.localPosition = new Vector3(-0.493f, 0.066f, -0.13f);
        transform.localRotation = Quaternion.Euler(49.5f, -28.7f, 140f);


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
        // enable projectile
        projectile.SetActive(true);

        timer = 0;
    }

    void ResetAttack(){
        projectile.SetActive(false);

    }

}
