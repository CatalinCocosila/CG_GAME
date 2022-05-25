using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadProgress(); 
    }

    public static void SaveProgress()
    {
        SaveObject so = new SaveObject();

        so.coins = Inventory.currentCoins;
        so.highscore = UIManager.GetHighScore();
        so.shipStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().shipStats;
    }

    public static void LoadProgress()
    {
        SaveObject so = SaveLoad.LoadState();

        //Invetory.currentCoins = so.coins;
        //UIManager.UpdateHighscore(so.highscore);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().shipStats = so.shipStats;
    }
}
