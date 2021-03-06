﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class Run : MonoBehaviour
    
{
    
    //variaveis publicas
    public GameObject Player;
    public Animator run;
    public float velocity;
    public static bool IsGrounded = false;
    public GameObject tpCircle;
    public Camera cameraPosicao;
    public Rigidbody2D rb;
    public Rigidbody2D rbBaziyo;




    //variaveis privadas
    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float time4 = 0f;
    private Transform player;
    private int count;
    private Rigidbody2D baziyoRB;
    private Vector2 scaleChange;
    private Vector2 scaleChange2;

    private bool movingRight;
    private bool movingLeft;
    private GameObject backGround;
    private Vector3 positionOfPlayer;
    private float posX;
    private float posY;
    

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tpCircle = GameObject.FindGameObjectWithTag("TPCircle");
        backGround = GameObject.FindGameObjectWithTag("TpArea");
        


        run = GetComponent<Animator>();
        baziyoRB = transform.GetComponent<Rigidbody2D>();
        scaleChange = new Vector2(-0.16f, 0.16f);
        scaleChange2 = new Vector2(0.16f, 0.16f);
        


    }


    void Update()
    {
        
        Vector3 maxDis = new Vector3 (1f,1f,0);
        //positionOfPlayer = transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            count++;
        }


        //ve se o personagem esta parado e se o player clicou na tela
        if(count > 0 && baziyoRB.velocity.y == 0)
        {
            time += Time.deltaTime;
            if(time > 0.4f)
            {
                count = 0;
                time = 0;
                
            }
            //verifica se deu dois cliques na tela no espaco de tempo setado
            if (count == 2 && time <= 0.6f )
            {
                posX = cameraPosicao.ScreenToWorldPoint(Input.mousePosition).x - rbBaziyo.position.x;
                posY = cameraPosicao.ScreenToWorldPoint(Input.mousePosition).y - rbBaziyo.position.y;
                
                if(posX <= maxDis.x && posY <= maxDis.y && posY >= -0.98f && posX >= -0.98f)
                {

                    
                    tp();
                    float jumpVelocity = 0.1f;
                    baziyoRB.velocity = Vector2.up * jumpVelocity;
                    //run.SetBool("Jumping", true);
                    time = 0;
                    count = 0;
                    
                }
                
            }
        }
        


        
        //verifica se o botao clicado foi o que faz o personagem andar pra direita


        if (!movingLeft && !movingRight)
        {
            run.SetBool("Running", false);
        }
        //verifica se o botao clicado foi o que faz o personagem andar pra esquerda
        if (movingLeft)
        {

            time3 += Time.deltaTime;
            if (time3 > 0.097f)
            {
                run.SetBool("Running", true);
                rb.velocity = new Vector2(-2.0f,rb.velocity.y);
                Player.transform.localScale = scaleChange;

            }
        


        }
        else if(!movingLeft)
        {
            
            time3 = 0;
        }
        
        
        if (movingRight)
        {
            time4 += Time.deltaTime;
            if (time4 > 0.097f)
            {
                rb.velocity = new Vector2(2.0f , rb.velocity.y);
                run.SetBool("Running", true);
                Player.transform.localScale = scaleChange2;
                

            }

        }
        else if (!movingRight)
        {
            time4 = 0;
            
            
        }
        
      
    }
    
    
    
    
    //funcao de teleporte
    private void tp()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      

    }

    //verifica se a pessoa ainda esta apertando o botao na tela
    public void MovementRight(bool active)
    {
        movingRight = active;

    }

    //verifica se a pessoa ainda esta apertando o botao na tela
    public void MovimentLeft(bool active)
    {
        movingLeft = active;
    }

    

}
