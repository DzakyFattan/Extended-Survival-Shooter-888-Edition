using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    // get player animator
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

// is attacking
    public void SetIsAttacking(bool isAttacking)
    {
        anim.SetBool("IsAttacking", isAttacking);
    }

// 
    public void setWeaponType(int type)
    {
        anim.SetInteger("WeaponType", type);
    }

    public void SetIsWalking(bool isWalking)
    {
        anim.SetBool("IsWalking", isWalking);
    }

    public void SetDie(bool isDead)
    {
        anim.SetBool("IsDead", isDead);
    }
}
