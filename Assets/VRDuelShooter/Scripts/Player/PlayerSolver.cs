using Fusion;
using UnityEngine;

namespace VRDuelShooter.Scripts.Player
{
    public class PlayerSolver : NetworkBehaviour
    {
        [SerializeField] private MeshRenderer _headPlayer;
        [SerializeField] private MeshRenderer _bodyRenderer;
        [SerializeField] private PlayerSynchronizer _playerSynchronizer;

        public override void Spawned()
        {
            base.Spawned();
            if (HasInputAuthority)
            {
                Destroy(_headPlayer.gameObject);
                Destroy(_bodyRenderer.gameObject);
            }
            else
            {
                Destroy(_playerSynchronizer.gameObject);
            }
        }
    }
}