using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("�v���C���[�̑��x")]
    private float _speed = 5f;
    public float Speed => _speed;

    [SerializeField,Header("�_�b�V���̃p���[")]
    private float _dash = 8f;
    public float Dash => _dash;

    [SerializeField, Header("�W�����v��")]
    private float _jumpPower = 5f;
    public float JumpPower => _jumpPower;

    Vector2 _rayOrigin; // Ray�̎n�_

    Vector2 _rayDirection = Vector2.down; // Ray�̕������w��

    [SerializeField,Header("Ray�̒���")]
    float _rayDistance = 0.1f; // Ray�̒������w��

    [SerializeField] bool _isGround; //�ڒn���Ă��邩�̔���
    public bool IsGround => _isGround;

    private int _layerMask;

    [SerializeField, Header("�v���C���[��Animator")]
    private Animator _animator;
    public Animator Animator => _animator;

    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

    private float _moveInput;
    public float MoveInput => _moveInput;

    private bool _jumpInput;
    public bool JumpInput => _jumpInput;

    private bool _dashInput;
    public bool DashInput => _dashInput;

    private bool _crouchingInput;
    public bool CrouchingInput => _crouchingInput;

    PlayerState _currentState;
    public IPlayerState CurrentState => _stateData[_currentState]; 

    public Dictionary<PlayerState, IPlayerState> _stateData = new Dictionary<PlayerState, IPlayerState>();

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Ground");
        _rb = GetComponent<Rigidbody2D>();
        _currentState = PlayerState.None;
        _stateData.Add(PlayerState.Stop,new StopState());
        _stateData.Add(PlayerState.Walk,new WalkState());
        _stateData.Add(PlayerState.Jump,new JumpState());
        _stateData.Add(PlayerState.Air,new AirState());
        _stateData.Add(PlayerState.Dash,new DashState());
        _stateData.Add(PlayerState.Crouching,new CrouchingState());
        _stateData.Add(PlayerState.Sliding,new SlidingState());
        _stateData.Add(PlayerState.NormalAttack,new NormalAttackState());
        _stateData.Add(PlayerState.AirAttack,new AirAttackState());
        _stateData.Add(PlayerState.ChargeAttack,new ChargeAttackState());
        ChangeState(PlayerState.Stop);
    }
    void Update()
    {
        _rayOrigin = transform.position; // Ray�̎n�_���擾
        _isGround = Physics2D.Raycast(_rayOrigin, _rayDirection, _rayDistance, _layerMask);
        Debug.DrawRay(_rayOrigin, _rayDirection * _rayDistance, Color.red);

        CurrentState.OnUpdate(this);
        Debug.Log(_currentState);
    }
    public void ChangeState(PlayerState nextState)
    {
        if(_currentState == nextState) return;

        _currentState = nextState;

        CurrentState.OnStart(this);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>().x;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        _jumpInput = context.ReadValue<bool>();
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        _dashInput = context.ReadValue<bool>();
    }
    public void OnCrouching(InputAction.CallbackContext context)
    {
        _crouchingInput = context.ReadValue<bool>();
    }
}
public enum PlayerState
{
    None,
    Stop,
    Walk,
    Jump,
    Air,
    Dash,
    Crouching,
    Sliding,
    NormalAttack,
    AirAttack,
    ChargeAttack
}