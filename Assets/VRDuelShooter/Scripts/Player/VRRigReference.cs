using Fusion;
using UnityEngine;

namespace VRDuelShooter.Scripts.Player
{
    public class VRRigReference : NetworkBehaviour
    { 
        [SerializeField] private Transform _headTransform;

        [SerializeField] private Transform _leftHandTransform;
        [SerializeField] private Transform _rightHandTransform;
        [SerializeField] private Transform _bodyTransform;
        
        [Networked] private Vector3 _headPosition { get; set; }

        [Networked] private Quaternion _headRotation { get; set; }

        [Networked] private Vector3 _leftHandPosition { get; set; }
        [Networked] private Quaternion _leftHandRotation { get; set; }

        [Networked] private Vector3 _rightHandPosition { get; set; }
        [Networked] private Quaternion _rightHandRotation { get; set; }

        [Networked] private Vector3 _bodyPosition { get; set; }
        [Networked] private Quaternion _bodyRotation { get; set; }

        public override void FixedUpdateNetwork()
        {
            if (Object.HasInputAuthority)
            {
                _headPosition = _headTransform.position;
                _headRotation = _headTransform.rotation;

                _leftHandPosition = _leftHandTransform.position;
                _leftHandRotation = _leftHandTransform.rotation;

                _rightHandPosition = _rightHandTransform.position;
                _rightHandRotation = _rightHandTransform.rotation;

                _bodyPosition = _bodyTransform.position;
                _bodyRotation = _bodyTransform.rotation;
            }
            else
            {
                UpdateBodyPart(_headTransform, _headPosition, _headRotation);
                UpdateBodyPart(_leftHandTransform, _leftHandPosition, _leftHandRotation);
                UpdateBodyPart(_rightHandTransform, _rightHandPosition, _rightHandRotation);
                UpdateBodyPart(_bodyTransform, _bodyPosition, _bodyRotation);
            }
        }

        private void UpdateBodyPart(Transform partTransform, Vector3 position, Quaternion rotation)
        {
            partTransform.position = Vector3.Lerp(partTransform.position, position, Runner.DeltaTime * 10f);
            partTransform.rotation = Quaternion.Slerp(partTransform.rotation, rotation, Runner.DeltaTime * 10f);
        }
    }
}