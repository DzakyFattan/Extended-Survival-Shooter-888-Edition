using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    GameObject target;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    private List<GameObject> targets;


    private void Awake ()
    {
        // create targets including tags Player and Pet
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        targets.AddRange(GameObject.FindGameObjectsWithTag("Pet"));
        targets.AddRange(GameObject.FindGameObjectsWithTag("Robot"));

        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        // find the closest target with the lowest distance and health > 0
        float minDistance = Mathf.Infinity;
        foreach (GameObject t in targets)
        {
            float distance = Vector3.Distance(transform.position, t.transform.position);
            if (t.tag == "Pet")
            {
                if (distance < minDistance && t.GetComponent<PetHealth>().currentHealth > 0)
                {
                    minDistance = distance;
                    target = t;
                }
            }
            else if (t.tag == "Player")
            {
                if (distance < minDistance && t.GetComponent<PlayerHealth>().currentHealth > 0)
                {
                    minDistance = distance;
                    target = t;
                }
            }
            else if (t.tag == "Robot") {
                if (distance < minDistance && t.GetComponent<RobotHealth>().currentHealth > 0)
                {
                    minDistance = distance;
                    target = t;
                }
            }
        }

        // targetHealth is the health of the target
        int targetHealth = 0;
        if (target.tag == "Pet")
        {
            targetHealth = target.GetComponent<PetHealth>().currentHealth;
        }
        else if (target.tag == "Player")
        {
            targetHealth = target.GetComponent<PlayerHealth>().currentHealth;
        }
        else if (target.tag == "Robot")
        {
            targetHealth = target.GetComponent<RobotHealth>().currentHealth;
        }

        if (enemyHealth.currentHealth > 0 && targetHealth > 0)
        {
            nav.SetDestination (target.transform.position);
        }
        else
        {
           nav.enabled = false;
        }
    }

    public void AddTarget(GameObject newTarget)
    {
        targets.Add(newTarget);
    }

    public void RemoveTarget(GameObject oldTarget)
    {
        targets.Remove(oldTarget);
    }
}
