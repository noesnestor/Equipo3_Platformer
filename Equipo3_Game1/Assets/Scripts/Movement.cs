using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float fuerzaSalto;
    [SerializeField] LayerMask suelo;
    [SerializeField] float velocidadSlide;
    private bool facingRight;
    private Rigidbody2D personaje;

    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            personaje.velocity = new Vector2(-1f*velocidad,personaje.velocity.y);
            facingRight = false;
        }
        

        else if(Input.GetKey(KeyCode.D)){
           personaje.velocity = new Vector2(1f*velocidad,personaje.velocity.y); 
           facingRight = true;
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo()){
            personaje.AddForce(Vector2.up*fuerzaSalto,ForceMode2D.Impulse);
        }

        //Slide
        if(Input.GetKeyDown(KeyCode.LeftControl) && estaEnElSuelo()){
            if(facingRight){
                personaje.AddForce(Vector2.right*velocidadSlide,ForceMode2D.Impulse);
            }
            else if (!facingRight){
                personaje.AddForce(Vector2.left*velocidadSlide,ForceMode2D.Impulse);
            }
        }
    }

    private bool estaEnElSuelo(){
        RaycastHit2D lineaAlSuelo = Physics2D.BoxCast(boxCollider.bounds.center,new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y),0f,Vector2.down,0.2f,suelo);
        return lineaAlSuelo.collider!=null;
    }
}
