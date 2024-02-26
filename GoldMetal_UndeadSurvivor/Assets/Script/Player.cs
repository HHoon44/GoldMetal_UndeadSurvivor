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
        // 1. 힘을 준다
        rigid.AddForce(inputVec);

        // 2. 속도 제어
        rigid.velocity = inputVec;
    */
    private void FixedUpdate()
    {
        // 대각선 이동 시, 더 큰 값으로 이동하기 때문에 정규화를 해줘야한다
        // fixedDeltaTime은 물리 프레임 하나가 소비한 시간이다
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        // 위치 이동
        // 위치 이동이라 현재 위치를 더해줘야 한다
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}