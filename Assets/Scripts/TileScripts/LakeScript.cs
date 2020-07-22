using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScript : TileEffect
{
    public override void RunTileEffect()
    {

    }

    public override void ActivatePanel(Vector2 coord)
    {
        Debug.Log("I'm in Lake");
        //var tmp = FindObjectOfType<TableManager>();
        //tmp.SetActivateSingleTile(gameObject.transform.position, coord, false);
        //Vector2 tmpCoord = gameObject.transform.position;
        //tmp.SetActivateSingleTile(tmpCoord + (tmpCoord - coord), coord, true);
    }
}
