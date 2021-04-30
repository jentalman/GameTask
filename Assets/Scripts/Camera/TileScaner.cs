using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileScaner : MonoBehaviour
{

    public UnityAction<Tile> OnGetTileEvent;

    private Camera _mainCamera;
    private Vector3 _leftTopPoint;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
            return;

        GetTile();
    }

    private void GetTile()
    {
        _leftTopPoint = _mainCamera.ViewportToWorldPoint(Vector2.up);
        RaycastHit2D hit = Physics2D.Raycast(_leftTopPoint, Vector3.forward, 11f);
        if (hit.collider != null)
        {
            hit.collider.TryGetComponent<Tile>(out Tile tile);
            OnGetTileEvent?.Invoke(tile);
        }
    }

    
}
