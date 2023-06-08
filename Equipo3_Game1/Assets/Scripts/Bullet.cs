using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rd;
    public float Speed;

    public  int damageEnemy; // Daño de la bala para el enemigo
    public  int damageObstacle; // Daño de la bala para un obstaculo

    // Start is called before the first frame update
    void Start()
    {
        Rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rd.velocity = transform.right * Speed; // Direccion de la bala
        Destroy(gameObject, 5f); // Destulle la bala si no coliciona contara un objeto
    }

    /// <summary>
    /// Metodo del Collider2D de la clase Bullet que destulle la bala cuando colisiona con un 
    /// objeto que tenga una tag diferente a la del personaje
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }

}
