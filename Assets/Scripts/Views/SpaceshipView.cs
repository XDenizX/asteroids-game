using Base;
using Interfaces;
using Presenters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Views
{
    public class SpaceshipView : BaseView<SpaceshipPresenter>
    {
        [SerializeField] private InputActionAsset spaceshipActions;
        [SerializeField] private SpriteRenderer flameSprite;
        
        public void SetFlame(float speed)
        {
            Color color = flameSprite.color;
            color = new Color(color.r, color.g, color.b, speed);
            flameSprite.color = color;
            flameSprite.transform.localScale = new Vector3(1f, 1 + speed * 2);
        }
        
        private void Awake()
        {
            spaceshipActions["Move"].performed += OnMove;
            spaceshipActions["Move"].canceled += OnMoveCancel;
            spaceshipActions["Shoot"].performed += OnShoot;
            spaceshipActions["TurnLeft"].performed += OnTurnLeft;
            spaceshipActions["TurnRight"].performed += OnTurnRight;
            spaceshipActions["TurnLeft"].canceled += OnRotateCancel;
            spaceshipActions["TurnRight"].canceled += OnRotateCancel;
            spaceshipActions["ChangeWeapon"].performed += OnChangeWeapon;
            
            spaceshipActions.Enable();
        }

        private void OnDestroy()
        {
            spaceshipActions["Move"].performed -= OnMove;
            spaceshipActions["Move"].canceled -= OnMoveCancel;
            spaceshipActions["Shoot"].performed -= OnShoot;
            spaceshipActions["TurnLeft"].performed -= OnTurnLeft;
            spaceshipActions["TurnRight"].performed -= OnTurnRight;
            spaceshipActions["TurnLeft"].canceled -= OnRotateCancel;
            spaceshipActions["TurnRight"].canceled -= OnRotateCancel;
            spaceshipActions["ChangeWeapon"].performed -= OnChangeWeapon;
            
            spaceshipActions.Disable();
        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            Presenter.OnMoveKeyPressed();
        }
        
        private void OnMoveCancel(InputAction.CallbackContext obj)
        {
            Presenter.OnMoveKeyReleased();
        }
        
        private void OnTurnLeft(InputAction.CallbackContext obj)
        {
            Presenter.OnLeftKeyPressed();
        }

        private void OnTurnRight(InputAction.CallbackContext obj)
        {
            Presenter.OnRightKeyPressed();
        }
        
        private void OnShoot(InputAction.CallbackContext obj)
        {
            Presenter.OnShootKeyPressed();
        }
        
        private void OnRotateCancel(InputAction.CallbackContext obj)
        {
            Presenter.OnRotateKeyReleased();
        }
        
        private void OnChangeWeapon(InputAction.CallbackContext obj)
        {
            Presenter.OnChangeWeaponKeyPressed();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isCosmicBody = collision.TryGetComponent(out ICosmicBodyView _);
            if (!isCosmicBody)
                return;

            Presenter.OnDamage();
        }
    }
}