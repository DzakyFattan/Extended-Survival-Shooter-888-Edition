using UnityEngine;
using System.Collections;

public class EnemyMovementEuclidean : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    public float speed = 2.0f;

    private void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
    }


    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.LookAt(player.position);

            // rotate the enemy to face the player
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), 0.1f);
        }
        else
        {
            // stop moving

        }
    }
}
