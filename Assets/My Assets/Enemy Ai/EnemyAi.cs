using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public GameObject Target;
    public float MoveSpeed;
    public int Damage;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FollowTarget()
    {
         transform.position =(Vector3.MoveTowards(transform.position, Target.transform.position, MoveSpeed * Time.deltaTime));
    }
    
    void Update()
    {
        FollowTarget();
    }
}
