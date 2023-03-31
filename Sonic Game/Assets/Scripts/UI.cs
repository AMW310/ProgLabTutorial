using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text coin;
    public Text playerPosition;
    public DataManager dataManager;
    void Start()
    {
        dataManager.Load();
        playerPosition.text = $"({dataManager.data.pos_x.ToString()}, {dataManager.data.pos_y.ToString()}, {dataManager.data.pos_z.ToString()})";
        coin.text = dataManager.data.coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            NewSave();
        }
    }

    public void NewSave()
    {
        dataManager.Save();
        playerPosition.text = $"({dataManager.data.pos_x.ToString()}, {dataManager.data.pos_y.ToString()}, {dataManager.data.pos_z.ToString()})";
        coin.text = dataManager.data.coin.ToString();
    }
}
