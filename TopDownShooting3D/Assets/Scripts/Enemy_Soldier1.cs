using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Soldier1 : Enemy
{

    private Rigidbody rigid;

    private Animator animator;

    private NavMeshAgent nav;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        maxHealth = 5.0f;

        currentHealth = maxHealth;

        CreatedPool();
    }

    private void Update()
    {
        //���� �þ߿� ���� ���� Ȯ�� 

        bPlayerInSightRange = Physics.CheckSphere(this.transform.position, sightRange, player);
        bPlayerInAttackRange = Physics.CheckSphere(this.transform.position, attackRange, player);

        //���� ��Ȳ�� ���� ���� ���� 

        if(!bPlayerInSightRange && !bPlayerInAttackRange)
        {
            Patroling();
        }

        if (bPlayerInSightRange && !bPlayerInAttackRange)
        {
            Chase();
        }

        if (bPlayerInSightRange && bPlayerInAttackRange)
        {
            Attack();
        }

    }

    private void Patroling()
    {
        if(!bWalkPointSet)
        {
            SearchWalkPoint();
        }

        if(bWalkPointSet)
        {
            nav.SetDestination(walkPoint);

            animator.SetBool("bMove", bWalkPointSet);
        }

        Vector3 distanceToWalkPoint = this.transform.position - walkPoint;

        //�ش� WalkPoint�� ������ ���

        if(distanceToWalkPoint.magnitude < 1.0f)
        {
            bWalkPointSet = false;

            animator.SetBool("bMove", bWalkPointSet);
        }
    }

    private void SearchWalkPoint()
    {
        //���� ������ ������ ���� ��� 

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(this.transform.position.x + randomX, 
            this.transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -this.transform.up, 2.0f, ground))
        {
            bWalkPointSet = true;

            animator.SetBool("bMove", bWalkPointSet);
        }
    }

    private void Chase()
    {
        nav.SetDestination(target.position);

        animator.SetBool("bMove", true);
    }

    private void Attack()
    {
        //���ݵ��� �������� �ʵ��� ������Ű�� �κ� 
        nav.SetDestination(this.transform.position);

        animator.SetBool("bMove", false);

        this.transform.LookAt(target);

        if(!alreadyAttacked)
        {
            Debug.Log("������ ���� �����ϴ�");

            GameObject bullets = GetPoolObject();

            if (bullets != null)
            {
                SoundManager.Instance.PlaySFX("RifleShot");
                bullets.transform.position = muzzleLocation.position;
                bullets.gameObject.SetActive(true);
                bullets.GetComponent<Rigidbody>().velocity = muzzleLocation.transform.forward * bulletSpeed;
            }

            alreadyAttacked = true;

            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;

        animator.SetBool("bMove", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);
    }

}
