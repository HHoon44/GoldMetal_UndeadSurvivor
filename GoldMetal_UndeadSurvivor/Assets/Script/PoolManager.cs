using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �����յ��� ������ ����
    public GameObject[] prefabs;

    // Ǯ�� ��Ƴ��� ����
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            // i��°�� ���� ������Ʈ Ǯ�� ����
            pools[i] = new List<GameObject>();
        }
    }

    /// <summary>
    /// ��û�� ���� ������Ʈ�� ��ȯ���ִ� �޼���
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject Get(int index)
    {
        GameObject select = null;

        // ��û�� ������Ʈ�� ã�� �۾�
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ��û�� ������Ʈ�� ���ٸ� �����ϴ� �۾�
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}