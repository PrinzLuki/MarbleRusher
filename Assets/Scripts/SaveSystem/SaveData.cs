using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveData
{
    public static void Save()
    {
        BinaryFormatter binary = new();
        string path = Application.persistentDataPath + "/player.SavedData"; /*Application.persistentDataPath + " / player.Data"*/
        FileStream stream = new(path, FileMode.Create);

        PlayerData data = new(GameManager.Instance.playersMat.index);

        binary.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/player.SavedData";

        if (File.Exists(path))
        {
            BinaryFormatter binary = new();
            FileStream stream = new(path, FileMode.Open);

            PlayerData data = binary.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning($"Save file not found");
            return null;
        }
    }

}
