using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Shoot
    public GameObject Stick;
    public float ShootForce = 5f;
    bool shoot;

    private bool isToching;
    public Transform PlatformCheck;
    public float checkradius;
    public LayerMask whatIsTouch;

    //Movement
    public float Speed = 5f;
    private float moveInput;
    private Vector3 moveing;
    private Rigidbody2D rb2d;

    //  DownCheck
    private bool isDownCheck;
    public Transform DownCheck;

    bool triger;

    public Collider2D collisio;

    //Audio
    private AudioSource source;
    public AudioClip Shootsound;


    //Animation
    private Animator anim;
    private bool isRight = true;



    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triger");
        triger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        triger = false;
    }

    private void FixedUpdate()
    {
        isToching = Physics2D.OverlapCircle(PlatformCheck.position, checkradius, whatIsTouch);
        Vector2 stickPosition = Stick.transform.position;
        Vector2 mousrPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Direction = mousrPosition - stickPosition;
        Stick.transform.right = -Direction;
        if (Input.GetMouseButtonDown(0) && isToching == true && triger == true)
        {
            source.clip = Shootsound;
            source.Play();
            Shoot();
            shoot = true;
            moveing = Stick.transform.right * ShootForce;
            triger = false;
            anim.SetFloat("Speed", 0);
            anim.SetFloat("moving", 0);

        }
        else { moveing.y = 0f; shoot = false; }

        isDownCheck = Physics2D.OverlapCircle(DownCheck.position, checkradius, whatIsTouch);



        moveInput = Input.GetAxis("Horizontal");


        if (triger == true && shoot != true)
        {
            moveing.x = 0;
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveing.x, moveing.y);
            if (isDownCheck == false)
            {
                anim.SetFloat("Speed", 0);
                anim.SetFloat("moving", 0);
            }
        }

        if (isDownCheck == true && triger == true && shoot != true)
        {
            moveing.x = moveInput * Speed;
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveing.x, moveing.y);
            anim.SetFloat("Speed", moveInput);
            anim.SetFloat("moving", Mathf.Abs(moveInput));
        }


        if (moveing.x > 0)
        {
            isRight = true;

        }
        else
        {
            if (moveing.x < 0)
            {
                isRight = false;
            }
        }


        anim.SetBool("IsRight", isRight);
    }

    void Shoot()
    {
        rb2d.velocity = Stick.transform.right * ShootForce;
    }
}
