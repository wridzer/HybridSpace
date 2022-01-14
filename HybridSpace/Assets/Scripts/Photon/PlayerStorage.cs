using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStorage
{
    private static Dictionary<int, GameObject> playerDict = new Dictionary<int, GameObject>();

    public static void AddPlayer(GameObject _player)
    {
        playerDict.Add(playerDict.Count + 1, _player);
    }

    public static void RemovePlayer(int _i)
    {
        if (playerDict.ContainsKey(_i))
            playerDict.Remove(_i);
    }

    public static void RemovePlayer(GameObject _player)
    {
        if (playerDict.ContainsValue(_player))
        {
            foreach(KeyValuePair<int, GameObject> playerEntry in playerDict)
            {
                if(playerEntry.Value == _player)
                {
                    playerDict.Remove(playerEntry.Key);
                }
            }
        }
    }

    public static List<GameObject> GetPlayers()
    {
        List<GameObject> playerList = new List<GameObject>();
        foreach(KeyValuePair<int, GameObject> playerEntry in playerDict)
        {
            playerList.Add(playerEntry.Value);
        }
        return playerList;
    }
}