using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{

    private string _id;
    public string Id
    {
        get { return _id; }
    }

    private string _type;
    public double _width;
    private double _height;
    private float _posX;
    private float _posY;
    private SpriteRenderer _icon;

    private void OnEnable()
    {
        _icon = GetComponent<SpriteRenderer>();
    }

    public void SetValues(TileData data)
    {
        this._id = data.Id;
        this._type = data.Type;
        this._width = data.Width;
        this._height = data.Height;
        this._posX = (float)data.X;
        this._posY = (float)data.Y;
    }

    public void SetSprite()
    {
        _icon.sprite = Resources.Load<Sprite>($"Sprites/Background/{_id}");
    }

    public void SetPosition()
    {
        transform.position = new Vector2(_posX, _posY);
    }

    public void SetOffsetPosition(float posX)
    {
        transform.position = new Vector2(posX, _posY);
    }

    public float OffsetPosition()
    {
        return _icon.sprite.bounds.extents.x;
    }
}
