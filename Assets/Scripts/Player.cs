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
    bool isCorner = true;
    bool isGameStart = true;
    int RotateCounter = 0;
    int RotateCode = -1;
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
            if (Input.GetKey(KeyCode.A))
            {
                if(isCorner && RotateCode == 1)
                {
                    CornerRotate();
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
                }
                else
                {
                    transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
                    anim.SetBool("Run", true);
                }
            }
        }
    }
    void CornerRotate()
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
        }
    }
    void RotateController()
    {
        
        if(TuringAddTime>= 10f)
        {
            TuringAddTime = 10f;
        }
        else
        {
            TuringAddTime += 1f;
            transform.Rotate(RotateVector[RotateCode]);
        }
        if (Input.GetKey(KeyCode.D)&&TuringAddTime >= 10f)
        {
            RotateCode = 0;
            TuringAddTime = 0f;
        }
        else if (Input.GetKey(KeyCode.A) && TuringAddTime >=10f)
        {
            RotateCode = 1;
            TuringAddTime = 0f;
        }//wait for fixing...
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
