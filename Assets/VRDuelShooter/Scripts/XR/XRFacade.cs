using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRDuelShooter.Scripts.XR
{
    public class XRFacade : MonoBehaviour
    {
        [field: SerializeField] public Transform HeadTransform { get; private set; }
        [field: SerializeField] public Transform LeftHandTransform { get; private set; }
        [field: SerializeField] public Transform RightHandTransform { get; private set; }
        [field: SerializeField] public Transform BodyTransform { get; private set; }
    }
}