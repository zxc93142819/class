using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float TuringTime = 10f;
    [SerializeField] float JumpSpeed = 10f;
    [SerializeField] float JumpTime = 90f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    Vector3[] RotateVector = new Vector3[] { new Vector3(0f, 9f, 0f), new Vector3(0f, -9f, 0f) };
    float TuringAddTime = 90f;//轉動冷卻時間
    float JumpAddTime = 90f;//同上
    bool isJump = false;
    public bool isRight = true;
    public bool isCorner = false;
    public bool isGameStart = false;
    public bool startTurn = false;
    int RotateCounter = 0;
    public int RotateCode = -1;
    public bool isX = false;//origin Z
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    void JumpController()
    {
        if(JumpAddTime >= JumpTime / 2)
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
        if (Input.GetKey(KeyCode.Space)&&JumpAddTime >= JumpTime)
        {
            rb.AddForce(transform.up * JumpSpeed);
            anim.SetBool("Jump", true);
            JumpAddTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
