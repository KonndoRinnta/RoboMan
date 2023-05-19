using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : EnemyBase
{
    [SerializeField, Header("速度")]
    float _moveSpeed =  5f;

    Vector2 _rayOrigin; // Rayの始点

    Vector2 _rayDirection = Vector2.left; // Rayの方向を指定

    [SerializeField, Header("Rayの長さ")]
    float _rayDistance = 0.1f; // Rayの長さを指定ss

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
