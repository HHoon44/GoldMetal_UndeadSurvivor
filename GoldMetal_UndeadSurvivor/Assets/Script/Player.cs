using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    private Rigidbody2D rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

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

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}