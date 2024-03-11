using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator anim;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    /*
        // 1. ���� �ش�
        rigid.AddForce(inputVec);

        // 2. �ӵ� ����
        rigid.velocity = inputVec;
    */
    private void FixedUpdate()
    {
        // �밢�� �̵� ��, �� ū ������ �̵��ϱ� ������ ����ȭ�� ������Ѵ�
        // fixedDeltaTime�� ���� ������ �ϳ��� �Һ��� �ð��̴�
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        // ��ġ �̵�
        // ��ġ �̵��̶� ���� ��ġ�� ������� �Ѵ�
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        // �¿� ����
        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0 ? true : false;
        }
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}