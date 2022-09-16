using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveData
{
    public static void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.Data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(GameManager.instance.playerMat, GameManager.instance.playerLevel);

        binary.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/player.Data";

        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = binary.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else Debug.LogWarning($"Save file not found");
        return null;
    }

}
