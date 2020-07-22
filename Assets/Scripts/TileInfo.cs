﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TILE INFO")]

public class TileInfo : ScriptableObject
{
    public List<EmptyTileScript> tilesToRandom;
    public List<GameObject> allTiles;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int playersCount;
}

