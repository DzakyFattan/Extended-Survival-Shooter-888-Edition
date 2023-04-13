using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Titan : MonoBehaviour
{
    // public target
    public Transform target;
    // get sibling animator
    private Animator animator;



    // private phase. 1 and 2
    private int phase = 1;
    private int damage = 10;
    private float attackCooldown = 5f;
    // timer last attack
    private float lastAttack = 0f;
    // public charge duration
    public float chargeDuration = 2f;
    // private current action: "Idle", "Charge", "Dash"
    private string currentAction = "Idle";
    // private target locked position
    private Vector3 targetLockedPosition;
// UI slider for health
    public Slider healthSlider;

    private float roarCooldown = 3f;

// speed
public float speed = 5f;
    

    void Awake(){
        // get sibling animator
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // set idle animation
        animator.SetTrigger("Idle");
        
    }

    void EndGame(){
        print("end game");
        GameObject.Find("BossSceneManager").GetComponent<BossSceneManager>().EndGame();

    }

    // Update is called once per frame
    void Update()
    {
        // get health from EnemyHealth.cs
        int health = GetComponent<EnemyHealth>().currentHealth;
        int startingHealth = GetComponent<EnemyHealth>().startingHealth;
        float startingHealthFloat = (float) startingHealth;
        float healthFloat = (float) health;
        // update the UI slider
        healthSlider.value = (int) Math.Round((float)(healthFloat / startingHealthFloat) * 100);
        if(health <= 0){
            Invoke("EndGame", 10f);
            return;
        }

        // set phase based on health. when health is 20% or less, phase is 2
        if (health <= startingHealth * 0.3 && phase == 1){
            phase = 2;
            print("phase 2");
            // set current action to "Roar"
            currentAction = "Roar";
            lastAttack = Time.time;


            transform.localScale = new Vector3(3, 3, 3);
            damage = damage * 2;
            attackCooldown = attackCooldown / 2;
            speed = speed * 2;


            // set animation to Roar
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);

            animator.SetBool("Roar", true);
        }

        else if(currentAction == "Roar"){
            print("roar");
            // change scale, damage, attack cooldown
            

            // return to idle based on roar cooldown
            if (Time.time - lastAttack > roarCooldown){
                lastAttack = Time.time;
                currentAction = "Idle";
                animator.SetBool("Roar", false);
                animator.SetBool("Idle", true);
            }

        }

        else if(currentAction == "Idle"){



            // rotate facing to target
            transform.LookAt(target);
            // if enemy is near, do this
            if (Vector3.Distance(transform.position, target.position) < 5){
                // attack
                // change current action to "Attack"
                currentAction = "Attack";
                // set animation to Attack
                animator.SetBool("Idle", false);
                animator.SetBool("Attack", true);
            }
            // change current action based on attack cooldown and last attack time
            if (Time.time - lastAttack > attackCooldown){
                currentAction = "Charge";
                // stop idle animation

                animator.SetBool("Idle", false);
                animator.SetBool("Charge", true);
                
            }
        }
        else if(currentAction == "Attack"){
            // attack
            // change current action to "Idle"
            currentAction = "Idle";
            // change last attack time
            lastAttack = Time.time;
            // set animation to Idle
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", true);
        }
        else if(currentAction == "Charge"){
            // set animation to Charge
            // update target locked position
            targetLockedPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetLockedPosition);
            targetLockedPosition = targetLockedPosition + transform.forward * 5;

            // when charge duration is over, change current action to "Dash"
            if (Time.time - lastAttack > attackCooldown + chargeDuration){
                currentAction = "Dash";
                animator.SetBool("Charge", false);
                animator.SetBool("Dash", true);
            }
        }
        else if(currentAction == "Dash"){
            // move forward
            transform.position += transform.forward * speed * Time.deltaTime;
            // change current action to "Idle"
            if (Vector3.Distance(transform.position, targetLockedPosition) < 1){
                currentAction = "Idle";
                animator.SetBool("Dash", false);
                animator.SetBool("Idle", true);
            }
            // change last attack time
            lastAttack = Time.time;
        }
        
    }

    void Die(){
        // die
        animator.SetTrigger("Die");
    }
    // when target touch titan, target take damage
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    } 
}
