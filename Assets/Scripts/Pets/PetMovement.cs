using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMovement : MonoBehaviour
{
    
    NavMeshAgent nav;
    Vector3 targetPos;
    private Transform target;
    private GameObject player;

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
        nav.SetDestination(target.transform.position);

        bool moving = nav.velocity.magnitude > 0.5f;
        GetComponent<Animator>().SetBool("IsMoving", moving);
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
