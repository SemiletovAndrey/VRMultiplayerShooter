using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VRDuelShooter.Scripts.Hand
{
    public class SnapHandAnimation : MonoBehaviour

    {
        [SerializeField] private Animator _handAnimator;
        [SerializeField] private InputActionReference _triggerActionRef;
        [SerializeField] private InputActionReference _gripActionRef;

        private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
        private static readonly int GripAnimation = Animator.StringToHash("Grip");

        private void OnEnable()
        {
            _triggerActionRef.action.performed += TriggerActionPerformed;
            _triggerActionRef.action.canceled += TriggerActionCanceled;

            _gripActionRef.action.performed += GripActionPerformed;
            _gripActionRef.action.canceled += GripActionCanceled;
        }

        private void OnDisable()
        {
            _triggerActionRef.action.performed -= TriggerActionPerformed;
            _triggerActionRef.action.canceled -= TriggerActionCanceled;

            _gripActionRef.action.performed -= GripActionPerformed;
            _gripActionRef.action.canceled -= GripActionCanceled;
        }

        private void TriggerActionPerformed(InputAction.CallbackContext obj) =>
            _handAnimator.SetFloat(TriggerAnimation, 1);

        private void GripActionPerformed(InputAction.CallbackContext obj) => _handAnimator.SetFloat(GripAnimation, 1);

        private void TriggerActionCanceled(InputAction.CallbackContext obj) =>
            _handAnimator.SetFloat(TriggerAnimation, 0);

        private void GripActionCanceled(InputAction.CallbackContext obj) => _handAnimator.SetFloat(GripAnimation, 0);
    }
}