using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Gun : MonoBehaviour
{
    [SerializeField]
    private float delay;
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private LayerTag enemyTag = LayerTag.Enemy;

    private float currentDelay;
    private List<Transform> enemies = new List<Transform>();

    private const InventoryObjectTag ammoTag = InventoryObjectTag.Ammo;

    private void Update()
    {
        UpdateTimers();
        MuzzleLook();
    }

    public bool MuzzleLook()
    {
        if (enemies.Count != 0)
        {
            var vetorLook = (enemies[0].position - muzzle.position).normalized;
            muzzle.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(vetorLook.y, vetorLook.x) * Mathf.Rad2Deg);
            return true;
        }

        return false;
    }

    public void CheckShoot()
    {
        if (currentDelay == 0f && MuzzleLook())
        {
            Shoot();
        }
    }

    private void UpdateTimers()
    {
        currentDelay = Mathf.Max(0f, currentDelay - Time.deltaTime);
    }

    private void Shoot()
    {
        if (Inventory.Instance.CheckAndDecreaseObject(ammoTag))
        {
            Instantiate(bullet, muzzle.position, muzzle.rotation).Instantiate(enemyTag);
            currentDelay = delay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerController.Instance.GetNameLayer(enemyTag)))
        {
            enemies.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(LayerController.Instance.GetNameLayer(enemyTag)))
        {
            enemies.Remove(collision.transform);
        }
    }
}
