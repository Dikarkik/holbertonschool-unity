using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DataSystem
{
    // [Serializable]
    // public class MyData
    // {
    //     public int value;
    // }

    public class DataManager : MonoBehaviour
    {
        // [SerializeField] private GameData data;
        // private string _path;
        //
        // private void Awake()
        // {
        //     _path = $"{Application.persistentDataPath}/HighScore";
        // }
        //
        // public void Save()
        // {
        //     var file = new FileStream(_path, FileMode.OpenOrCreate);
        //     var bf = new BinaryFormatter();
        //     //var savedData = "Hola";
        //     var savedData = new MyData
        //     {
        //         value = 30
        //     };
        //     bf.Serialize(file, savedData);
        // }
        //
        // public void Load()
        // {
        //     var file = File.Open(_path, FileMode.Open);
        //     var bf = new BinaryFormatter();
        //     //var savedData = (string) bf.Deserialize(file);
        //     var savedData = (MyData)bf.Deserialize(file);
        //
        //     Debug.Log(savedData.value);
        // }
        //
        // private IEnumerator Start()
        // {
        //     Save();
        //     yield return new WaitForSeconds(3);
        //     Load();
        //     
        // }
    }
}