using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{

    // get player animator
    public PlayerAnimationController animController;
    // get the player right hand
    public GameObject playerRightHand;
    public GameObject playerLeftHand;
    public GameObject ArrowPrefab;

    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    public int damage = 10;
    
    float timer = 0;
    void Awake()
    {
           // set the sword to the right hand
        transform.parent = playerLeftHand.transform;
        // position: 0, 0.06, 0.03
        // rotation: -18.8, 0, -83.5
        transform.localPosition = new Vector3(0, 0.06f, 0.03f);
        transform.localRotation = Quaternion.Euler(-18.8f, 0, -83.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.parent = playerLeftHand.transform;
        // position: 0, 0.06, 0.03
        // rotation: -18.8, 0, -83.5
        transform.localPosition = new Vector3(0, 0.06f, 0.03f);
        transform.localRotation = Quaternion.Euler(-18.8f, 0, -83.5f);


        // read input. bad practice, should be in input handler
        // if left mouse button is pressed, attack
        if (Input.GetButton("Fire1") && timer >= attackCooldown)
        {
            Attack();
        }
        if (timer >= attackCooldown)
        {
            ResetAttack();
        }
    }
    void Attack(){
        print("attack!");
        // set is attacking to true
        animController.SetIsAttacking(true);
        // create new arrow. rotate 90 degrees to the left based on the rotation of the bow
        GameObject arrow = Instantiate(ArrowPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        // give it a velocity based on the rotation of the bow to vector3(1,0,0)
        arrow.GetComponent<Rigidbody>().velocity =  transform.rotation * new Vector3(-1,0,0)* 10;


        timer = 0;
    }

    void ResetAttack(){
        animController.SetIsAttacking(false);
    }

}
