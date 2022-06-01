using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    GameObject _player, _laser;
    MeshRenderer _playerRenderer;

    private Vector3 _offset = new Vector3(8, 2, -12);

    void Start()
    {
        #region Get Component
        _player = GameObject.Find("Player");
        _laser = GameObject.Find("Laser");
        _playerRenderer = _player.GetComponent<MeshRenderer>();
        #endregion

        #region Null Check
        if (_player == null)
        {
            Debug.LogError("Player game object not found on Camera!");
        }
        if (_laser == null)
        {
            Debug.LogError("Laser game object not found on Camera!");
        }
        if (_playerRenderer == null)
        {
            Debug.LogError("Player's mesh rendere not assigned on Camera!");
        }
        #endregion
    }


    void Update()
    {
        if (_playerRenderer != null)
        {
            transform.position = _player.transform.position + _offset;
            transform.parent = _player.transform;
        }
        else
        {
            transform.position = _laser.transform.position + _offset;
            transform.parent = _laser.transform;
        }
    }
}
