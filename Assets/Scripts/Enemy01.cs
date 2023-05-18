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
    float _rayDistance = 0.1f; // Ray�̒������w��

    Transform _myTransform = default;

    SpriteRenderer _sr;

    [SerializeField]
    Move _move = Move.Ible;

    private void OnEnable()
    {
        _sr = GetComponent<SpriteRenderer>();
        _myTransform = this.transform;
        if (_move == Move.Left)
        {
            _sr.flipX = false;
        }
        else if (_move == Move.Right)
        {
            _sr.flipX = true;
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        EnemyMove();
    }   
    private void EnemyMove()
    {
        
    }

    enum Move
    {
        Ible,
        Left,
        Right
    }
}
