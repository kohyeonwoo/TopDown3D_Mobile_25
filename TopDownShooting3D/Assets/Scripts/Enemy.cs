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
