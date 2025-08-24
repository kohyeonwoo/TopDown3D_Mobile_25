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

    //�ֺ� ���ƴٴϴ� �κ� ���� ����

    public Vector3 walkPoint;

    private bool bWalkPointSet;

    public float walkPountRange;

    //

    //���� ���� ����

    public float timeBetweenAttacks;

    private bool alreadyAttacked;

    //

    //������ ���� ��Ȳ ����

    public float sightRange;

    public float attackRange;

    public bool bPlayerInSightRange;

    public bool bPlayerInAttackRange;

    //

    public void Damage(float Damage)
    {
        currentHealth -= Damage;

        Debug.Log("���� �Ѿ˿� �°� ���ظ� �Ծ����ϴ�");

        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("���� ����߽��ϴ�.");

        Destroy(this.gameObject);
    }

}
