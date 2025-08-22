using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private FixedJoystick joystick;

    [SerializeField]
    private Animator animator;

    public Transform muzzleLocation;

    public GameObject bulletPrefab;

    public List<GameObject> poolObject = new List<GameObject>();

    [SerializeField]
    private float moveSpeed;

    public float bulletSpeed;

    public int bulletLimit;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        CreatedPool();
    }

    private void FixedUpdate()
    {

        rigid.velocity = new Vector3(joystick.Horizontal * moveSpeed,
            rigid.velocity.y, joystick.Vertical * moveSpeed);

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            this.transform.rotation = Quaternion.LookRotation(rigid.velocity);

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }

    public void Shoot()
    {
        Debug.Log("플레이어 사격!!!!!!");

        animator.SetBool("isShooting", true);

        // GameObject bullets = Instantiate(bulletPrefab, muzzleLocation.position, muzzleLocation.rotation);
        GameObject bullets = GetPoolObject();

        if(bullets != null)
        {
            bullets.transform.position = muzzleLocation.position;
            bullets.gameObject.SetActive(true);
            bullets.GetComponent<Rigidbody>().velocity = muzzleLocation.transform.forward * bulletSpeed;
        }

       
    }

    public void ShootEnd()
    {
        animator.SetBool("isShooting", false);
    }

    public void Damage(float Damage)
    {
       
    }

    private void CreatedPool()
    {
        for(int i =0; i < bulletLimit; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.SetActive(false);

            poolObject.Add(bullet);
        }
    }

    public GameObject GetPoolObject()
    {

        for(int i =0; i < poolObject.Count; i++)
        {
            if (!poolObject[i].activeInHierarchy)
            {
                return poolObject[i];
            }
        }

        return null;
    }

}
