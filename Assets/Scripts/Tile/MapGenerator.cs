using UnityEngine;

[System.Serializable]
public class MapGenerator : MonoBehaviour
{

    [SerializeField] private Tile _template;

    private TileDataList _tileMap;
    private JsonTileReader _jsonTileReader;

    private float _previousX;
    private float _offsetPrev;
    private float _offsetCurr;

    private void Awake()
    {
        _jsonTileReader = GetComponent<JsonTileReader>();
        _jsonTileReader.LoadTileList(out _tileMap);

        GenerateMap();
    }

    private void GenerateMap()
    {

        for (int i = 0; i < _tileMap.List.Length; i++)
        {
            var newObject = Instantiate(_template, transform);
            newObject.SetValues(_tileMap.List[i]);
            newObject.SetSprite();
            if (_tileMap.List[i].X - _previousX >= 0)
            {
                _offsetCurr = newObject.OffsetPosition();
                _previousX += _offsetCurr + _offsetPrev;
                newObject.SetOffsetPosition(_previousX);
                _offsetPrev = _offsetCurr;

            }
            else
            {
                _offsetPrev = 0;
                _previousX = 0;
                _offsetCurr = newObject.OffsetPosition();
                _previousX += _offsetCurr + _offsetPrev;
                newObject.SetOffsetPosition(_previousX);
                _offsetPrev = _offsetCurr;
            }
        }
    }
}
