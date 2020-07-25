using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScript : TileEffect
{
    public override void RunTileEffect(Vector2 coord)
    {
        var gm = FindObjectOfType<GameManager>();

    }

    public override void ActivatePanel(Vector2 coord)
    {
        //Debug.Log("I'm in Lake");
        var tmp = FindObjectOfType<TableManager>();
        Vector2 tmpCoord = gameObject.transform.position;
        tmp.SetActivateSingleTile(tmpCoord, false);
        tmp.SetActivateSingleTile(tmpCoord + (tmpCoord - coord), tmpCoord, true);
    }
}
