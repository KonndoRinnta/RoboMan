using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("敵の体力")]
    protected float _enemyHp = 2;

    [SerializeField, Header("無敵時間")]
    private float _damageInvisibleTime = 3f;

    [SerializeField, Header("ダメージ音")]
    private AudioClip _damageSound;

    [SerializeField]
    protected AnimationNames _animNames;

    protected SpriteRenderer _sR;

    protected Rigidbody2D _rB;

    private PlayerController _pC;
    
    private AudioSource _aS;

    protected Animator _enemyAnimator;

    private bool _damegeFlag;

    protected bool _isMove = false;

    protected virtual void OnEnable()
    {
        _sR ??= GetComponent<SpriteRenderer>();
        _rB ??= GetComponent<Rigidbody2D>();
        _pC ??= GetComponent<PlayerController>();
        _aS ??= GetComponent<AudioSource>();
        _enemyAnimator ??= GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAtk"))
        {
            Damage();
        }
    }
    private void OnWillRenderObject()
    {
        _isMove = true;
    }

    private void OnBecameInvisible()
    {
        _isMove = false;
    }

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(_damageInvisibleTime);
    }

    protected virtual void Damage()
    {
        _aS.PlayOneShot(_damageSound);

        Debug.Log("a");
        if (!_damegeFlag)
        {
            _damegeFlag = true;
            _enemyAnimator.Play(_animNames.DamegeAnimName);
            _enemyHp--;
            StartCoroutine(Execute());
            _damegeFlag = false;
        }
    }

    public void StopDamegeAnimation()
    {
        _enemyAnimator.Play(_animNames.NormalAnimName);
    }

    public void Death()
    {
        if (_enemyHp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
[System.Serializable]
public class AnimationNames
{
    public string NormalAnimName => _normalAnimName;

    public string DamegeAnimName => _damegeAnimnName;

    [SerializeField, Header("通常時のアニメーションの名前")]
    protected string _normalAnimName;

    [SerializeField, Header("ダメージを受けたときのアニメーション名前")]
    protected string _damegeAnimnName;
}
