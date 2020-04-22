using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    private static string FILE_NAME = "/player.dat";
    public static void SavePlayer(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + FILE_NAME;
        FileStream stream = new FileStream(path, FileMode.Create);
        //PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, player);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + FILE_NAME;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Close();
            return formatter.Deserialize(stream) as PlayerData;
        }
        Debug.Log("Save file not found in " + path);
        return null;
    }
}
