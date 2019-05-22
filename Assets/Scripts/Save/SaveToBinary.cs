using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveToBinary
{
    public static void SaveData(PlayerManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + player.playerName + ".data";
        FileStream stream = new FileStream(path, FileMode.Create);
        DataToSave data = new DataToSave(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static DataToSave LoadData(PlayerManager player)
    {
        string path = Application.persistentDataPath + "/" + player.playerName + ".data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
