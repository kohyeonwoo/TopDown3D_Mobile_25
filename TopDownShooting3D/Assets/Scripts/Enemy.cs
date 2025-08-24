using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public float maxHealth;
   
    public float currentHealth;

    public Transform target;

    public LayerMask ground;

    public LayerMask player;

    //주변 돌아다니는 부분 관련 변수

    public Vector3 walkPoint;

    private bool bWalkPointSet;

    public float walkPountRange;

    //

    //공격 관련 변수

    public float timeBetweenAttacks;

    private bool alreadyAttacked;

    //

    //움직임 관련 상황 변수

    public float sightRange;

    public float attackRange;

    public bool bPlayerInSightRange;

    public bool bPlayerInAttackRange;

    //

    public void Damage(float Damage)
    {
        currentHealth -= Damage;

        Debug.Log("적이 총알에 맞고 피해를 입었습니다");

        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("적이 사망했습니다.");

        Destroy(this.gameObject);
    }

}
