using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNotRunningAndWalkingCondition : Condition
{
    PauseMenu _menu;

    public PlayerNotRunningAndWalkingCondition(PauseMenu menu)
    {
        _menu = menu;
    }

    public override bool Check()
    {
        if (!_menu.EstadoMenu)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "LevelLaberinth":
                    return !Input.GetKey(KeyCode.LeftShift) && !(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
                case "Level1":
                    return !Input.GetKey(KeyCode.LeftShift) && !(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);
                default: return false;
            }
        }
        return true;
    }
}
