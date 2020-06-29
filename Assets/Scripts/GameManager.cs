using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PanelsInfo pI;
    [SerializeField] int leftX = -6;
    [SerializeField] int rightX = 6;
    [SerializeField] int upY = 6;
    [SerializeField] int downY = -6;
    Dictionary<Vector3, EmptyPanelScript> allTilesOnField = new Dictionary<Vector3, EmptyPanelScript>();
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
        int allI = 0;
        int emptyI = 0;
        for (int i = rightX; i <= leftX; i++)
            for (int j = upY; j >= downY; j--) 
            {
               if (pI.allTiles[allI] == null)
                {
                    allTilesOnField.Add(new Vector3(i, j, 0), pI.tilesToRandom[emptyI]);
                    emptyI++;
                }
               else
                {
                    allTilesOnField.Add(new Vector3(i, j, 0), pI.tilesToRandom[allI]);
                }
                allI++;
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

    public void StartClipSelect(Vector3 coord)
    {
        SetActivePanel(activePlayers[currentPlayerID].GetClipCoord(currentPlayerClipTag), false);
        activePlayers[currentPlayerID].MoveClip(coord, currentPlayerClipTag);
        StartPanelSelect(currentPlayerID + 1);
    }

    public void MoveClipWithoutEndingTurn(Vector3 coord)
    {
        SetActivePanel(activePlayers[currentPlayerID].GetClipCoord(currentPlayerClipTag), false);
        activePlayers[currentPlayerID].MoveClip(coord, currentPlayerClipTag);
    }

    public void ActivatePanel(Vector3 coord)
    {
        allTilesOnField[coord].SetActive(true);
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
        for (int i = -1;i<2;i++)
        {
            for (int j = -1;j<2;j++)
            {
                allTilesOnField[coord + new Vector3(i, j, 0)].SetActive(tmp);
            }
        }
    }
        
}
