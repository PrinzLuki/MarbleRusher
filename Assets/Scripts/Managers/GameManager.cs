using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] Transform player;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    [Header("Data To Save")]
    public int playerMat = 1;
    public int playerLevel = 1;

    public List<Material> allPlayerMaterials = new();


    #region SaveData
    public void LoadSavedData()
    {
        var data = SaveData.LoadData();
        if (data != null)
        {
            playerMat = data.playerMaterial;
            playerLevel = data.level;
        }
    }

    public void Save()
    {
        SaveData.Save();
    }
    #endregion

    void LoadPlayerMaterial()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (player == null) return;
    }

    void LoadPlayerLevel()
    {

    }

}
