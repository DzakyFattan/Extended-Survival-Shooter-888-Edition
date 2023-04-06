using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 10;
    public int damage = 10;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
           if (enemyHealth != null)
           {
               enemyHealth.TakeDamage(damage, collision.transform.position);
           }
        }
        Destroy(gameObject);
    }
}
