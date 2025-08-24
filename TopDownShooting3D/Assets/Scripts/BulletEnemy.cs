using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField]
    private float attackPoint;

    private void Start()
    {
        Invoke("DestroyBullet", 2.0f);
    }

    private void DestroyBullet()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(attackPoint);

                this.gameObject.SetActive(false);

                Debug.Log("플레이어가 적의 총알에 맞았습니다!!!");
            }

        }
    }
}
