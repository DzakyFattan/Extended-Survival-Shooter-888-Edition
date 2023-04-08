using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPetAction : PetAction
{
    public float healSpeed = 1;
    public int healAmount = 10;
    public float healRange = 3;
    private float timer;
    private GameObject player;

    [SerializeField]
    ParticleSystem healParticles;

    // Start is called before the first frame update
    public override void StartAction()
    {
        // Check distance to player
        if (Vector3.Distance(transform.position, player.transform.position) <= healRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth.currentHealth < playerHealth.startingHealth)
            {
                timer = 0;

                // Turn on the particle system
                healParticles.Play();

                // Heal player
                player.GetComponent<PlayerHealth>().Heal(healAmount);
            }
        }
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void FixedUpdate()
    {
        if (timer > healSpeed)
        {
            StartAction();
        }
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }
}
