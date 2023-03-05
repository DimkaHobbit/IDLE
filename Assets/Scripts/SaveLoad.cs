using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public Object[] saveObjects;
    private string _savePath;

    private void Awake()
    {
        _savePath = $"{Application.dataPath}/Saves/";

        for (int step = 0; step < saveObjects.Length; step++)
        {
            string savePath = $"{_savePath + saveObjects[step].GetType()}.json";
            Load(savePath, saveObjects[step]);
        }
    }

    public void OnApplicationQuit()
    {
        for (int step = 0; step < saveObjects.Length; step++)
        {
            string savePath = $"{_savePath + saveObjects[step].GetType()}.json";
            Save(savePath, saveObjects[step]);
        }
    }

    private void Save(string savePath, object saveObject)
    {
        using (StreamWriter sw = new StreamWriter(savePath))
        {
            string json = JsonUtility.ToJson(saveObject);
            sw.Write(json);
            sw.Close();
        }
    }

    private void Load(string loadPath, object saveObject)
    {
        if (File.Exists(loadPath))
        {
            Debug.Log($"Загрузка сохранения для {saveObject}");

            string json;

            using (StreamReader sr = new StreamReader(loadPath))
            {
                json = sr.ReadToEnd();
                sr.Close();
            }

            JsonUtility.FromJsonOverwrite(json, saveObject);
        }
    }
}
