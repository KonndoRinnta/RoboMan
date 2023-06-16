using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    [SerializeField]
    private float _fallCount;

    private Collider2D _collider;

    private Animator _anim;

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(_fallCount);
        this._collider.enabled = false;
    }
    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _anim.Play("fall_ground");
            StartCoroutine(Execute());
        }
    }
}