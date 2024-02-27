using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    private void Awake()
    {
        instance = this;
    }
}