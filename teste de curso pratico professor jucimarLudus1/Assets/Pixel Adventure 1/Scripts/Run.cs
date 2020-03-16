using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Run : MonoBehaviour
    
{
    

    public GameObject Player;
    public Animator run;
    public float velocity;
    public static bool IsGrounded = false;
    




    private float time = 0f;
    private float time2 = 0f;
    private Transform player;
    private int cont;
    private Rigidbody2D astroneerRB;
    private Vector2 scaleChange;
    private Vector2 scaleChange2;
    



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        run = GetComponent<Animator>();
        astroneerRB = transform.GetComponent<Rigidbody2D>();
        scaleChange = new Vector2(-0.112f, 0.112f);
        scaleChange2 = new Vector2(0.112f, 0.112f);
       




    }


    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            cont++;

        }
        if(cont > 0 && astroneerRB.velocity.y == 0)
        {
            time += Time.deltaTime;
            if(time > 1)
            {
                cont = 0;
                time = 0;
            }
            if (cont == 2 && time <= 1)
            {
                time2 += Time.deltaTime;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                if (time2 >= 0.3f)
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    
                    transform.gameObject.SetActive(true);
                    tp();
                    float jumpVelocity = 0.1f;
                    astroneerRB.velocity = Vector2.up * jumpVelocity;
                    run.SetBool("Jumping", true);
                    time = 0;
                    cont = 0;
                    time2 = 0;

                }
                
            }
        }
      

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(Vector2.right * velocity);
            run.SetBool("Run", true);
            Player.transform.localScale = scaleChange2;


        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            run.SetBool("Run", false);
        }

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Translate(Vector2.left * velocity);
            run.SetBool("Run", true);
            Player.transform.localScale = scaleChange;
            


        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            run.SetBool("Run", false);
        }

        if (astroneerRB.velocity.y < 0)
        {
            run.SetBool("Jumping", false);
            run.SetBool("Fall", true);
        }
        else
        {
            run.SetBool("Fall", false);
        }

        
            



    }
    private void tp()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
