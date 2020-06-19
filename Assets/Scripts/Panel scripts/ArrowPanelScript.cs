using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPanelScript : MonoBehaviour
{
    bool[] directions = new bool[9];

    public void panelOption(int panelTag, GameManager gm)
    {
        gm.MoveClipWithoutEndingTurn(panelTag);
        for(int i = 0;i<9;i++)
        {
            if (directions[i])
            {
                switch(i)
                {
                    case 0:
                        ActivatePanel
                        break;
                }
            }
        }
    }

}
