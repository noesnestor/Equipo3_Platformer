using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float fuerzaSalto;
    [SerializeField] LayerMask suelo;
    private Rigidbody2D personaje;
    private float horizontalInput;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        personaje.velocity = new Vector2(horizontalInput*velocidad,personaje.velocity.y);
        if(Input.GetKeyDown(KeyCode.UpArrow) && estaEnElSuelo()){
            personaje.AddForce(Vector2.up*fuerzaSalto,ForceMode2D.Impulse);
        } 
    }

    private bool estaEnElSuelo(){
        RaycastHit2D lineaAlSuelo = Physics2D.BoxCast(boxCollider.bounds.center,new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y),0f,Vector2.down,0.2f,suelo);
        return lineaAlSuelo.collider!=null;
    }
}
