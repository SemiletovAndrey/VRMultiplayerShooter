using Fusion;
using UnityEngine;

namespace VRDuelShooter.Scripts.Player
{
    public class PlayerSolver : NetworkBehaviour
    {
        [SerializeField] private MeshRenderer _headPlayer;
        [SerializeField] private MeshRenderer _bodyRenderer;

        public override void Spawned()
        {
            base.Spawned();
            if (HasInputAuthority)
            {
                Debug.Log("Player solvedSpawned");
                _headPlayer.enabled = false;
                _bodyRenderer.enabled = false;
            }
        }
    }
}