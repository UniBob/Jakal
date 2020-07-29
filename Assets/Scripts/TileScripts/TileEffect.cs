using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEffect : MonoBehaviour
{
    public virtual void RunTileEffect(Vector2 coord) 
    {
        GetComponent<EmptyTileScript>().TurnEnd();
    }
    public virtual void ActivatePanel(Vector2 tmp) { }
}
