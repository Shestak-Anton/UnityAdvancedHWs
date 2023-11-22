using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveObserver : MonoBehaviour
    {
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private InputManager inputManager;

        private void OnEnable()
        {
            inputManager.OnPositionChangedListener += moveComponent.MoveByRigidbodyVelocity;
        }

        private void OnDisable()
        {
            inputManager.OnPositionChangedListener -= moveComponent.MoveByRigidbodyVelocity;
        }
        
    }
}