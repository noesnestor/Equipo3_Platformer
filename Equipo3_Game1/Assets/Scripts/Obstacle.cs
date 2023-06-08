using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int vidaObstaculo;

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
            Bullet bullet = other.GetComponent<Bullet>();
            vidaObstaculo -= bullet.damageObstacle;
            if (vidaObstaculo <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
