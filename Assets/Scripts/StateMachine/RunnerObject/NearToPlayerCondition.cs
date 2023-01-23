using UnityEngine;

public class NearToPlayerCondition : Condition
{
    GameObject _player;
    GameObject _npc;
    float _minDistance;
    PauseMenu _menu;

    public NearToPlayerCondition(GameObject player, GameObject npc, float minDistance, PauseMenu menu)
    {
        _player = player;
        _npc = npc;
        _minDistance = minDistance;
        _menu = menu;
    }

    public override bool Check()
    {
        return Vector3.Distance(_npc.transform.position, _player.transform.position) <= _minDistance || _menu.EstadoMenu;
    }
}
