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
        //적의 시야와 공격 범위 확인 

        bPlayerInSightRange = Physics.CheckSphere(this.transform.position, sightRange, player);
        bPlayerInAttackRange = Physics.CheckSphere(this.transform.position, attackRange, player);

        //각각 상황에 따른 조건 설정 

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

        //해당 WalkPoint에 도달한 경우

        if(distanceToWalkPoint.magnitude < 1.0f)
        {
            bWalkPointSet = false;

            animator.SetBool("bMove", bWalkPointSet);
        }
    }

    private void SearchWalkPoint()
    {
        //범위 내에서 무작위 지점 계산 

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
        //공격동안 움직이지 않도록 고정시키는 부분 
        nav.SetDestination(this.transform.position);

        animator.SetBool("bMove", false);

        this.transform.LookAt(target);

        if(!alreadyAttacked)
        {
            Debug.Log("적군이 총을 쐈습니다");

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
