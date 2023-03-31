using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SaveData : MonoBehaviour
{
    public SaveDataObject SaveDataObject;

    private string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/Save.dat";
        SaveDataObject = new SaveDataObject
        {
            stats = new Stats(),
            inventory = new List<Inventory>()
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveDataObject.stats = new Stats { health = 100, coins = Manager.coinCount};
        }
    }
}

[System.Serializable]
public class SaveDataObject
{
    public Stats stats;
    public List<Inventory> inventory;
}
[System.Serializable]
public class Stats
{
    public int health;
    public int coins;
}
[System.Serializable]
public class Inventory
{
    public int itemId;
    public string itemName;
}
