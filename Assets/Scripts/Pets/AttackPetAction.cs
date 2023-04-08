using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPetAction : PetAction
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public Transform projectileSpawnPoint;
    public float attackRange;
    public float attackSpeed;
    private LineRenderer lineRenderer;
    private GameObject target;
    private float timer;

    public override void StartAction()
    {
        target = FindClosestEnemy();
        
        if (target != null)
        {
            transform.LookAt(target.transform);
            
            // Shoot projectile in the direction of the target 
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileSpeed;
        }
    }

    public GameObject FindClosestEnemy(){
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance < attackRange)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;

    }

    public void FixedUpdate()
    {
        if (timer > attackSpeed)
        {
            timer = 0;
            StartAction();
        }
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }


}