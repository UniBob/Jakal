using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] TableManager tm;
    [SerializeField] List<PlayerController> pc;

    int activePlayer;

    private void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        tm.StartPrepare();
        foreach(var player in pc)
        {
            player.StartPreparation();
        }
        activePlayer = 0;
        pc[activePlayer].StartClipSelect();
    }

    public void StartClipSelect(Vector2 tileCoord)
    {
        
        pc[activePlayer].MoveClip(tileCoord);
        activePlayer++;
        if (activePlayer >= pc.Count)
        {
            activePlayer = 0;
        }
        //Debug.Log(activePlayer);
        pc[activePlayer].StartClipSelect();
    }

    void CheckAtack(Vector3 coord)
    {
        foreach (PlayerController player in pc)
        {
            if (player != pc[activePlayer])
            {
                if (player.CheckAtack(coord)) player.RetutnToShip(coord);
            }
        }
    }

    public void StartTileSelect(Vector2 clipCoord)
    {
        tm.StartSelection(clipCoord);
    }

    public void StartTileSelect(Vector2 clipCoord, int just)
    {
        tm.StartSelection(clipCoord, 1);
    }

    public Vector2 GectChosenClipCoord()
    {
        return pc[activePlayer].GetChosenClipCoord();
    }
}
