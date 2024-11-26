using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VRDuelShooter.Scripts.Hand
{
    public class SmoothHandAnimation : NetworkBehaviour
    {
        [SerializeField] private Animator _handAnimator;
        [SerializeField] private InputActionReference _triggerActionRef;
        [SerializeField] private InputActionReference _gripActionRef;

        private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
        private static readonly int GripAnimation = Animator.StringToHash("Grip");

        public override void FixedUpdateNetwork()
        {
            if (HasInputAuthority)
            {
                float triggerValue = _triggerActionRef.action.ReadValue<float>();
                _handAnimator.SetFloat(TriggerAnimation, triggerValue);

                float gripValue = _gripActionRef.action.ReadValue<float>();
                _handAnimator.SetFloat(GripAnimation, gripValue);
            }
        }
    }
}