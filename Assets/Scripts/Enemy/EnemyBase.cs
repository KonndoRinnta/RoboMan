using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("�G�̗̑�")]
    protected float _enemyHp = 2;

    [SerializeField, Header("���G����")]
    private float _damageInvisibleTime = 3f;

    [SerializeField]
    protected AnimationNames _animNames;

    protected SpriteRenderer _sR;

    protected Rigidbody2D _rB;

    private PlayerController _pC;

    protected Animator _enemyAnimator;

    private bool _damegeFlag;

    protected virtual void OnEnable()
    {
        _sR ??= GetComponent<SpriteRenderer>();
        _rB ??= GetComponent<Rigidbody2D>();
        _pC ??= GetComponent<PlayerController>();
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

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(_damageInvisibleTime);
    }

    protected virtual void Damage()
    {
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

    [SerializeField, Header("�ʏ펞�̃A�j���[�V�����̖��O")]
    protected string _normalAnimName;

    [SerializeField, Header("�_���[�W���󂯂��Ƃ��̃A�j���[�V�������O")]
    protected string _damegeAnimnName;
}
