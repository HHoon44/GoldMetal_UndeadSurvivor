using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    /// <summary>
    /// 무기 초기화 메서드
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="per"></param>
    public void Initialize(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }
}