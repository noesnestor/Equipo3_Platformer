using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int vidaObstaculo; // Vide dal obstaculo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Metodo Collider2D de la clase Obstacle que le quita vida al obstaculo si coliciona cuntra una bala
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
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
