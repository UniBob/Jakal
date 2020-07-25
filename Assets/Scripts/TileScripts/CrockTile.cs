using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrockTile : TileEffect
{
    public override void RunTileEffect(Vector2 coord)
    {
        var tmp = GetComponent<TableManager>();
        Vector2 tmpCoord = gameObject.transform.position;
        tmp.SetActivateSingleTile(tmpCoord, false);
        tmp.SetActivateSingleTile(coord, true);
    }

    public override void ActivatePanel(Vector2 coord)
    {
       // Debug.Log("I'm in Arrow");
        var tmp = GetComponent<TableManager>();
        Vector2 tmpCoord = gameObject.transform.position;
        tmp.SetActivateSingleTile(tmpCoord, false);
        tmp.SetActivateSingleTile(coord,true);
    }
}
