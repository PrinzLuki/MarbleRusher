using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public void SetClickedMaterial(Transform t)
    {
        for (int i = 0; i < GameManager.Instance.matDatas.Count; i++)
        {

            if (t.name == GameManager.Instance.matDatas[i].name)
            {
                GameManager.Instance.playersMat = GameManager.Instance.matDatas[i];
                Debug.Log($"Transform name = {t.name} == {GameManager.Instance.matDatas[i].name}");
            }
        }

    }
}

[System.Serializable]
public class MaterialData
{
    public string name;
    public Material material;
    public int index;
}
