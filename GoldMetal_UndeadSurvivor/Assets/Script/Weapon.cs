using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    public void Initialize()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;

            case 1:
                break;
        }
    }

    private void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Initialize(damage, -1);
        }
    }
}