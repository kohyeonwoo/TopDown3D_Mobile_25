using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private FixedJoystick joystick;

    [SerializeField]
    private GameObject shootButton;

    [SerializeField]
    private Animator animator;

    public Transform muzzleLocation;

    public GameObject bulletPrefab;

    public List<GameObject> poolObject = new List<GameObject>();

    [SerializeField]
    private float moveSpeed;

    public float bulletSpeed;

    public int bulletLimit;

    public int currentAmmo;

    public int ammoLimit;

    public TextMeshProUGUI currentBulletText;

    public TextMeshProUGUI maxBulletText;

    public float maxHealth;

    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        rigid = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        currentAmmo = ammoLimit;

        CreatedPool();
    }

    private void Update()
    {
        currentBulletText.text = currentAmmo.ToString();

        maxBulletText.text = bulletLimit.ToString();
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

        if(bullets != null && currentAmmo > 0)
        {
            currentAmmo--;
            SoundManager.Instance.PlaySFX("RifleShot");
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
        currentHealth -= Damage;

        if(currentHealth <= 0)
        {
            Dead();
        }

    }

    public void Dead()
    {
        animator.SetTrigger("Dead");

        joystick.gameObject.SetActive(false);

        shootButton.SetActive(false);

        Destroy(this.gameObject, 2.0f);

        Invoke("ActiveEndGamePanel", 1.9f);
    }

    public void ActiveEndGamePanel()
    {
        GameManager.Instance.endGamePanel.SetActive(true);
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
