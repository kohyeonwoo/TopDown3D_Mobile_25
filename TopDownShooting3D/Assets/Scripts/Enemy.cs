using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public float maxHealth;
   
    public float currentHealth;


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
