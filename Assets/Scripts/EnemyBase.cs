using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField,Header("�G�̗̑�")]
    protected int _enemyHp;

    [SerializeField, Header("�G�̍U����")]
    protected int _enemyAtk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Damage();
        }
    }

    public void Damage()
    {
        _enemyHp--;
    }
}
