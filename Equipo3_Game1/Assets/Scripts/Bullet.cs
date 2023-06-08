using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rd;
    public float Speed;

    public  int damageEnemy;
    public  int damageObstacle;
    // Start is called before the first frame update
    void Start()
    {
        Rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rd.velocity = transform.right * Speed;
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }

}
