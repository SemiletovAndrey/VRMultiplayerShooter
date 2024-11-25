using Unity.XR.CoreUtils;
using UnityEngine;
using VRDuelShooter.Scripts.XR;
using Zenject;

namespace VRDuelShooter.Scripts.ZenjectInstallers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private XRFacade _xrFacade;
        
        public override void InstallBindings()
        {
            Container.Bind<XRFacade>().FromInstance(_xrFacade).AsSingle();
        }
    }
}