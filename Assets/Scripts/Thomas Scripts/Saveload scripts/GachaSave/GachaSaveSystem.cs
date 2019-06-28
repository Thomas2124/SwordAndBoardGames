using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class GachaSaveSystem
{
    public static void SavePlayer1(GachaRolls expList)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/newcharacterExp3.this";
        FileStream stream = new FileStream(path, FileMode.Create);

        GachaExpList expData = new GachaExpList(expList);

        formatter.Serialize(stream, expData);
        stream.Close();

    }

    public static GachaExpList LoadPlayer1()
    {
        string path = Application.persistentDataPath + "/newcharacterExp3.this";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GachaExpList expData = formatter.Deserialize(stream) as GachaExpList;
            stream.Close();
            return expData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}