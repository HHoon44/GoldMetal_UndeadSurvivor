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

    private float timer;
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;

            case 1:
                timer += Time.deltaTime;

                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }

                break;
        }
    }

    /// <summary>
    /// ������ ���� ���� �� �޼���
    /// </summary>
    /// <param name="damage"></param>
    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
        {
            Batch();
        }
    }


    public void Initialize()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;

            case 1:
                speed = .3f;
                break;
        }
    }

    private void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet;

            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            // ���� ���� �ʱ�ȭ
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;

            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Initialize(damage, -1);

            // -1 is Infinity Per.
        }
    }

    /// <summary>
    /// ���� ���ؼ� �Ѿ��� �߻��ϴ� �޼���
    /// </summary>
    private void Fire()
    {
        // ����� ���� �ִ��� Ȯ���ϴ� �۾�
        if (!player.scanner.nearestTarget)
        {
            return;
        }

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
    }
}