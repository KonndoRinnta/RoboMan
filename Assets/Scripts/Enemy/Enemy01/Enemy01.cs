using UnityEngine;

public class Enemy01 : EnemyBase
{
    [SerializeField, Header("‘¬“x")]
    private float _moveSpeed = 5f;

    [SerializeField]
    private Move _moveDirection = Move.Ible;

    [SerializeField]
    protected RightWallHit _rH;

    [SerializeField]
    protected LeftWallHit _lH;



    protected override void OnEnable()
    {
        base.OnEnable();
        _enemyAnimator.Play("enemy01_normal");
    }

    void Start()
    {
        _enemyAnimator.Play("enemy01_normal");
    }

    protected override void Update()
    {
        base.Update();
        EnemyMove();
        EnumChange();
    }

    protected override void Damage()
    {
        base.Damage();
    }

    private void EnemyMove()
    {
        if (_moveDirection == Move.Left)
        {
            _rB.velocity = new Vector2(-_moveSpeed, _rB.velocity.y);
        }
        if (_moveDirection == Move.Right)
        {
            _rB.velocity = new Vector2(_moveSpeed, _rB.velocity.y);
        }
    }

    public void EnumChange()
    {
        if (_lH.LeftHit)
        {
            _moveDirection = Move.Right;
            _sR.flipX = true;
            _lH.LeftHitDisable();
        }
        if (_rH.RightHit)
        {
            _moveDirection = Move.Left;
            _sR.flipX = false;
            _rH.RightHitDisable();
        }
    }

    enum Move
    {
        Ible,
        Left,
        Right
    }
}
