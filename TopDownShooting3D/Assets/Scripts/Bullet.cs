using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { None, Pistol, Rifle}

public class Bullet : MonoBehaviour
{

    public WeaponType weaponTypes;

    [SerializeField]
    private float attackPoint;

    private void Start()
    {
       if(weaponTypes == WeaponType.Pistol)
       {
            attackPoint = 5.0f;
       }

       if(weaponTypes == WeaponType.Rifle)
       {
            attackPoint = 10.0f;
       }

        Invoke("DestroyBullet", 2.0f);
    }

    private void DestroyBullet()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(attackPoint);

                this.gameObject.SetActive(false);

                Debug.Log("적에게 총알이 명중했습니다!!!");
            }

        }
    }

}
