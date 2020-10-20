using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 7.5f;
    private Vector3 direction;

    

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other) //
    {
        if(other.tag == "Player")
        {

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
