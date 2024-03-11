using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        // 1. 캐스팅 시작 위치
        // 2. 원으 반지름
        // 3. 캐스팅 방향
        // 4. 캐스팅 길이
        // 5. 대상 레이어
        targets = Physics2D.CircleCastAll
            (transform.position, scanRange, Vector2.zero, 0, targetLayer);

        nearestTarget = GetNearest();
    }

    /// <summary>
    /// 플레이어와 가장 가까운 적을 탐지하는 메서드
    /// </summary>
    /// <returns></returns>
    private Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;

            // 플레이어와 현재 적의 사이 거리를 구하는 작업
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                // 결과값 업데이트 작업
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
}