using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public int damage = 10;
    public float maximumLifespan = 60f  ;
    // Start is called before the first frame update

    float lifespan = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroy if object has been alive for 60 seconds
        lifespan += Time.deltaTime;
        if (lifespan >= maximumLifespan){
            Destroy(gameObject);
        }

        
    }
    // get collider. if hit enemy, do damage
    void OnTriggerEnter(Collider other){
        // if layer === "Shootable"
        if (other.gameObject.layer == 6){        
            print("enemy hit!");
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                print("enemy got hit!");
                enemyHealth.TakeDamage(damage, other.transform.position);
                Destroy(gameObject);
            }
        }
    }
}
