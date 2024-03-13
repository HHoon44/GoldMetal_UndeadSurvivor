using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    private Rigidbody2D rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 무기 초기화 메서드
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="per"></param>
    public void Initialize(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        // -1보다 크면 원거리 공격
        if (per > -1)
        {
            rigid.velocity = dir * 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1)
        {
            return;
        }

        per--;

        if (per == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}