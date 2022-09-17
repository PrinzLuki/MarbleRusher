using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("Data To Save")]
    public MaterialData playersMat;
    public int playerLevel = 1;

    public List<MaterialData> matDatas;

    float matchTime;

    public static event Action<float> OnTimeChanged;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    #region TimeCounter
    public void ResetTimer()
    {
        matchTime = 0;
    } 

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            matchTime += Time.deltaTime;
            OnTimeChanged?.Invoke(matchTime);
            yield return null;
        }
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    #endregion


    #region SaveData
    public void LoadSavedData()
    {
        var data = SaveData.LoadData();

        playersMat.index = data.playerMaterial;
    }

    public void Save()
    {
        SaveData.Save();
    }
    #endregion

    public void LoadPlayerMaterial(Transform player)
    {
        if (player == null) { Debug.LogWarning("No Player found!!"); return; }

        Debug.Log($"{player.GetComponent<Renderer>().material} || {playersMat.index} || {matDatas[playersMat.index].material}");
        player.GetComponent<Renderer>().material = matDatas[playersMat.index].material;
    }

    public void GetPlayerMatIndex()
    {
        playersMat.index = PlayerPrefs.GetInt("playerMat");
    } 

    public void SetPlayerMatIndex()
    {
        PlayerPrefs.SetInt("playerMat", playersMat.index);
    }




    void LoadPlayerLevel()
    {

    }
}
