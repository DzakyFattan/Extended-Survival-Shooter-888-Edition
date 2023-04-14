using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    private List<GameObject> targets;
    bool targetInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        targets = new List<GameObject>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Pet" || other.gameObject.tag == "Robot")
        {
            targets.Add(other.gameObject);
        }
        
        if(other.gameObject == player && other.isTrigger == false)
        {
            targets.Add(other.gameObject);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Pet" || other.gameObject.tag == "Robot")
        {
            targets.Remove(other.gameObject);
        }
        
        if(other.gameObject == player && other.isTrigger == false)
        {
            targets.Remove(other.gameObject);
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0)
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

        foreach (GameObject t in targets.ToArray())
        {
            if (t.tag == "Pet") {
                t.transform.LookAt(transform);
            }
            t.GetComponent<IHealth>().TakeDamage(attackDamage);
        }
    }

    public void RemoveTarget(GameObject oldTarget)
    {
        try
        {
            targets.Remove(oldTarget);
        }
        catch (System.Exception)
        {
        }
        
    }
}
