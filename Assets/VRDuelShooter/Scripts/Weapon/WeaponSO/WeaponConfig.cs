using UnityEngine;

namespace VRDuelShooter.Scripts.Weapon.WeaponSO
{
    [CreateAssetMenu(fileName ="WeaponSettings", menuName = "StaticData/Weapon Settings Data")]
    public class WeaponConfig : ScriptableObject
    {
        public float BulletLifetime = 2.0f;
        public int Damage = 10;
        public int BulletsPerShot = 1;
        public int MaxAmmo = 30;
        public float ShootCooldown = 1f;
    }
}