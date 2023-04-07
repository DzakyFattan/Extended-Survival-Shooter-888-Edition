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
    // slider ui bowStrength
    public GameObject bowStrengthSlider;

    // set attack cooldown and damage
    public float attackCooldown = 0.5f;
    public int damage = 10;
    public int maximumVelocity = 50;
    bool isHoldingButton = false;

    int velocity = 0;
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

        transform.parent = playerLeftHand.transform;
        // position: 0, 0.06, 0.03
        // rotation: -18.8, 0, -83.5
        transform.localPosition = new Vector3(0, 0.06f, 0.03f);
        transform.localRotation = Quaternion.Euler(-18.8f, 0, -83.5f);


        // read input. bad practice, should be in input handler
        // read press and hold right mouse button. on release, attack based on duration of press
        if(!isHoldingButton && Input.GetMouseButtonDown(1)){
            isHoldingButton = true;
            print("holding");
            animController.SetIsAttacking(true);
        }
        if(Input.GetMouseButtonUp(1)){
            isHoldingButton = false;
            print("released");
            animController.SetIsAttacking(false);

        }
    }
    // fixedUpdate
    void FixedUpdate(){
        if(isHoldingButton){
            // increase velocity
            velocity += 1;
            // set slider value
            bowStrengthSlider.GetComponent<UnityEngine.UI.Slider>().value = 100 * velocity / maximumVelocity;
            // clamp velocity
            velocity = Mathf.Clamp(velocity, 0, maximumVelocity);
        }
        if(!isHoldingButton && velocity > 0){
            // attack
            Attack();
            // reset velocity
            velocity = 0;
            // set slider value
            bowStrengthSlider.GetComponent<UnityEngine.UI.Slider>().value = 0;
        }
    }
    void Attack(){
        print("attack!");
        // set is attacking to true
        animController.SetIsAttacking(true);
        // create new arrow. rotate 90 degrees to the left based on the rotation of the bow
        GameObject arrow = Instantiate(ArrowPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        // give it a velocity based on the rotation of the bow to vector3(1,0,0)
        arrow.GetComponent<Rigidbody>().velocity =  transform.rotation * new Vector3(-1,0,0)* velocity;
    }

}
