using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerClipScript[] clips;
    public int playerID;

    GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        int j = 0;
        foreach (PlayerClipScript i in clips)
        {
            i.SetTag(j);
            j++;
        }
    }

    public void StartTurn()
    {
        foreach (PlayerClipScript i in clips)
        {
            i.SetActive(true);
        }
    }

    public void StartPanelSelect(int playerClipTag)
    {
        foreach(PlayerClipScript i in clips)
        {
            i.SetActive(false);
        }
        gm.StartPanelSelect(playerClipTag);
    }

    public void MoveClip(Vector3 newCoord, int playerClipTag)
    {
        clips[playerClipTag].Move(newCoord);
    }

    public void SetID(int id)
    {
        playerID = id;
    }
    
    public Vector3 GetClipCoord(int clipTag)
    {
        return clips[clipTag].GetCoord();
    }


}
