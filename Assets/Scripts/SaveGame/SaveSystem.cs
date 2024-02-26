using System.IO;
using UnityEngine;

public static class SaveSystem
{
    //private static readonly string Save_Folder = Application.dataPath + "/Saves/";

    //public static void Init()
    //{
    //    if (!Directory.Exists(Save_Folder))
    //        Directory.CreateDirectory(Save_Folder);
    //}

    public static void Save(string saveString)
    {
        File.WriteAllText(Application.persistentDataPath + "/save.txt", saveString);
    }

    public static string Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/save.txt");
            return saveString;
        }
        else
            return null;
    }
}
