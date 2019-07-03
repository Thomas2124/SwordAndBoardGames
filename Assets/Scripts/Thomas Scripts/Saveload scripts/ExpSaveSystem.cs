using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class ExpSaveSystem
{
    public static void SavePlayer(PlayerScript myList)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/characterExp2.this";
        FileStream stream = new FileStream(path, FileMode.Create);

        ExpSaver expData = new ExpSaver(myList);

        formatter.Serialize(stream, expData);
        stream.Close();

    }

    public static ExpSaver LoadPlayer()
    {
        string path = Application.persistentDataPath + "/characterExp2.this";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ExpSaver expData = formatter.Deserialize(stream) as ExpSaver;
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
