using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRDuelShooter.Scripts.Player
{
    public class PlayerSynchronizer : MonoBehaviour
    {
        [SerializeField] public Transform avatarHeadTransform;
        [SerializeField] public Transform avatarLeftHandTransform;
        [SerializeField] public Transform avatarRightHandTransform;
        [SerializeField] public Transform avatarBodyTransform;
        
        private Transform xrHeadTransform;
        private Transform xrLeftHandTransform;
        private Transform xrRightHandTransform;
        private Transform xrBodyTransform;
        
        public void Initialize(Transform head, Transform leftHand, Transform rightHand, Transform body)
        {
            xrHeadTransform = head;
            xrLeftHandTransform = leftHand;
            xrRightHandTransform = rightHand;
            xrBodyTransform = body;
        }
        
        private void LateUpdate()
        {
            if (xrHeadTransform != null) SynchronizePart(xrHeadTransform, avatarHeadTransform);
            if (xrLeftHandTransform != null) SynchronizePart(xrLeftHandTransform, avatarLeftHandTransform);
            if (xrRightHandTransform != null) SynchronizePart(xrRightHandTransform, avatarRightHandTransform);
            if (xrBodyTransform != null) SynchronizePart(xrBodyTransform, avatarBodyTransform);
        }

        private void SynchronizePart(Transform source, Transform target)
        {
            if (source == null || target == null) return;

            target.position = source.position;
            target.rotation = source.rotation;
        }
    }
}