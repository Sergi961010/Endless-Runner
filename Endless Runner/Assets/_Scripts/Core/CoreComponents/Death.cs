using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class Death : BaseCoreComponent
    {
        private readonly PlayerAnimator _playerAnimator;
        private PlayerAnimator PlayerAnimator
        {
            get => _playerAnimator != null ? _playerAnimator : Core.GetCoreComponent<PlayerAnimator>();
        }
        private readonly Movement _movement;
        private Movement Movement
        {
            get => _movement != null ? _movement : Core.GetCoreComponent<Movement>();
        }
        private readonly InputController _inputController;
        private InputController InputController
        {
            get => _inputController != null ? _inputController : Core.GetCoreComponent<InputController>();
        }
        private readonly SpriteRendererComponent _spriteRendererComponent;
        private SpriteRendererComponent SpriteRendererComponent
        {
            get => _spriteRendererComponent != null ? _spriteRendererComponent : Core.GetCoreComponent<SpriteRendererComponent>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : Core.GetCoreComponent<StateMachineComponent>();
        }
        [SerializeField] private AnimationClip _animationClip;
        public UnityEvent DeathEvent;
        public IEnumerator Die()
        {
            InputController.DisableInput();
            StateMachine.gameObject.SetActive(false);
            Movement.Rigidbody.isKinematic = true;
            Movement.gameObject.SetActive(false);
            PlayerAnimator.PlayAnimation(_animationClip);
            yield return new WaitForSeconds(_animationClip.length);
            SpriteRendererComponent.gameObject.SetActive(false);
            DeathEvent.Invoke();
        }
    }
}