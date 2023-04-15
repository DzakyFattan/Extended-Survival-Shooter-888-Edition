using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PetHealth : MonoBehaviour, IHealth
{

    public int startingHealth = 50;
    public int currentHealth;
    public AudioClip deathClip;

    private PetMovement petMovement;
    bool isDead = false;
    Animator anim;
    private AudioSource petAudio;

    public int petIdx;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        petMovement = GetComponent<PetMovement>();
        currentHealth = startingHealth;
        petAudio = GetComponent<AudioSource>();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().AddTarget(gameObject);
        }
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // Apply knockback
        petMovement.Knockback();
        // Play hurt sound
        petAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;

        // Play death clip
        petAudio.clip = deathClip;

        petAudio.Play();

        // Remove pet from target list
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().RemoveTarget(gameObject);
            enemy.GetComponent<EnemyAttack>().RemoveTarget(gameObject);
        }

        State.Instance.ownedPets.Remove(petIdx);


        Destroy(gameObject);
    }
}
