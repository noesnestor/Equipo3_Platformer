using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int saludEnemigo; // Salud del enemigo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Metodo Collider2D de la clase Enemy que le quita vida al enemigo, si coliciona cuntra una bala
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Bullet") 
        {
            Bullet bullet = other.GetComponent<Bullet>();
            saludEnemigo -= bullet.damageEnemy;
            if (saludEnemigo <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
