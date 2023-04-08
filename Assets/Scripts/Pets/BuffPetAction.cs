using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPetAction : MonoBehaviour
{
    
    public float buffRange = 3;
    public int buffAmount = 10;
    private bool buffing = false;
    private GameObject player;
    private GameObject gunBarrelEnd;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gunBarrelEnd = player.transform.Find("GunBarrelEnd").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= buffRange)
        {
            if (!buffing)
            {
                buffing = true;
                gunBarrelEnd.GetComponent<PlayerShooting>().damagePerShot += buffAmount;
            }
        }
        else
        {
            if (buffing)
            {
                buffing = false;
                gunBarrelEnd.GetComponent<PlayerShooting>().damagePerShot -= buffAmount;
            }
        }
    }
}
