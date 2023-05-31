using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの速度")]
    private float _speed = 5f;
    public float Speed => _speed;

    [SerializeField, Header("ダッシュのパワー")]
    private float _dashPower = 8f;
    public float DashPower => _dashPower;

    [SerializeField, Header("ダッシュ時間")]
    private float _dashTime = 0.2f;
    public float DashTime => _dashTime;

    [SerializeField, Header("ジャンプ力")]
    private float _jumpPower = 5f;
    public float JumpPower => _jumpPower;

    [SerializeField, Header("プレイヤーの体力")]
    private float _hP = 20f;
    public float HP => _hP;

    [SerializeField, Header("プレイヤーの体力の最大値")]
    private float _hPMaxValue;
    public float HPMaxValue => _hPMaxValue;

    [SerializeField, Header("攻撃時の硬直時間")]
    private float _attackTime = 0.2f;
    public float AttackTime => _attackTime;

    [SerializeField, Header("ダメージヒット時の無敵時間")]
    private float _damageInvincibleTime = 1f;
    public float DamageInvincibleTime => _damageInvincibleTime;

    [SerializeField, Header("立ち攻撃のヒット判定Colliderの親オブジェクト")]
    private GameObject _normalAttackHitBox;

    [SerializeField, Header("歩き攻撃のヒット判定Colliderの親オブジェクト")]
    private GameObject _walkAttackHitBox;

    [SerializeField, Header("空中攻撃のヒット判定Colliderの親オブジェクト")]
    private GameObject _airAttackHitBox;

    [Header("ダメージ判定中かのフラグ")]
    private bool _isDamege = false;

    public bool IsDamege => _isDamege;

    Vector2 _rayOrigin; // Rayの始点

    Vector2 _rayDirection = Vector2.down; // Rayの方向を指定

    [SerializeField, Header("Rayの長さ")]
    float _rayDistance = 0.1f; // Rayの長さを指定

    [SerializeField] bool _isGround;
    public bool IsGround => _isGround;

    private int _layerMask;

    private bool _playerFlip;

    [SerializeField, Header("プレイヤーのAnimator")]
    private Animator _animator;
    public Animator Animator => _animator;

    private SpriteRenderer _sR;

    public bool FlipX => _sR.flipX;

    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

    [SerializeField] private bool _airDashable = true;
    public bool AirDashable => _airDashable;

    private bool _isInputDisable = false;

    private float _moveInput;
    public float MoveInput => _moveInput;

    private bool _jumpInput;
    public bool JumpInput => _jumpInput;

    private bool _dashInput;
    public bool DashInput => _dashInput;

    private bool _crouchingInput;
    public bool CrouchingInput => _crouchingInput;

    private bool _slidingInput;
    public bool SlidingInput => _slidingInput;

    private bool _attackInput;
    public bool AttackInput => _attackInput;

    PlayerState _currentState;
    public IPlayerState CurrentState => _stateData[_currentState];

    public Dictionary<PlayerState, IPlayerState> _stateData = new Dictionary<PlayerState, IPlayerState>();

    private void Awake()
    {
        _hP = _hPMaxValue;
        _sR = GetComponent<SpriteRenderer>();
        _layerMask = LayerMask.GetMask("Ground");
        _rb = GetComponent<Rigidbody2D>();
        _currentState = PlayerState.None;
        _stateData.Add(PlayerState.Stop, new StopState());
        _stateData.Add(PlayerState.Walk, new WalkState());
        _stateData.Add(PlayerState.Jump, new JumpState());
        _stateData.Add(PlayerState.Air, new AirState());
        _stateData.Add(PlayerState.AirWalk, new AirWalkState());
        _stateData.Add(PlayerState.Dash, new DashState());
        _stateData.Add(PlayerState.Crouching, new CrouchingState());
        _stateData.Add(PlayerState.Sliding, new SlidingState());
        _stateData.Add(PlayerState.NormalAttack, new NormalAttackState());
        _stateData.Add(PlayerState.WalkAttack, new WalkAtkState());
        _stateData.Add(PlayerState.AirAttack, new AirAttackState());
        _stateData.Add(PlayerState.ChargeAttack, new ChargeAttackState());
        _stateData.Add(PlayerState.Damege, new DamageState());
        ChangeState(PlayerState.Stop);
    }
    void Update()
    {
        _rayOrigin = transform.position; // Rayの始点を取得
        _isGround = Physics2D.Raycast(_rayOrigin, _rayDirection, _rayDistance, _layerMask);
        Debug.DrawRay(_rayOrigin, _rayDirection * _rayDistance, Color.red);

        CurrentState.OnUpdate(this);
        Debug.Log(_currentState);
    }
    public void ChangeState(PlayerState nextState)
    {
        if (_currentState == nextState) return;

        _currentState = nextState;

        CurrentState.OnStart(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_isInputDisable)
        {
            _moveInput = context.ReadValue<Vector2>().x;
            if (_moveInput != 0)
            {
                _sR.flipX = _moveInput < 0 ? true : false;
                if (_sR.flipX == true) _normalAttackHitBox.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else _moveInput = 0f;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!_isInputDisable) _jumpInput = context.ReadValueAsButton();
        else _jumpInput = false;
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (!_isInputDisable) _dashInput = context.ReadValueAsButton();
        else _dashInput = false;
    }
    public void OnCrouching(InputAction.CallbackContext context)
    {
        if (_isInputDisable) return;
        _crouchingInput = context.ReadValueAsButton();
    }
    public void OnSliding(InputAction.CallbackContext context)
    {
        if (!_isInputDisable) _slidingInput = context.ReadValueAsButton();
        else _slidingInput = false;
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!_isInputDisable) _attackInput = context.ReadValueAsButton();
        else _attackInput = false;
    }
    public void DashChecker()
    {
        _dashInput = false;
    }
    public void AirDashChecker()
    {
        _airDashable = false;
    }
    public void AirDashRemove()
    {
        _airDashable = true;
    }
    public void SlidingChecker()
    {
        _slidingInput = false;
    }
    public void NormalAttackCheckOn()
    {
        if (FlipX)
        {
            _normalAttackHitBox.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        else
        {
            _normalAttackHitBox.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        _normalAttackHitBox.SetActive(true);
    }
    public void NormalAttackCheckOff()
    {
        _normalAttackHitBox.SetActive(false);
    }
    public void WalkAttackCheckOn()
    {
        if (FlipX)
        {
            _walkAttackHitBox.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        else
        {
            _walkAttackHitBox.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        _walkAttackHitBox.SetActive(true);
    }
    public void WalkAttackCheckOff()
    {
        _walkAttackHitBox.SetActive(false);
    }

    public void AirAttackCheckOn()
    {
        if (FlipX)
        {
            _airAttackHitBox.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        else
        {
            _airAttackHitBox.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        _airAttackHitBox.SetActive(true);
    }
    public void AirAttackCheckOff()
    {
        _airAttackHitBox.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isDamege)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("ヒット");
                _isDamege = true;
            }
        }
    }

    public void IsDamegeDisable()
    {
        _isDamege = false;
    }

    public void InputDisable()
    {
        _isInputDisable = true;
    }
    public void Damage()
    {
        _hP--;
    }
    public void InputAble()
    {
        _isInputDisable = false;
        Debug.Log("S");
    }
}
public enum PlayerState
{
    None,
    Stop,
    Walk,
    Jump,
    Air,
    AirWalk,
    Dash,
    Crouching,
    Sliding,
    NormalAttack,
    WalkAttack,
    AirAttack,
    ChargeAttack,
    Damege
}