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
    }

    private void Start()
    {
        maxHealth = 5.0f;

        currentHealth = maxHealth;
    }

}
