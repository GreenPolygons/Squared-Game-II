using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanBullet : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<HealthManager>().LoseHealth(damage, 1f);
            other.gameObject.GetComponent<PlayerMovement>().FrozePlayer();
        }

        Destroy(gameObject);
    }
}
