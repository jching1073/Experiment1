using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float speed = 7.5f;
    private Vector3 direction;



    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other) //
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
        if (other.tag != "Enemy" && other.tag != "Confiner" && other.tag != "EnemyBullet")
        {
            //Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Destroyed by" + other);

        }


    }

    private void OnBecameInvisible() //destroy bullet after a while
    {
        Destroy(gameObject);
    }
}
