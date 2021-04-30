using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TileData
{
    public string Id;
    public string Type;
    public double Width;
    public double Height;
    public double X;
    public double Y;
}
[System.Serializable]
public class TileDataList
{
    public TileData[] List;
}