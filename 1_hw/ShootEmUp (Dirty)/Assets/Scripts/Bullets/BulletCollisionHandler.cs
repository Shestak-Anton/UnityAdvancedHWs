using System;
using LifeCycle;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletCollisionHandler : MonoBehaviour,
        ILifeCycle.IDisableListener,
        ILifeCycle.IEnableListener
    {
        public event Action<BulletComponent> OnBulletCollided;

        [SerializeField] private BulletComponent _bullet;

        void ILifeCycle.IEnableListener.OnEnable()
        {
            _bullet.OnCollisionEntered += OnBulletCollision;
        }

        void ILifeCycle.IDisableListener.OnDisable()
        {
            _bullet.OnCollisionEntered -= OnBulletCollision;
        }

        private void OnBulletCollision(BulletComponent bulletComponent, Collision2D collision)
        {
            TryDealDamage(collision.gameObject, bulletComponent.BulletData.Damage);
            OnBulletCollided?.Invoke(bulletComponent);
        }

        private static void TryDealDamage(GameObject collidedGo, int damage)
        {
            if (collidedGo.TryGetComponent(out HitPointsComponent hitPointsComponent))
            {
                hitPointsComponent.TakeDamage(damage);
            }
        }
    }
}