using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    // get player animator
    public PlayerAnimationController animController;
    // get the player right hand
    public GameObject playerRightHand;


    // set attack cooldown and damage
    public float attackCooldown = 1f;
    public int damage = 10;

    float timer = 0;

    private PetManager playerPetManager;
    void Awake()
    {
        // set the sword to the right hand
        transform.parent = playerRightHand.transform;
        // position: 0, 0.06, 0 
        // rotation 0, 0, 65
        transform.localPosition = new Vector3(0, 0.06f, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 65);
        playerPetManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.parent = playerRightHand.transform;
        // position: 0, 0.06, 0 
        // rotation 0, 0, 65
        transform.localPosition = new Vector3(0, 0.06f, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 65);
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
    void Attack()
    {
        print("attack!");
        // set is attacking to true
        animController.SetIsAttacking(true);
        // set weapon type to sword
        // set is attacking to false after attack cooldown

        timer = 0;
    }

    void ResetAttack()
    {
        animController.SetIsAttacking(false);
    }

    // TODO: handle collisions for damaging enemies
    void OnTriggerEnter(Collider other)
    {

        // if layer === "Shootable"
        if (other.gameObject.layer == 6)
        {
            // print("enemy hit!");
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                int totalDamage = damage + playerPetManager.getBuffDamage();
                // print("enemy got hit!");
                enemyHealth.TakeDamage(totalDamage, other.transform.position);
            }
        }
    }
}
