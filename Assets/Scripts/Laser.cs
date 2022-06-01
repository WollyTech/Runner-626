using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("other doesn't contain Character Controller!");
            }

            player.Stop();
            Destroy(other.GetComponent<MeshRenderer>(), 2.0f);
            Destroy(other.gameObject, 2.1f);
        } 
        else if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy == null)
            {
                Debug.LogError("other doesn't contain Character Controller!");
            }

            enemy.Stop();
            Destroy(other.gameObject, 2.0f);
        }
    }
}
