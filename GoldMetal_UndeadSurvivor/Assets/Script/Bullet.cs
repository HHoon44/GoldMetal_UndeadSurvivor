using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    /// <summary>
    /// ���� �ʱ�ȭ �޼���
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="per"></param>
    public void Initialize(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }
}