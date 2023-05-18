using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField,Header("ìGÇÃëÃóÕ")]
    protected float _enemyHp;

    [SerializeField, Header("ìGÇÃçUåÇóÕ")]
    protected int _enemyAtk;

    private PlayerController playerController;

    private void Update()
    {
        Death();
    }
    void OnBecameVisible()
    {
        this.gameObject.SetActive(true);
    }
    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAtk")
        {
            Damage();
        }
    }

    public void Damage()
    {
        _enemyHp -= playerController.Attack;
    }
    public void Death()
    {
        if(_enemyHp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
