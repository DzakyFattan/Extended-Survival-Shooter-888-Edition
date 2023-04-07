using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // public parent game object
    public GameObject weapon;
    public GameObject weaponTip;
    // LineRenderer called gunLine
    LineRenderer gunLine;
  
    // gunline
    public float range = 100f;
    int shootableMask;
    
    Ray shootRay = new Ray();                                   
    RaycastHit shootHit; 
    
    void Awake(){

        transform.parent = weaponTip.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        
        // set the gunLine to the LineRenderer component
        gunLine = GetComponent<LineRenderer>();
        // set the gunLine to the right hand
        // set local position
        // turn of line renderer
        gunLine.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.TransformDirection(new Vector3(1, 0, 0));

        // update gunline location
        gunLine.SetPosition(0, transform.position);


        // shootRay.origin = transform.position;
        // shootRay.direction = transform.forward;
        // if(Physics.Raycast(shootRay, out shootHit, range, shootableMask)){
        //     EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

        //     if (enemyHealth != null)
        //     {
        //         enemyHealth.TakeDamage(50, shootHit.point);
        //     }



        //     gunLine.SetPosition(1, shootHit.point);
        // }
        // else{

            // set direction 1,0,0 based on the transform
            gunLine.SetPosition(1, transform.position + direction * range);
        // }
        
        
    }
}
