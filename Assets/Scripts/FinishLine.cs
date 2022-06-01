using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameObject _gate;

    void Awake()
    {
        _gate = GameObject.Find("Gate");
        if (_gate == null)
        {
            Debug.LogError("Gate is null on Finish Line!");
        }
    }

    void Start()
    {
        _gate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Finish Line Logic
        if (gameObject.name == "Finish_Line")
        {
            if (other.tag == "Player" || other.tag == "Enemy")
            {
                _gate.SetActive(true);
                if (other.tag == "Player")
                {
                    Player player = other.GetComponent<Player>();
                    player.Stop();
                }
                else if (other.tag == "Enemy")
                {
                    Enemy enemy = other.GetComponent<Enemy>();
                    enemy.Stop();
                }
            }
            else if (other.tag == "Laser")
            {
                Destroy(other.gameObject);
            }
        }
        #endregion

        #region Gate Logic
        else if (gameObject.name == "Gate")
        {
            if (other.tag == "Player")
            {
                Player player = other.GetComponent<Player>();
                player.Stop();
            }
            else if (other.tag == "Enemy")
            {
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.Stop();
            }
            else if (other.tag == "Laser")
            {
                Destroy(other.gameObject);
            }
        }
        #endregion
    }
}