using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private TMP_Text _TileNameText;
    [SerializeField] private TileScaner _GetTileEvent;

    private void OnEnable()
    {
        _GetTileEvent.OnGetTileEvent += ChangeTileNameText;
    }

    private void OnDisable()
    {
        _GetTileEvent.OnGetTileEvent -= ChangeTileNameText;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ChangeTileNameText(Tile tile)
    {
        _TileNameText.text = tile.Id;
    }
}
