using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using VRDuelShooter.Scripts.Weapon.WeaponSO;

namespace VRDuelShooter.Scripts.Weapon
{
    public class Weapon : NetworkBehaviour
    {

        [SerializeField] protected NetworkPrefabRef BulletPrefab;
        [SerializeField] protected Transform ShootPoint;
        [SerializeField] private WeaponConfig _weaponConfig;

        private float _lastShootTime = 0f;
        private int _currentAmmo;
        
        [Networked, OnChangedRender(nameof(OnAmmoCountChangedMethod))]
        protected int CurrentAmmo
        {
            get => _currentAmmo;
            set
            {
                if (_currentAmmo != value)
                {
                    _currentAmmo = value;
                    OnAmmoChanged?.Invoke(_currentAmmo, _weaponConfig.MaxAmmo);
                }
            }
        }
        
        public event Action<int, int> OnAmmoChanged;


        public override void Spawned()
        {
            CurrentAmmo = _weaponConfig.MaxAmmo;
        }

        public virtual void Shoot()
        {
            if (!Object.HasStateAuthority) return;

            if (CurrentAmmo <= 0)
            {
                Debug.Log("Out of ammo!");
                return;
            }

            if (CanShoot())
            {
                int bulletsCountPerShot = _weaponConfig.BulletsPerShot;
                if (CurrentAmmo < _weaponConfig.BulletsPerShot)
                {
                    bulletsCountPerShot = CurrentAmmo;
                }

                CurrentAmmo = Mathf.Clamp(CurrentAmmo - bulletsCountPerShot, 0, _weaponConfig.MaxAmmo);

                for (int i = 0; i < bulletsCountPerShot; i++)
                {
                    SpawnBullet();
                }

                _lastShootTime = Time.time;
            }
        }

        public void AddAmmo(int ammo)
        {
            CurrentAmmo = Mathf.Clamp(CurrentAmmo + ammo, 0, _weaponConfig.MaxAmmo);
        }

        protected virtual void SpawnBullet()
        {
            Vector3 position = ShootPoint.position;
            Quaternion rotation = Quaternion.LookRotation(ShootPoint.forward);
            
            NetworkObject bullet = Runner.Spawn(
                BulletPrefab, position, rotation, Object.InputAuthority, 
                (runner, spawnedBullet) =>
                {
                    Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();
                    bulletScript.Initialize(ShootPoint.forward, _weaponConfig.Damage, _weaponConfig.BulletLifetime);
                });
        }

        private bool CanShoot()
        {
            return Time.time >= _lastShootTime + _weaponConfig.ShootCooldown;
        }

        private void OnAmmoCountChangedMethod()
        {
            OnAmmoChanged?.Invoke(CurrentAmmo, _weaponConfig.MaxAmmo);
        }
    }
}