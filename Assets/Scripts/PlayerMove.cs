using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーの速度")]
    float speed = 5f;

    void Update()
    {
        Move();
    }
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
