using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPanelScript : MonoBehaviour
{
    bool[] directions = new bool[8];

    public void panelOption(GameManager gm, EmptyPanelScript panel)
    {
        gm.MoveClipWithoutEndingTurn(panel.GetTag());
        for(int i = 0;i<8;i++)
        {
            if (directions[i])
            {
                Vector3 tmp = panel.GetCoord();
                switch(i)
                {
                    case 0:
                        tmp.x += -1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 1:
                        tmp.x += 1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 2:
                        tmp.x += -1;
                        tmp.y += -1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 3:
                        tmp.x += -1;
                        tmp.y += 1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 4:
                        tmp.x += 1;
                        tmp.y += -1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 5:
                        tmp.x += 1;
                        tmp.y += 1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 6:
                        tmp.y += -1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 7:
                        tmp.y += -1;
                        gm.ActivatePanel(tmp);
                        break;
                    case 8:
                        tmp.y += 1;
                        gm.ActivatePanel(tmp);
                        break;
                }
            }
        }
    }

}
