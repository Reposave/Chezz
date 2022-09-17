using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Board;
using Newtonsoft.Json;

[CreateAssetMenu(menuName = "Create Piece Movement")]
public class MovementData : ScriptableObject
{
    [SerializeField]
    private string filePath;
    
    public string Name;
    public List<TileInfo> TilesInfos;

    public void ReadJson()
    {
        using (StreamReader stream = new StreamReader(filePath))
        {
            string json = stream.ReadToEnd();
            
            MovementData loadedData = JsonConvert.DeserializeObject<MovementData>(json);
            Name = loadedData.Name;
            TilesInfos = loadedData.TilesInfos;
            stream.Close();
        }
    }
    
    public void OutputJson()
    {
        using (StreamWriter stream = new StreamWriter(filePath))
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            stream.Write(json);
            stream.Close();
        }
    }
}
