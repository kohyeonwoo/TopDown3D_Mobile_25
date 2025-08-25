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

    protected bool bWalkPointSet;

    public float walkPointRange;

    //

    //���� ���� ����

    public float timeBetweenAttacks;

    protected bool alreadyAttacked;

    //

    //������ ���� ��Ȳ ����

    public float sightRange;

    public float attackRange;

    public bool bPlayerInSightRange;

    public bool bPlayerInAttackRange;

    //

    //�Ѿ� �߻� �κ� 

    public Transform muzzleLocation;

    public GameObject bulletPrefab;

    public List<GameObject> poolObject = new List<GameObject>();

    public int bulletLimit;

    public float bulletSpeed;

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

    public void CreatedPool()
    {
        for (int i = 0; i < bulletLimit; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.SetActive(false);

            poolObject.Add(bullet);
        }
    }

    public GameObject GetPoolObject()
    {

        for (int i = 0; i < poolObject.Count; i++)
        {
            if (!poolObject[i].activeInHierarchy)
            {
                return poolObject[i];
            }
        }

        return null;
    }


    public void Dead()
    {
        Debug.Log("���� ����߽��ϴ�.");

        Destroy(this.gameObject);
    }

}
