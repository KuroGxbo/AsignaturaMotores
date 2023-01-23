using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSimpleJump : State
{
    CharacterController _playerController;
    Animator _animation;
    Vector3 _VerticalSpeed;
    float _jumpStrenght, _Speed,_gravity;
    PauseMenu _menu;

    public PlayerSimpleJump(CharacterController playerController, Animator animation, Vector3 verticalSpeed, float gravity, float speed, PauseMenu menu, float jumpStrength)
    {
        _playerController = playerController;
        _animation = animation;
        _VerticalSpeed = verticalSpeed;
        _Speed = speed;
        _gravity = gravity;
        _menu = menu;
        _jumpStrenght = jumpStrength;
    }

    public override void DoAction()
    {
        if (!_menu.EstadoMenu)
        {
            _VerticalSpeed += Physics.gravity * _gravity;
            jump();
            _playerController.Move(_VerticalSpeed * _Speed * Time.deltaTime);
        }

    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _playerController.isGrounded)
        {
            _VerticalSpeed = _jumpStrenght * Vector3.up;
            _animation.SetBool("jumping", true);
        }
        else if (!_playerController.isGrounded)
        {
            _animation.SetBool("jumping", false);
        }
    }
}
