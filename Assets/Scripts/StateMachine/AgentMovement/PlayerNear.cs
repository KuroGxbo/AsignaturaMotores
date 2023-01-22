using UnityEngine;

public class PlayerNear : Condition
{
    public GameObject _player;
    public GameObject _npc;
    public float _minDistance;

    public PlayerNear(GameObject player, GameObject npc, float minDistance)
    {
        _player = player;
        _npc = npc;
        _minDistance = minDistance;
    }

    public override bool Check()
    {
        float distance = Vector3.Distance(_player.transform.position, _npc.transform.position);
        Debug.Log(distance);
        return distance <= _minDistance;
    }
}
