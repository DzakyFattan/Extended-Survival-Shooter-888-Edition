using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    // get player animator
    public PlayerAnimationController animController;
    
    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    public int damage = 10;

    void Awake()
    {
        animController = GetComponent<PlayerAnimationController>();
        // set weapon type to sword
    }

    // Update is called once per frame
    void Update()
    {
        // read input. bad practice, should be in input handler
        // if left mouse button is pressed, attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack(){
        // set is attacking to true
        animController.SetIsAttacking(true);
        // set weapon type to sword
        animController.setWeaponType(3);
        // set is attacking to false after attack cooldown
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack(){
        animController.SetIsAttacking(false);
    }

    // TODO: handle collisions for damaging enemies
}
