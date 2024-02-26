using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class JsonDataService
{
    //public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
    //{
        // string path = Application.persistentDataPath + RelativePath;

        //string streamPath = Application.persistentDataPath+ RelativePath;
        //try
        //{
        //    if (File.Exists(streamPath))
        //    {
        //        Debug.Log("Data exists, Deleting old file and writing a new one!");
        //        File.Delete(streamPath);
        //    }
        //    else
        //    {
        //        Debug.Log("Wtiting file for the first time");
        //    }

        //    using FileStream stream = File.Create(streamPath);
        //    stream.Close();
        //    File.WriteAllText(streamPath, JsonConvert.SerializeObject(Data));
        //    return true;
        //}
        //catch (Exception e)
        //{
        //    Debug.LogError($"Unable to save data dur to: {e.Message} {e.StackTrace}");
        //    return false;
        //}
    //}

    //public T LoadData<T>(string RelativePath, bool Encrypted)
    //{
    //    //string path = Application.persistentDataPath + RelativePath;

    //    string streamPath = Path.Combine(Application.persistentDataPath+ RelativePath);

    //    if (!File.Exists(streamPath))
    //    {
    //        Debug.LogError($"Cannot load file at {streamPath}. File does not exist!");
    //        throw new FileNotFoundException($"{streamPath} does not exist!");
    //    }

    //    using (var request = UnityWebRequest.Get(streamPath))
    //    {
    //        yield return request.SendWebRequest();

    //        if (request.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.LogError("Error: " + request.result);
    //            yield break;
    //        }

    //        streamPath = request.downloadHandler.text;
    //        T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(streamPath));
    //    }

        //    try
        //{
        //   //WWW www = new WWW(streamPath);          
        //    T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(streamPath));
        //    return data;
        //}
        //catch (Exception e)
        //{
        //    Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
        //    throw e;
        //}
    }

