using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public int damage = 10;
    public float maximumLifespan = 60f  ;
    // Start is called before the first frame update

    float lifespan = 0f;

    private PetManager playerPetManager;
    void Start()
    {
        playerPetManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PetManager>();
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

        int totalDamage = damage + playerPetManager.getBuffDamage();

        // if layer === "Shootable"
        if (other.gameObject.layer == 6){        
            print("enemy hit!");
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                print("enemy got hit!");
                enemyHealth.TakeDamage(totalDamage, other.transform.position);
                Destroy(gameObject);
            }
        }
    }
}
