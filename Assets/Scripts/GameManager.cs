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

    public void StartTileSelect(Vector2 clipCoord)
    {
        tm.StartSelection(clipCoord);
    }
}
