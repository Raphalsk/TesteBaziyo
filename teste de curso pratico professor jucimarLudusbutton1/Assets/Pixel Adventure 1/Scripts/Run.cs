using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Run : MonoBehaviour
    
{
    

    public GameObject Player;
    public Animator run;
    public float velocity;
    public static bool IsGrounded = false;
    




    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float time4 = 0f;
    private Transform player;
    private int count;
    private Rigidbody2D baziyoRB;
    private Vector2 scaleChange;
    private Vector2 scaleChange2;
    private Button buttonRight;
    private Button buttonLeft;
    private bool movingRight;
    private bool movingLeft;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
        run = GetComponent<Animator>();
        baziyoRB = transform.GetComponent<Rigidbody2D>();
        scaleChange = new Vector2(-0.112f, 0.112f);
        scaleChange2 = new Vector2(0.112f, 0.112f);
       




    }


    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            count++;
           

        }


        //ve se o personagem esta parado e se o player clicou na tela
        if(count > 0 && baziyoRB.velocity.y == 0)
        {
            time += Time.deltaTime;
            if(time > 0.3f)
            {
                count = 0;
                time = 0;
            }
            //verifica se deu dois cliques na tela no espaco de tempo setado
            if (count == 2 && time <= 1)
            {
                time2 += Time.deltaTime;
                transform.gameObject.SetActive(true);
                tp();
                float jumpVelocity = 0.1f;
                baziyoRB.velocity = Vector2.up * jumpVelocity;
                run.SetBool("Jumping", true);
                time = 0;
                count = 0;
                time2 = 0;
            }
        }



        //verifica se o botao clicado foi o que faz o personagem andar pra direita
        if (movingRight)
        {
            time4 += Time.deltaTime;
            if (time4 > 0.08f)
            {
                transform.Translate(Vector2.right * velocity);
                run.SetBool("Run", true);
                Player.transform.localScale = scaleChange2;

            }




        }
        else
        {
            run.SetBool("Run", false);
            time4 = 0;
        }

        //verifica se o botao clicado foi o que faz o personagem andar pra esquerda
        if (movingLeft)
        {

            time3 += Time.deltaTime;
            if (time3 > 0.08f)
            {
                transform.Translate(Vector2.left * velocity);
                run.SetBool("Run", true);
                Player.transform.localScale = scaleChange;

            }



        }
        else
        {
            run.SetBool("Run", false);
            time3 = 0;
        }

        //ativa a animacao de fall
        if (baziyoRB.velocity.y < 0)
        {
            run.SetBool("Jumping", false);
            run.SetBool("Fall", true);
        }
        else
        {
            run.SetBool("Fall", false);
        }
        
        
            



    }
    //funcao de teleporte
    private void tp()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //verifica se a pessoa ainda esta apertando o botao na tela
    public void MovementRigth(bool active)
    {
        movingRight = active;

    }

    //verifica se a pessoa ainda esta apertando o botao na tela
    public void movimentLeft(bool active)
    {
        movingLeft = active;
    }


}
