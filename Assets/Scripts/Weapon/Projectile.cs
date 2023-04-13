using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 ShootDirection;
    public float range = 100f;
    public int damage = 50;
    // public parent game object
    GameObject weapon;
    GameObject weaponTip;
    // public projecitle direction

    // LineRenderer called gunLine
    LineRenderer gunLine;
  
    // gunline
    int shootableMask;
    
    Ray shootRay = new Ray();                                   
    RaycastHit shootHit;
    
    bool enemyHit = false;
    void Awake(){
        weapon = transform.parent.gameObject;
        weaponTip = weapon.transform.Find("Tip").gameObject;
        transform.parent = weaponTip.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        
        // set the gunLine to the LineRenderer component
        gunLine = GetComponent<LineRenderer>();

        shootableMask = LayerMask.GetMask("Shootable");
    }
    
    void OnEnable(){
        enemyHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.TransformDirection(ShootDirection);

        // update gunline location
        gunLine.SetPosition(0, transform.position);


        shootRay.origin = transform.position;
        shootRay.direction = direction;
        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask)){
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null && enemyHit == false)
            {
                print("enemy got hit!");
                enemyHealth.TakeDamage(damage, shootHit.point);
                enemyHit = true;
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else{
            gunLine.SetPosition(1, transform.position + direction * range);
        }
    }
}
