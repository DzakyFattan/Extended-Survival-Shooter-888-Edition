using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMainMenu : Weapon
{
    // get the player right hand
    public GameObject playerRightHand;

    void Awake()
    {
        // set the sword to the right hand
        transform.parent = playerRightHand.transform;
        // position: 0, 0.06, 0 
        // rotation 0, 0, 65
        transform.localPosition = new Vector3(0, 0.06f, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 65);
    }
}
