using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMovement : MonoBehaviour
{
    private Transform target;
    NavMeshAgent nav;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Set desitnation to the right of the player facing
        targetPos = target.position + target.right * 2;
        nav.SetDestination(targetPos);

        bool moving = nav.velocity.magnitude > 0.5f;
        GetComponent<Animator>().SetBool("IsMoving", moving);

        
    }
}
