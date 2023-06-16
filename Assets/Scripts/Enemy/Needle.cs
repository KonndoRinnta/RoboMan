using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    [SerializeField]
    PlayerController _pC;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("HitNeedle");
            _pC.ChangeState(PlayerState.GameOver);
        }
    }
}
