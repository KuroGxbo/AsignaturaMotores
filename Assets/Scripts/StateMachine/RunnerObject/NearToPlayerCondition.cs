using UnityEngine;

public class NearToPlayerCondition : Condition
{
    GameObject _player;
    GameObject _npc;
    float _minDistance;

    public NearToPlayerCondition(GameObject player, GameObject npc, float minDistance)
    {
        _player = player;
        _npc = npc;
        _minDistance = minDistance;
    }

    public override bool Check()
    {
        return Vector3.Distance(_npc.transform.position, _player.transform.position) <= _minDistance;
    }
}
