using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject[] _spawnPoints;
    
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Vector3 spawnPosition = new Vector3((player.RawEncoded % Runner.Config.Simulation.PlayerCount) * 3, 1, 0);
            spawnPosition.y = 0;
            Debug.Log($"Runner.Config.Simulation.PlayerCount {Runner.Config.Simulation.PlayerCount}");
            Runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
