using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleState : State
{
    GameObject _player;
    CharacterController _playerController;
    Animator _animation;
    Vector3 _VerticalSpeed;
    float _SpeedLab, _RotationSpeed, _gravity;
    PauseMenu _menu;

    public IdleState(GameObject player, CharacterController playerController, Animator animation, Vector3 verticalSpeed, float speedLab, float rotationSpeed, float gravity, PauseMenu menu)
    {
        _player = player;
        _playerController = playerController;
        _animation = animation;
        _VerticalSpeed = verticalSpeed;
        _SpeedLab = speedLab;
        _RotationSpeed = rotationSpeed;
        _gravity = gravity;
        _menu = menu;
    }

    public override void DoAction()
    {
        if (!_menu.EstadoMenu)
        {
            _VerticalSpeed += Physics.gravity * _gravity;
            _playerController.Move(_VerticalSpeed * _SpeedLab * Time.deltaTime);
            _animation.SetFloat("speed", 0);
            switch (SceneManager.GetActiveScene().name)
            {
                case "LevelLaberinth":
                    rotationMouse();
                    break;
                case "Level1":
                    rotationMouse();
                    break;
            }
        } else
        {
            _animation.SetFloat("speed", 0);
        }

    }

    private void rotationMouse()
    {
        float rotX = Input.GetAxis("Mouse X") * _RotationSpeed * Mathf.Deg2Rad;
        _player.transform.RotateAround(Vector3.up, rotX);
    }
}
