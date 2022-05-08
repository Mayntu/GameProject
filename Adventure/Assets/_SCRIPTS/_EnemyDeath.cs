using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyDeath : MonoBehaviour
{
    Animator animator;
    [SerializeField] int hp;
    private bool isDead = false;
    _PlayerAttack damage = new _PlayerAttack();
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AttackHitBox")
        {
            animator.Play("SlizenDamaged");
            Debug.Log(damage.PlayerDamage);
            hp -= damage.PlayerDamage;
          
        }
    }
    void Update()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
        if (isDead == true)
        {
            Destroy(gameObject);
        }
    }
    //void IsDead()
    //{

    //    if(isDead == true)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
