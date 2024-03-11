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
        // 1. ĳ���� ���� ��ġ
        // 2. ���� ������
        // 3. ĳ���� ����
        // 4. ĳ���� ����
        // 5. ��� ���̾�
        targets = Physics2D.CircleCastAll
            (transform.position, scanRange, Vector2.zero, 0, targetLayer);

        nearestTarget = GetNearest();
    }

    /// <summary>
    /// �÷��̾�� ���� ����� ���� Ž���ϴ� �޼���
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

            // �÷��̾�� ���� ���� ���� �Ÿ��� ���ϴ� �۾�
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                // ����� ������Ʈ �۾�
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
}