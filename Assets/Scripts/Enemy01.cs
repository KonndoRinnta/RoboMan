using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : EnemyBase
{
    [SerializeField, Header("���x")]
    float _moveSpeed =  5f;

    Vector2 _rayOrigin; // Ray�̎n�_

    Vector2 _rayDirection = Vector2.left; // Ray�̕������w��

    [SerializeField, Header("Ray�̒���")]
    float _rayDistance = 0.1f; // Ray�̒������w��ss

    [SerializeField]
    Move _moveDirection = Move.Ible;

    protected override void OnEnable()
    {
        base.OnEnable();
        _enemyAnimator.Play("enemy01_normal");
        if (_moveDirection == Move.Left)
        {
            _sR.flipX = false;
        }
        else if (_moveDirection == Move.Right)
        {
            _sR.flipX = true;
        }

    }

    void Start()
    {
        _enemyAnimator.Play("enemy01_normal");
    }

    protected override void Update()
    {
        base.Update();
        EnemyMove();
    }   

    protected override void Damage()
    {
        
        base.Damage();
    }

    private void EnemyMove()
    {
        if(_moveDirection == Move.Left)
        {
            _rB.velocity = new Vector2(-_moveSpeed, 0);
        }
        if(_moveDirection == Move.Right)
        {
            _rB.velocity = new Vector2(_moveSpeed, 0);
        }
    }

    enum Move
    {
        Ible,
        Left,
        Right
    }
}
