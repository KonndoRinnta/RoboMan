using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField,Header("敵の体力")]
    protected float _enemyHp = 2;

    [SerializeField, Header("敵の攻撃力")]
    protected int _enemyAtk;

    [SerializeField]
    protected AnimationNames _animNames;

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

    protected virtual void Update()
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
        _enemyAnimator.Play(_animNames.DamegeAnimName);
        _enemyHp--;
    }

    public void StopDamegeAnimation()
    {
        _enemyAnimator.Play(_animNames.NormalAnimName);
    }

    public void Death()
    {
        if(_enemyHp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
[System.Serializable]
public class AnimationNames
{
    public string NormalAnimName => _normalAnimName;

    public string DamegeAnimName => _damegeAnimnName;

    [SerializeField, Header("通常時のアニメーションの名前")]
    protected string _normalAnimName;

    [SerializeField, Header("ダメージを受けたときのアニメーション名前")]
    protected string _damegeAnimnName;
}
