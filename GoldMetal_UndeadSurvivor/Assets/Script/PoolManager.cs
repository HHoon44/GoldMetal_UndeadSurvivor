using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹들을 보관할 변수
    public GameObject[] prefabs;

    // 풀을 담아놓을 변수
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            // i번째에 게임 오브젝트 풀을 생성
            pools[i] = new List<GameObject>();
        }
    }

    /// <summary>
    /// 요청한 게임 오브젝트를 반환해주는 메서드
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject Get(int index)
    {
        GameObject select = null;

        // 요청한 오브젝트를 찾는 작업
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 요청한 오브젝트가 없다면 생성하는 작업
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}