using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("プレイヤーの速度")]
    private float _speed = 5f;
    public float Speed => _speed;

    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;

    PlayerState _currentState;
    public IPlayerState CurrentState => _stateData[_currentState]; 

    public Dictionary<PlayerState, IPlayerState> _stateData = new Dictionary<PlayerState, IPlayerState>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentState = PlayerState.Stop;
        _stateData.Add(PlayerState.Stop,new StopState());
        _stateData.Add(PlayerState.Walk,new WalkState());
    }
    void Update()
    {
        CurrentState.OnUpdate(this);
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
}