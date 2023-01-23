using UnityEngine;

public class PlayerFar : Condition
{
    public GameObject _player;
    public GameObject _npc;
    public float _minDistance;
    PauseMenu _menu;

    public PlayerFar(GameObject player, GameObject npc, float minDistance, PauseMenu menu)
    {
        _player = player;
        _npc = npc;
        _minDistance = minDistance;
        _menu = menu;
    }

    public override bool Check()
    {
        float distance = Vector3.Distance(_player.transform.position, _npc.transform.position);
        return distance > _minDistance && !_menu.EstadoMenu;
    }
}
