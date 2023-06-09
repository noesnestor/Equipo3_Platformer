using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D personaje;
    [SerializeField] LayerMask suelo;
    private enum State {
        Normal,
        Sliding
    }
    private State state;
    private Vector2 ultimoMoveDirection;
    private Vector2 moveDirection;
    [SerializeField] float velocidad;
    [SerializeField] float fuerzaSalto;
    [SerializeField] float velocidadSlide;
    private Vector2 slideDirection;
    private Vector2 aimDirection;
    private bool dashUsado;
    [SerializeField] float distanciaDash;
    [SerializeField] float cooldownDash;
    private float baseGravity;
    void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        dashUsado = false;
        state = State.Normal;
        baseGravity = personaje.gravityScale;
    }
     void Update() {
        switch (state){
            case State.Normal:
                float inputX = 0f;
                float inputY = 0f;

                if(Input.GetKey(KeyCode.W))
                    inputY = +1f;
                else if(Input.GetKey(KeyCode.S))
                    inputY = -1f;
                else if(Input.GetKey(KeyCode.A))
                    inputX = -1f;
                else if(Input.GetKey(KeyCode.D))
                    inputX = +1f;

            moveDirection = new Vector2(inputX,0f).normalized;
            aimDirection = new Vector2(inputX,inputY).normalized;
            if(inputX !=0){
                //en Movimiento
                ultimoMoveDirection = new Vector2(inputX,0f);
            }

            //Slide
            if(Input.GetKeyDown(KeyCode.LeftControl) && estaEnElSuelo()){
                velocidadSlide = 20f;
                slideDirection = ultimoMoveDirection;
                state = State.Sliding;
            }

            //Jump
            if(Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo()){
                moveDirection.y = 1f;
            }

            break;
            case State.Sliding:
                float reducirVelocidadSlide = 10f;
                velocidadSlide -= reducirVelocidadSlide * Time.deltaTime;

                float minimaVelocidadSlide = 12f;
                if (velocidadSlide < minimaVelocidadSlide){
                    state = State.Normal;
                }
                break;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(state){
            case State.Normal:
                personaje.velocity = moveDirection*velocidad;

                if(moveDirection.y == 1f){
                    personaje.AddForce(Vector2.up*fuerzaSalto,ForceMode2D.Impulse);
                }

                if(dashUsado){
                    personaje.transform.position = new Vector2();
                    dashUsado = false;
                }
                break;
            case State.Sliding:
                personaje.velocity = slideDirection * velocidadSlide;
                break;
        }
       
        
    }

    private bool estaEnElSuelo(){
        RaycastHit2D lineaAlSuelo = Physics2D.BoxCast(boxCollider.bounds.center,new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y),0f,Vector2.down,0.2f,suelo);
        return lineaAlSuelo.collider!=null;
    }
}
