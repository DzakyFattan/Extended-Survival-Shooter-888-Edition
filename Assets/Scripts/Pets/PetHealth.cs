using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetHealth : MonoBehaviour
{

    public int startingHealth = 50;
    public int currentHealth;

    private PetMovement petMovement;
    bool isDead = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        petMovement = GetComponent<PetMovement>();
        currentHealth = startingHealth;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().AddTarget(gameObject);
        }
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        anim.SetBool("IsMoving", false);
        anim.SetTrigger("Hurt");

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        // Remove pet from target list
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().RemoveTarget(gameObject);
        }
        // Destroy pet
        Destroy(gameObject);
    }
}
