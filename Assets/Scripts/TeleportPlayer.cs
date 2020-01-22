using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _tpPos;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("PlayerController");
    }

    public void Teleport()
    {
        _player.transform.position = _tpPos.transform.position;
    }
}
