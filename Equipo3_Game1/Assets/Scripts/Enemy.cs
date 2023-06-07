using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int saludEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Bullet") 
        {
            saludEnemigo -= Bullet.damageEnemy;
            if (saludEnemigo <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
