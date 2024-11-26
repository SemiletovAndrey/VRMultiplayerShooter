using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using VRDuelShooter.Scripts.XR;
using Zenject;

namespace VRDuelShooter.Scripts.Player.Photon
{
    public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _xROrigin;
        [SerializeField] private GameObject[] _spawnPoints;

        [SerializeField] private XRFacade _xrFacade;


        public void Construct(XRFacade xRFacade)
        {
            _xrFacade = xRFacade;
            if (_xrFacade == null)
            {
                Debug.Log("XRFacade is null");
            }
        }

        public void PlayerJoined(PlayerRef player)
        {
            if (player == Runner.LocalPlayer)
            {
                int spawnIndex =
                    player.RawEncoded %
                    _spawnPoints.Length; // Берём остаток от деления на длину массива для безопасности
                Vector3 spawnPosition = _spawnPoints[spawnIndex].transform.position;

                _xROrigin.SetActive(true);
                _xROrigin.transform.position = spawnPosition;

                var spawnedPlayer = Runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);

                var synchronizer = spawnedPlayer.GetComponent<PlayerSynchronizer>();
                synchronizer.Initialize(
                    _xrFacade.HeadTransform,
                    _xrFacade.LeftHandTransform,
                    _xrFacade.RightHandTransform,
                    _xrFacade.BodyTransform
                );
            }
        }
    }
}