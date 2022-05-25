using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject 
{
    public int coins;
    public int highscore;
    public ShipStats shipStats;

    public SaveObject()
    {
        coins = 0;
        highscore = 0;

        shipStats = new ShipStats();
        shipStats.maxHealth = 3;
        shipStats.maxLives = 3;
        shipStats.shipStats = 3;
        shipStats.fireRate = 0.5f;
    }
}
