using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour,IDamagable
{
    public GameObject Target;
    public float MoveSpeed;
   

    [Header("Enemy Stats")]
    public int Health;
    public int MaxHealth;
    public int Damage;

    Rigidbody2D rb;
    void Start()
    {
        EnemyManager.instance.AddEnemyToList(this);
        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;

    }
    
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = (Vector2.MoveTowards(transform.position, Target.transform.position, MoveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int Damage)
    {
        if (Health > 0)
        {
            Health -= Damage;
            Debug.Log("enemy taken Damage");
        }
        else if (Health <= 0)
        {
            Debug.Log("enemy died");
            EnemyManager.instance.RemoveEnemyFromList(this);  
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(Damage);
        }

    }
}
