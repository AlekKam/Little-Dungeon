using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] GameObject projectile;
    [SerializeField] float attackInterval = 0.5f;
    public FloatVariable MaxHP, Damage, AtkSpd, Move;

    Rigidbody2D rb;
    float attackTimer = 0;
    public TextMeshProUGUI text;
    public float MaximumHp;
    public float Hp;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        v.Normalize();
        v *= speed;
        rb.velocity = v;
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);

        if (attackTimer <= 0)
        {
            Attack();
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SpawnProjectile(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            SpawnProjectile(Vector2.down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            SpawnProjectile(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            SpawnProjectile(Vector2.right);
        }
    }

    private void SpawnProjectile(Vector2 direction)
    {
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
        instance.GetComponent<ProjectileController>().SetVelocity(direction);
        attackTimer = attackInterval;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            GameManager.Instance.addGems(1);
            Destroy(collision.gameObject);
        }
    }

    private void OnGUI()
    {
        text.text = "Gems: " + Gem.Gems;
    }

    public void FinalizeShop()
    {
        MaximumHp = MaxHP.Value;
        Hp = MaximumHp;
        animator.SetFloat("AttackSpeed", 1 + AtkSpd.Value);
    }
}
