using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int playerMaterial;
    public int level;

    public PlayerData(int playerMaterial, int level)
    {
        this.playerMaterial = playerMaterial;
        this.level = level;
    }
}
