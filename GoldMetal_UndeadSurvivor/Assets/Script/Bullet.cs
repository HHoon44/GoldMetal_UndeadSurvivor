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
    /// ���� �ʱ�ȭ �޼���
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="per"></param>
    public void Initialize(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        // -1���� ũ�� ���Ÿ� ����
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