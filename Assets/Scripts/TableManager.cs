using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] TileInfo info;

    [SerializeField] Vector2 upLeftPoint;

    Dictionary<Vector2, EmptyTileScript> tilesOnField;
    bool isClipChoose = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TurnEnd()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isClipChoose)
        {
            Vector2 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tmp.x = Mathf.Round(tmp.x);
            tmp.y = Mathf.Round(tmp.y);
            tilesOnField[tmp].ClipDown();
        }
    }

    public void SetIsClipChoose(bool tmp)
    {
        isClipChoose = tmp;
    }



    void BoardSet()
    {
        Random rnd = new Random();
        info.tilesToRandom.OrderBy((item) => Random.value);
        int allI = 0, emptyI = 0;
        for (float i = upLeftPoint.x; i < -upLeftPoint.x; i++)
        {
            for (float j = upLeftPoint.y;j<-upLeftPoint.y;j++)
            {   
                if (info.allTiles[allI] == null)
                {
                    tilesOnField.Add(new Vector2(i, j), info.tilesToRandom[emptyI]);
                    emptyI++;
                }
                else
                {
                    tilesOnField.Add(new Vector2(i, j), info.allTiles[allI]);
                }
                allI++;
            }
        }

    }


}
