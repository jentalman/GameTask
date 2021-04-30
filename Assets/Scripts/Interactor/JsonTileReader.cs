using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonTileReader : MonoBehaviour
{

    [SerializeField] private TextAsset _jsonTileData;

    public void LoadTileList(out TileDataList tileMap)
    {
        if (_jsonTileData == null)
            throw new Exception("Missing jsonTileData");
        else
            tileMap = JsonUtility.FromJson<TileDataList>(_jsonTileData.text);
    }

}