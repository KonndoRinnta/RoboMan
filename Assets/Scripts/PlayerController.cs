using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

     // �ڒn������s�����C���[���w��

    [SerializeField] bool _isGround; //�ڒn���Ă��邩�̔���
    public bool IsGround => _isGround;

    private int _layerMask;

    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

    PlayerState _currentState;
    public IPlayerState CurrentState => _stateData[_currentState]; 

    public Dictionary<PlayerState, IPlayerState> _stateData = new Dictionary<PlayerState, IPlayerState>();

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Ground");
        _rb = GetComponent<Rigidbody2D>();
        _currentState = PlayerState.Stop;
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
        if (_currentState == nextState) return;

        _currentState = nextState;
    }
}
public enum PlayerState
{
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