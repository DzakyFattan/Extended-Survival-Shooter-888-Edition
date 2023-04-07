using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    private GameObject target;
    bool targetInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player || other.gameObject.tag == "Pet" && other.isTrigger == false)
        {
            targetInRange = true;
            target = other.gameObject;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player || other.gameObject.tag == "Pet" && other.isTrigger == false)
        {
            targetInRange = false;
            target = null;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && targetInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack ()
    {

        // Precondition: targetInRange == true
        timer = 0f;
        if (target == null)
        {
            return;
        }

        if(target.tag == "Pet")
        {
            target.GetComponent<PetHealth>().TakeDamage(attackDamage);
            target.transform.LookAt(transform);
        }
        else if(target.tag == "Player")
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
