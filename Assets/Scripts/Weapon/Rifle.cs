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
        // position: -0.1 -0.08, -0.03
        transform.localPosition = new Vector3(-0.1f, -0.08f, -0.03f);
        // rotation: -3.4, 0.1, 95.3
        transform.localRotation = Quaternion.Euler(-3.4f, 0.1f, 95.3f);


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
