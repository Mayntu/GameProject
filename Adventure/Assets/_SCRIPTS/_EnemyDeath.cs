using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyDeath : MonoBehaviour
{
    Animator animator;
    [SerializeField] private int hp;
    private bool isDead = false;
    _PlayerAttack damage = new _PlayerAttack();
    private Vector3 off1;
    private Vector3 off2;
    //[SerializeField] private GameObject[] objects;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Awake()
    {
        off1 = new Vector3(Random.Range(-2, 2), 1);
        off2 = new Vector3(Random.Range(-2, 2), 1);
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
    void FixedUpdate()
    {
        DeathCheck();
    }
    void DeathCheck()
    {
        if(hp <= 0)
        {
            isDead = true;
        }
        if (isDead == true)
        {
            StartCoroutine(DoDeath());
        }
    }
    IEnumerator DoDeath()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Slizen");
        _EnemyMovement script1 = enemy.GetComponent<_EnemyMovement>();
        script1.enabled = false;
        animator.Play("SlizenDeathAnimation");
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
        script1.enabled = true;
        DropGoldCoin();
        DropSilverCoin();
    }
    [SerializeField] private GameObject GoldCoin;
    [SerializeField] private Transform transform1;
    [SerializeField] private GameObject SilverCoin;
    [SerializeField] private Transform transform2;
    [SerializeField] private int minGold, maxGold, minSilver, maxSilver;
    void DropGoldCoin()
    {
        if(isDead == true)
        {
            int countOfCoin = Random.Range(minGold, maxGold);
            for(int i = 0; i < countOfCoin; i++)
            {
                Vector3 position = transform.position;
                GameObject coin = Instantiate(GoldCoin, position + off1, Quaternion.identity);
                coin.SetActive(true);
            }
        }
    }
    void DropSilverCoin()
    {
        if (isDead == true)
        {
            int countOfCoin = Random.Range(minSilver, maxSilver);
            for (int i = 0; i < countOfCoin; i++)
            {
                Vector3 position = transform.position;
                GameObject coin = Instantiate(SilverCoin, position += off2, Quaternion.identity);
                coin.SetActive(true);
            }
        }
    }
    //void IsDead()
    //{

    //    if(isDead == true)
    //    {
    //        Instantiate(objects[1], objects[1].transform.position, Quaternion.identity);
    //    }
    //}
}
