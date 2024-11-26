using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace VRDuelShooter.Scripts.Weapon
{
    public class Bullet : NetworkBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody _rigidbody;
        
        private float _lifetime = 5f;
        private float _timeAlive = 0f;
        private int _damage;

        public void Initialize(Vector3 direction, int damage, float lifeTime)
        {
            _lifetime = lifeTime;
            _damage = damage;
            _rigidbody.AddForce(direction.normalized * _speed, ForceMode.Impulse);
        }

        public override void FixedUpdateNetwork()
        {
            _timeAlive += Runner.DeltaTime;

            if (_timeAlive >= _lifetime)
            {
                if (Object.HasStateAuthority)
                {
                    Runner.Despawn(Object);
                }
                return;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            
        }
    }
}