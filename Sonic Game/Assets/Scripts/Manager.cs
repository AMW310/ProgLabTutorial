using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int coinCount;
    public static Transform playerPos;

    internal int coin = coinCount;
    internal float pos_x;
    internal float pos_y;
    internal float pos_z;

    public DataManager dataManager;

    private void FixedUpdate()
    {
        playerPos = GameObject.Find("Banana Man").transform;
    }
    private void Start()
    {
        coin = coinCount;
        pos_x = playerPos.position.x;
        pos_y = playerPos.position.y;
        pos_z = playerPos.position.z;
    }
    private void Update()
    {
        Debug.Log(coinCount);
    }
}


