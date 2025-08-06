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

    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();    
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
    }

    public void ShootEnd()
    {
        animator.SetBool("isShooting", false);
    }

    public void Damage()
    {
       
    }

}
