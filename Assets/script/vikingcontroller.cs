using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI ;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class vikingcontroller : MonoBehaviour
{
    public Vector3 MovingDirection;
    public AudioSource jumping_music;
    public Text coin_show;
    float jumpingforce = 35 ;
    int jump_or_not = 0 , coin = 0 ;
    bool run = false ;

    Rigidbody rb;
    [SerializeField] float MovingSpeed = 10f;          //serializefield = 能在介面顯示private 項
    Animator ani;
    NavMeshAgent agent;
    RaycastHit raycastHit;

    void Awake(){}
    void Start()
    {
        coin = 0 ;
        Transform t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //t.position = Vector3.one ;
    }
    
    void Update()
    {
        run = false;
        if (Input.GetKey(KeyCode.W))
        {
            run = true;
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            run = true;
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            run = true;
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            run = true;
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.right;
        }

        if (jump_or_not == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumping_music.enabled = true;
                run = true;
                rb.AddForce(jumpingforce * transform.up);
            }
        }
        coin_show.text = coin.ToString();
        ani.SetBool("run", run);
    }
    

    void OnCollisionEnter(Collision collision)
    {
        jumping_music.enabled = false;
        jump_or_not = 0;
    }

    void OnCollisionStay(Collision collision) {}

    void OnCollisionExit(Collision collision)
    {
        jump_or_not = 1;
    }





    /*
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float TuringTime = 10f;
    [SerializeField] float JumpSpeed = 10f;
    [SerializeField] float JumpTime = 90f;
    //[SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    Vector3[] RotateVector = new Vector3[] { new Vector3(0f, 9f, 0f), new Vector3(0f, -9f, 0f) };
    float TuringAddTime = 90f;//Âà°Ê§N«o®É¶¡
    float JumpAddTime = 90f;//¦P¤W
    bool isJump = false;
    public bool isRight = true;
    public bool isCorner = false;
    public bool isGameStart = false;
    public bool startTurn = false;
    int RotateCounter = 0;
    public int RotateCode = -1;
    public bool isX = false;//origin Z

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<StartGame>().isGamePause)
        {
            return;
        }
        if (!isGameStart)
        {
            isGameStart = transform.parent.GetComponent<StartGame>().isGameStart;
            return;
        }
        anim.SetBool("Run", false);

        MoveController();
        if (!isGameStart)
        {
            RotateController();
        }
        JumpController();
    }
    void MoveController()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
            anim.SetBool("Run", true);
        }
        if (isGameStart)
        {
            if (startTurn)
            {
                CornerRotate();
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if (isCorner && RotateCode == 1)
                    {
                        CornerRotate();
                        startTurn = true;
                    }
                    else
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
                        anim.SetBool("Run", true);
                    }
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (isCorner && RotateCode == 0)
                    {
                        CornerRotate();
                        startTurn = true;
                    }
                    else
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
                        anim.SetBool("Run", true);
                    }
                }
            }
        }
    }
    void CornerRotate()
    {
        if (RotateCounter == 0)
        {
            if (isX)
            {
                isX = false;
            }
            else
            {
                isX = true;
            }
            transform.Rotate(RotateVector[RotateCode]);
            RotateCounter++;
        }
        else
        {
            if (RotateCounter != 10)
            {
                transform.Rotate(RotateVector[RotateCode]);
                RotateCounter++;
            }
            else
            {
                RotateCounter = 0;
                isCorner = false;
                startTurn = false;
            }
        }
    }
    void RotateController()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -1f, 0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 1f, 0f));
        }
    }
    void JumpController()
    {
        if (JumpAddTime >= JumpTime / 2)
        {
            anim.SetBool("Jump", false);
        }
        if (JumpAddTime >= JumpTime)
        {
            JumpAddTime = JumpTime;
        }//maybe use collider to make it real
        else
        {
            JumpAddTime += 0.1f;
        }
        if (Input.GetKey(KeyCode.Space) && JumpAddTime >= JumpTime)
        {
            rb.AddForce(transform.up * JumpSpeed);
            anim.SetBool("Jump", true);
            JumpAddTime = 0;
        }
    }
    */
    
}
