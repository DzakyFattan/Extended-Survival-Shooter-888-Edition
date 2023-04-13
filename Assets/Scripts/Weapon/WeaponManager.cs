using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    // list of weapons
    public List<Weapon> weapons = new List<Weapon>();
    public PlayerAnimationController animController;

    void Awake()
    {
        // // fill weapons based on children
        // weapons.Clear();
        // for (int i = 0; i < transform.childCount; i++)
        // {
        //     Weapon weapon = transform.GetChild(i).GetComponent<Weapon>();
        //     if (weapon != null)
        //     {
        //         weapons.Add(weapon);
        //     }
        // }
        // disable all weapons
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // read number row keys
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            print("0");
            SwitchWeapon(0);
            animController.SetWeaponType(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1");
            SwitchWeapon(1);
            animController.SetWeaponType(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("2");
            SwitchWeapon(2);
            animController.SetWeaponType(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("3");
            SwitchWeapon(3);
            animController.SetWeaponType(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("4");
            SwitchWeapon(4);
            animController.SetWeaponType(4);

        }
    }

    void SwitchWeapon(int index)
    {
        // index 0 mean use no weapon
        if (index == 0)
        {
            // disable all weapons
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].gameObject.SetActive(false);
            }
            return;
        }
        // check if index is valid
        if (index < 0 || index > weapons.Count)
        {
            print("invalid weapon index");
            return;
        }

        // disable all weapons
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
        print("switching to weapon " + index);
        // enable selected weapon
        weapons[index-1].gameObject.SetActive(true);
    }
}
