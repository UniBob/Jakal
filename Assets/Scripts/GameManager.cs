using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PanelsInfo pI;
    EmptyPanelScript[] allTilesOnField;
    Player[] activePlayers;
    int currentPlayerID;
    int playerAmmount;
    int currentPlayerClipTag;

    private void Start()
    {
        PlayerStart();
        PanelStart();
        StartGame();
        
    }

    void PanelStart()
    {
        allTilesOnField = FindObjectsOfType<EmptyPanelScript>();
        int j = 0;
        foreach (var i in allTilesOnField)
        {
            i.SetTag(j);
            i.SetActive(false);
            j++;
        }
    }

    void PlayerStart()
    {
        activePlayers = FindObjectsOfType<Player>();
        int j = 0;
        foreach (var i in activePlayers)
        {
            i.SetID(j);
            j++;
        }
        playerAmmount = activePlayers.Length;
    }

    void StartGame()
    {
        activePlayers[0].StartTurn();
    }

    public void StartClipSelect(int tileTag)
    {
        SetActivePanel(activePlayers[currentPlayerID].GetClipCoord(currentPlayerClipTag), false);
        activePlayers[currentPlayerID].MoveClip(allTilesOnField[tileTag].GetCoord(), currentPlayerClipTag);
        StartPanelSelect(currentPlayerID + 1);
    }

    public void MoveClipWithoutEndingTurn(int tileTag)
    {
        SetActivePanel(activePlayers[currentPlayerID].GetClipCoord(currentPlayerClipTag), false);
        activePlayers[currentPlayerID].MoveClip(allTilesOnField[tileTag].GetCoord(), currentPlayerClipTag);
    }

    public void ActivatePanel(Vector3 coord)
    {
        foreach (var i in allTilesOnField)
        {
            if (i.GetCoord() == coord)
            {
                i.SetActive(true);
                break;
            }
        }
    }

    public void StartPanelSelect(int playerTag)
    {
        currentPlayerID = playerTag;
        if (currentPlayerID >= playerAmmount) currentPlayerID = 0;
        foreach (PlayerClipScript i in activePlayers[currentPlayerID].clips)
        {
            SetActivePanel(i.GetCoord(), true);
        }
    }
    
    void SetActivePanel(Vector3 coord, bool tmp)
    {
        foreach(EmptyPanelScript i in allTilesOnField)
        {
            if (Vector3.Distance(i.GetCoord(), coord)<2)
            {
                i.SetActive(tmp);
            }
        }
    }
        
}
