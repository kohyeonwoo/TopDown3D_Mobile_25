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
    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
