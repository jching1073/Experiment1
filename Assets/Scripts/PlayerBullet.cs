using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 7.5f;
    [SerializeField] private Rigidbody2D theRB;
    [SerializeField] GameObject impactEffect;
    [SerializeField] int damageToGive = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) //
    {
        if (other.tag != "Player" && other.tag !="Confiner" && other.tag != "PlayerBullet")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Destroyed by" + other);

           if (other.tag == "Enemy")
            {
                other.GetComponent<EnemyFollow>().DamageEnemy(damageToGive);
            }

        }
       
       
    }

    private void OnBecameInvisible() //destroy bullet after a while
    {
        Destroy(gameObject);
    }
}
