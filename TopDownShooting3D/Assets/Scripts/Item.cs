using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { None, HealthPack, AmmoPack}

public class Item : MonoBehaviour
{

    public ItemType itemType;

    public float healthPoint;

    public int ammoCount;

    private void Start()
    {
        int healthRand = Random.Range(1, 6);

        int ammoRand = Random.Range(1, 6);

        int rand = Random.Range(0, 2);

        if(rand == 0)
        {
            itemType = ItemType.HealthPack;
        }

        if (rand == 1)
        {
            itemType = ItemType.AmmoPack;
        }

        healthPoint = healthRand;

        ammoCount = ammoRand;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {

            Player player = collision.gameObject.GetComponent<Player>();

            if (itemType == ItemType.AmmoPack)
            {
                player.currentAmmo += ammoCount;
            }

            this.gameObject.SetActive(false);
        }
    }

}
