using LifeCycle;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveObserver : MonoBehaviour,
        ILifeCycle.IEnableListener,
        ILifeCycle.IDisableListener
    {
        [SerializeField] private EnemyMoveAgent _enemyMoveAgent;
        [SerializeField] private EnemyAttackAgent _enemyAttackAgent;

        void ILifeCycle.IEnableListener.OnEnable()
        {
            _enemyMoveAgent.OnDestinationReachedListener += _enemyAttackAgent.EnableAttacking;
        }

        void ILifeCycle.IDisableListener.OnDisable()
        {
            _enemyMoveAgent.OnDestinationReachedListener -= _enemyAttackAgent.EnableAttacking;
        }
    }
}