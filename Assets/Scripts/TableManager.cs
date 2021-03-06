﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] TileInfo info;
    [SerializeField] Vector2 upLeftPoint;
    [SerializeField] GameManager gm;

    [SerializeField] EmptyTileScript water;

    Dictionary<Vector2, EmptyTileScript> tilesOnField = new Dictionary<Vector2, EmptyTileScript>();

    [SerializeField] bool isClipChoose;
    public Vector2 chosenClipCoord;
    

    // Start is called before the first frame update
    public void StartPrepare()
    {
        BoardSet();
    }

    public void TurnEnd(Vector2 coord)
    {
        foreach (var tile in tilesOnField)
        {
            tile.Value.SetActive(false);
        }
        isClipChoose = false;
        gm.StartClipSelect(coord);
    }

    private void Update()
    {
        if (isClipChoose)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                tmp.x = Mathf.Round(tmp.x);
                tmp.y = Mathf.Round(tmp.y);
                if (IsExists(tmp))
                {                    
                    if (tilesOnField[tmp].GetActive())
                    {
                        //Debug.Log("Tile chosen");
                        tilesOnField[tmp].ClipDown();
                    }
                }
                
            }
        }
    }

    public void StartSelection(Vector2 clipCoord)
    {
        isClipChoose = true;
        chosenClipCoord = clipCoord;
        for (int i = -1;i<=1;i++)
        {
            for (int j = -1;j<=1;j++)
            {                
                if (i == j && i == 0)
                { }
                else
                {
                    Vector2 tmp = new Vector2(clipCoord.x + i, clipCoord.y + j);
                    if (IsExists(tmp))
                    {
                        tilesOnField[tmp].SetActive(true, clipCoord);
                    }
                }
            }
        }
    }

    public void StartSelection(Vector2 clipCoord, int just)
    {
        isClipChoose = true;
        chosenClipCoord = clipCoord;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == j && i == 0)
                { }
                else
                {
                    Vector2 tmp = new Vector2(clipCoord.x + i, clipCoord.y + j);
                    if (IsExists(tmp))
                    {
                        if (tilesOnField[tmp].GetWater()) tilesOnField[tmp].SetActive(true, clipCoord);
                    }
                }
            }
        }
    }

    void BoardSet()
    {
        isClipChoose = false;
        Random rnd = new Random();
        info.tilesToRandom.OrderBy((item) => Random.value);

        int allI = 0, emptyI = 0;
        for (float i = upLeftPoint.x; i <= -upLeftPoint.x; i++) 
        {
            for (float j = upLeftPoint.y; j >= -upLeftPoint.y; j--) 
            {
                
                if (info.allTiles[allI] == null)
                {
                    //EmptyTileScript tmp = Instantiate(info.tilesToRandom[emptyI]) as EmptyTileScript;
                    Vector2 tmpCoord = new Vector2(i, j);
                    tilesOnField.Add(new Vector2(i, j), info.tilesToRandom[emptyI]);
                    Instantiate(tilesOnField[tmpCoord]);
                    tilesOnField[tmpCoord].StartPrep(tmpCoord);
                    emptyI++;
                }
                else
                {
                    //EmptyTileScript tmp = Instantiate(info.allTiles[allI]) as EmptyTileScript;
                    Vector2 tmpCoord = new Vector2(i, j);
                    tilesOnField.Add(new Vector2(i, j), info.allTiles[allI].GetComponent<EmptyTileScript>());
                    Instantiate(info.allTiles[allI]);
                    tilesOnField[tmpCoord].StartPrep(tmpCoord);                    
                }
                allI++;
            }
        }

    }
    
    void TempTableSet()
    {
        isClipChoose = false;
        EmptyTileScript[] tmpTiles = FindObjectsOfType<EmptyTileScript>();
       // Debug.Log(tmpTiles.Length);
        int tmpI = 0;
        for (float i = upLeftPoint.x; i <= -upLeftPoint.x; i++)
        {
            for (float j = upLeftPoint.y; j >= -upLeftPoint.y; j--)
            {
                if (tmpI < tmpTiles.Length)
                {
                    Vector2 tmpCoord = new Vector2(i, j);
                    tilesOnField.Add(tmpCoord, tmpTiles[tmpI]);
                    tilesOnField[tmpCoord].StartPrep(tmpCoord);
                    tmpI++;
                }
            }
        }
     //   Debug.Log(tilesOnField.Count);
    }

    bool IsExists(Vector2 tmp)
    {
        if ((Mathf.Abs(tmp.x) <= Mathf.Abs(upLeftPoint.x)) && (Mathf.Abs(tmp.y) <= Mathf.Abs(upLeftPoint.y)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetActivateSingleTile(Vector2 tileToActivateCoord, Vector2 clipCoord, bool tmp)
    {
        if (IsExists(tileToActivateCoord))
        {
            if (tilesOnField[tileToActivateCoord].GetActive() != tmp)
            {
                tilesOnField[tileToActivateCoord].SetActive(tmp, clipCoord);
            }
        }
    }

    public void SetActivateSingleTile(Vector2 tileToActivateCoord, bool tmp)
    {
        if (IsExists(tileToActivateCoord))
        {
            if (tilesOnField[tileToActivateCoord].GetActive() != tmp)
            {
                tilesOnField[tileToActivateCoord].SetActive(tmp);
            }
        }
    }

    public void GiveACoin(Vector3 coord)
    {
        gm.GiveACoin(coord);
    }

}
