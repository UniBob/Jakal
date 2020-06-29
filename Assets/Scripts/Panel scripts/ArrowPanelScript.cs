using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ArrowPanelScript : TileEffect
{
    [SerializeField] Vector3[] directions;

    public void panelOption(GameManager gm, EmptyPanelScript panel)
    {
        gm.MoveClipWithoutEndingTurn(panel.GetCoord());
        
        foreach(Vector3 i in directions)
        {
            gm.ActivatePanel(i);
        }
    }

}
