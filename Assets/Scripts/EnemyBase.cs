using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField,Header("ìGÇÃëÃóÕ")]
    protected float _enemyHp = 2;

    [SerializeField, Header("ìGÇÃçUåÇóÕ")]
    protected int _enemyAtk;

    protected SpriteRenderer _sR;

    protected Rigidbody2D _rB;

    private PlayerController _pC;

    protected Animator _enemyAnimator;

    protected virtual void OnEnable()
    {
        _sR ??= GetComponent<SpriteRenderer>();
        _rB ??= GetComponent<Rigidbody2D>();
        _pC ??= GetComponent<PlayerController>();
        _enemyAnimator ??= GetComponent<Animator>();
    }

    private void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAtk")
        {
            Damage();
        }
    }

    protected virtual void Damage()
    {
        Debug.Log("a");
        _enemyHp--;
    }
    public void Death()
    {
        
        if(_enemyHp <= 0)
        {
            Debug.Log("d");
            this.gameObject.SetActive(false);
        }
    }
}
