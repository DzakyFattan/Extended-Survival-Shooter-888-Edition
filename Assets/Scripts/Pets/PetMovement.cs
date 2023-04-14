using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMovement : MonoBehaviour
{
    
    NavMeshAgent nav;
    Vector3 targetPos;
    private Transform target;
    private Transform realTarget;
    private GameObject player;
    public bool chaserPet;
    bool chaseMode = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Ignore collisions with player
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        // Ignore colission with other pets
        GameObject[] pets = GameObject.FindGameObjectsWithTag("Pet");
        foreach (GameObject pet in pets)
        {
            Physics.IgnoreCollision(pet.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set desitnation to the right of the player facing

        if (chaseMode)
        {
            // Set target to player
            realTarget = target;
        }
        else
        {
            // Find the nearest enemy
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float minDistance = 1000;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
            }
            if (nearestEnemy != null)
            {
                realTarget = nearestEnemy.transform;
            }
            else
            {
                realTarget = target;
            }
        }
        nav.SetDestination(realTarget.transform.position);

        bool moving = nav.velocity.magnitude > 0.5f;
        GetComponent<Animator>().SetBool("IsMoving", moving);
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void Knockback()
    {
        // Knockback the pet in the direction it is facing
        Vector3 direction = transform.forward * -1;
        direction.y = 0;
        direction.Normalize();
        
        // Apply knockback force
        GetComponent<Rigidbody>().AddForce(direction * 700);
    }

    public void ChangeMode()
    {
        if (chaserPet)
        {
            chaseMode = !chaseMode;
        }
    }
}
