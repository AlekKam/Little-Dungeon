using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] int damage = 5;

    private void Attack()
    {
        GameManager.Instance.ReduceHealth(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("Attack", 0, 1);
            Destroy(this.gameObject);
        }
    }
}
