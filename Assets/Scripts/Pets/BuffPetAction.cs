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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= buffRange)
        {
            if (!buffing)
            {
                buffing = true;
                player.GetComponent<PetManager>().updateBuffDamage(buffAmount);
            }
        }
        else
        {
            if (buffing)
            {
                buffing = false;
                player.GetComponent<PetManager>().updateBuffDamage(-buffAmount);
            }
        }
    }

    void OnDestroy()
    {
        if (buffing)
        {
            player.GetComponent<PetManager>().updateBuffDamage(-buffAmount);
        }
    }
}
