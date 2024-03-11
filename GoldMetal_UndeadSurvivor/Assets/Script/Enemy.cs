using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    private bool isLive = true;

    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
        {
            return;
        }

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
        {
            return;
        }

        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    /// <summary>
    /// 적군 초기화 메서드
    /// </summary>
    /// <param name="data"></param>
    public void Initialize(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            return;
        }

        // 체력 감소
        health -= collision.GetComponent<Bullet>().damage;

        if (health > 0)
        {

        }
        else
        {
            Dead();
        }
    }

    /// <summary>
    /// 몬스터 사망 시 호출 될 메서드
    /// </summary>
    private void Dead()
    {
        gameObject.SetActive(false);
    }


}