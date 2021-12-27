using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float TuringTime = 10f;
    [SerializeField] float JumpSpeed = 10f;
    [SerializeField] float JumpTime = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    public int dieBecause = -1;//0 = fall , 1 = hit obstacle, 2 = caught by enemy, -1 = none
    Vector3[] RotateVector = new Vector3[] { new Vector3(0f, 9f, 0f), new Vector3(0f, -9f, 0f) };
    float TuringAddTime = 90f;//��ʧN�o�ɶ�
    [SerializeField]float JumpAddTime = 5f;//�P�W
    bool isJump = false;
    public AudioSource jumping_music;
    public bool isRight = true;
    public bool isCorner = false;
    public bool isGameStart = false;
    public bool startTurn = false;
    int RotateCounter = 0;
    public float margin = 0.01f;
    public int RotateCode = -1;
    public bool isX = false;//origin Z
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        JumpSpeed = 400f;
        JumpAddTime = 1f;
        JumpTime = 1f;
        margin = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(dieBecause != -1) { return; }
        if (transform.position.y < -10)
        {
            Debug.Log("YOu Die!");
            Time.timeScale = 0;
            dieBecause = 0;
            GetComponent<Animator>().enabled = false;
        }
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
            transform.Translate(Vector3.forward*Time.deltaTime*MoveSpeed);
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
                    Debug.Log(isCorner + " " + RotateCode);
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
            transform.Rotate(new Vector3(0f,-1f,0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 1f, 0f));
        }
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, margin);
    }
    void JumpController()
    {
        if(IsGrounded())
        {
            anim.SetBool("Jump", false);
            jumping_music.enabled = false;
        }
        if (JumpAddTime >= JumpTime)
        {
            JumpAddTime = JumpTime;
        }//maybe use collider to make it real
        else
        {
            JumpAddTime += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) &&IsGrounded()&& JumpAddTime >= JumpTime)
        {
            jumping_music.enabled = true;
            rb.AddForce(transform.up * JumpSpeed);
            anim.SetBool("Jump", true);
            JumpAddTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
