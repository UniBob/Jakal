using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : TileEffect
{
    [SerializeField] Vector3[] directions = new Vector3[4];
    public override void RunTileEffect(Vector2 coord)
    {

    }

    public override void ActivatePanel(Vector2 coord)
    {
        Debug.Log("I'm in Arrow");
        var tmp = GetComponent<EmptyTileScript>();
        
    }
}
