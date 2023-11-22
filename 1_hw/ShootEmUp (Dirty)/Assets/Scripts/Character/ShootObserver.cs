using UnityEngine;

namespace ShootEmUp
{
    public sealed class ShootObserver : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private WeaponComponent weaponComponent;

        private void OnEnable()
        {
            inputManager.OnShootListener += weaponComponent.Shoot;
        }

        private void OnDisable()
        {
            inputManager.OnShootListener -= weaponComponent.Shoot;
        }
    }
}