using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //  public GameObject[] tilesToRandom;
  //  public GameObject playerPrefab;

    EmptyPanelScript[] allTilesOnField;
    Player[] activePlayers;
    int currentPlayerID;
    int playerAmmount;
    int currentPlayerClipTag;

    private void Start()
    {
        activePlayers = FindObjectsOfType<Player>();
        int j = 0;
        foreach(var i in activePlayers)
        {
            i.SetID(j);
            j++;
        }
        playerAmmount = activePlayers.Length;
        allTilesOnField = FindObjectsOfType<EmptyPanelScript>();
        j = 0;
        foreach (var i in allTilesOnField)
        {
            i.SetTag(j);
            i.SetActive(false);
            j++;
        }
        StartGame();
        
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

    public void ActivatePanel(int panelTag)
    {
        allTilesOnField[panelTag].SetActive(true);
    }

    public void StartPanelSelect(int playerTag)
    {
        currentPlayerID = playerTag;
        if (currentPlayerID == playerAmmount) currentPlayerID = 0;
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
