using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the robot will move at.
    //navmeshagent
    private NavMeshAgent nav;               // Reference to the nav mesh agent.

    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject[] enemyPrefabs;

    private int waypointIndex = 0;
    bool reachedEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(waypoints[waypointIndex].position);

        // Set speed
        nav.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.remainingDistance < 0.5f && !reachedEnd )
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            if (waypointIndex == 0)
            {
                Debug.Log("Robot reached the end of the path");
                reachedEnd = true;
            }
            else 
            {
                nav.SetDestination(waypoints[waypointIndex].position);
                SpawnEnemyWave();
            }
        }

        if (reachedEnd)
        {
            GameObject.Find("EscortQuestManager").GetComponent<EscortQuestManager>().EndGame();
        }
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < waypointIndex+3; i++)
        {
            // Instantiate random enemy prefab at spawn points
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPoints[waypointIndex-1].position, spawnPoints[waypointIndex-1].rotation);
        }
        
    }
}
