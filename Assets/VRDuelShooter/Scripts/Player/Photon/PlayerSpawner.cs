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
                _xROrigin.SetActive(true);
                
                var spawnedPlayer = Runner.Spawn(_playerPrefab, new Vector3(0,2,0), Quaternion.identity, Runner.LocalPlayer);
                _xROrigin.transform.position = new Vector3(0,2,0);
                
                PlayerSynchronizer synchronizer = spawnedPlayer.GetComponent<PlayerSynchronizer>();
                synchronizer.Initialize(_xrFacade.HeadTransform, _xrFacade.LeftHandTransform, _xrFacade.RightHandTransform, _xrFacade.BodyTransform);
            }
        }
    }
}