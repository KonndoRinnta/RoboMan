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

    [SerializeField, Header("ゲームオーバーアニメーションの再生時間")]
    private float _gameOverAnimTime = 0.5f;
    public float GameOverAnimTime => _gameOverAnimTime;

    [SerializeField, Header("ゲームクリアアニメーションの再生時間")]
    private float _gameClearAnimTime = 1.6f;
    public float GameClearAnimTime => _gameClearAnimTime; 

    [SerializeField, Header("立ち攻撃のヒット判定Colliderの親オブジェクト")]
    private GameObject _normalAttackHitBox;

    [SerializeField, Header("歩き攻撃のヒット判定Colliderの親オブジェクト")]
    private GameObject _walkAttackHitBox;

    [SerializeField, Header("空中攻撃のヒット判定Colliderの親オブジェクト")]
    private GameObject _airAttackHitBox;

    [Header("ダメージ判定中かのフラグ")]
    private bool _isDamege = false;
    public bool IsDamege => _isDamege;

    [Header("接地中かのフラグ")] 
    private bool _isGround;
    public bool IsGround => _isGround;

    [Header("ステージクリアの判定")]
    private bool _isGameClear;
    public bool IsGameClear => _isGameClear;

    Vector2 _rayOrigin; // Rayの始点

    Vector2 _rayDirection = Vector2.down; // Rayの方向を指定

    [SerializeField, Header("Rayの長さ")]
    float _rayDistance = 0.1f; // Rayの長さを指定

    private int _layerMask;

    private bool _playerFlip;

    [SerializeField, Header("プレイヤーのAnimator")]
    private Animator _animator;
    public Animator Animator => _animator;

    private GameObject _player;
    public GameObject Player => _player;

    [SerializeField]
    private SpriteRenderer _sR;

    public bool FlipX => _sR.flipX;

    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

    [SerializeField]
    private GameManager _gM;
    public GameManager GM => _gM;

    [SerializeField]
    private PauseManager _pm;

    [SerializeField] private bool _airDashable = true;
    public bool AirDashable => _airDashable;

    [SerializeField]private bool _isInputDisable = false;

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

    private bool _freezePositionFlag = false;
    public bool FreezePositionFlag => _freezePositionFlag;

    private bool _pauseInput;
    public bool PauseInput => _pauseInput;

    [Header("現在の状態")]PlayerState _currentState;
    public IPlayerState CurrentState => _stateData[_currentState];

    PlayerState _beforeState;

    IPlayerState _beforeIstate = null;

    public Dictionary<PlayerState, IPlayerState> _stateData = new Dictionary<PlayerState, IPlayerState>();

    

    private void Awake()
    {
        _hP = _hPMaxValue;
        //_sR = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _player = this.gameObject;
        _layerMask = LayerMask.GetMask("Ground");
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
        _stateData.Add(PlayerState.GameOver, new GameOverState());
        _stateData.Add(PlayerState.GameClear, new GameClearState());
        _stateData.Add(PlayerState.Pause, new PauseState());
        _beforeState = PlayerState.Stop;
        _currentState = PlayerState.Stop;
        ChangeState(PlayerState.Stop);
        _pm.OnPause += PauseSetting;
        _pm.OnResume += ResumeSetting;
        }
    void Update()
    {
        _rayOrigin = transform.position; // Rayの始点を取得
        _isGround = Physics2D.Raycast(_rayOrigin, _rayDirection, _rayDistance, _layerMask);
        Debug.DrawRay(_rayOrigin, _rayDirection * _rayDistance, Color.red);
        OnGround();

        CurrentState.OnUpdate(this);
        Debug.Log(_currentState);
        Debug.Log(MoveInput);
    }
    public void OnGround()
    {
        if (_isGround) Debug.Log("接地");
    }
    public void ChangeState(PlayerState nextState)
    {
        if (_currentState == nextState) return;

        _beforeState = _currentState;

        _beforeIstate = CurrentState;

        _currentState = nextState;

        if(_beforeIstate == _stateData[PlayerState.Pause])
        {
            _beforeIstate?.OnEnd(this);
        }
        CurrentState.OnStart(this);

    }

    //頭にOnとつく関数はUnity上にてInputSystemで使用しているため参照0個で大丈夫
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_isInputDisable)
        {
            _moveInput = context.ReadValue<Vector2>().x;
            if (_moveInput != 0 && !FreezePositionFlag)
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
        if (_isInputDisable) return;
        if (!context.performed) return;
        _attackInput = true;
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        _pm.PauseUpdate(context.performed);
    }
    public void AttackInputDisAble()
    {
        _attackInput = false;
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

    public void AirAttackColliderOn()
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
    public void AirAttackClliderOff()
    {
        _airAttackHitBox.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isDamege)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                _isDamege = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Goal"))
        {
            _isGameClear = true;
        }
    }

    public void IsDamegeDisable()
    {
        _isDamege = false;
    }
    public void Damage()
    {
        _hP--;
    }
    public void InputDisable()
    {
        _isInputDisable = true;
    }
    public void InputAble()
    {
        _isInputDisable = false;
    }
    public void PlayerDisable()
    {
        _player.SetActive(false);
    }
    public void FreezePosition()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        _freezePositionFlag = true;
    }
    public void FreezePositionRemove()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _freezePositionFlag = false;
    }
    private void PauseSetting()
    {
        ChangeState(PlayerState.Pause);
    }
    private void ResumeSetting()
    {
        ChangeState(_beforeState);
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
    Damege,
    GameOver,
    GameClear,
    Pause
}