using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementCondition : Condition
{
    PauseMenu _menu;

    public PlayerMovementCondition(PauseMenu menu)
    {
        _menu = menu;
    }

    public override bool Check()
    {
        if (!_menu.EstadoMenu)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "LevelRunner":
                    return !_menu.EstadoMenu;
                case "LevelLaberinth":
                    return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
                case "Level1":
                    return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
                default: return false;
            }
        }
        return false;
    }
}
