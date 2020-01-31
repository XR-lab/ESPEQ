using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _tpPos;
    public GameObject _player;

    private void OnTriggerStay(Collider _coll)
    {
        if (_coll.gameObject.layer == 10 && GetComponent<InputInteract>().GetInput())
        {
            Teleport(_player);
        }
    }

    public void Teleport(GameObject _player)
    {
        _player.transform.position = _tpPos.transform.position;
        _player.transform.rotation = _tpPos.transform.rotation;
    }
}
