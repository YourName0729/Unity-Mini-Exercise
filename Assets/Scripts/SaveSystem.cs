using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void Save(GameObject[] objs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.save";

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            SaveData data = new SaveData(objs);

            formatter.Serialize(fs, data);
        }
    }

    public static void Load(GameObject[] objs)
    {
        string path = Application.persistentDataPath + "/save.save";
        if (!File.Exists(path))
        {
            Debug.LogError(path + " NOT found");
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            SaveData data = formatter.Deserialize(fs) as SaveData;
            data.ApplyTo(objs);
        }
    }
}
