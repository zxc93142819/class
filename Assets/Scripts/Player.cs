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
    [SerializeField] Vector3[] RotateVector = new Vector3[] { new Vector3(0f, 9f, 0f), new Vector3(0f, -9f, 0f) };
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    float TuringAddTime = 90f;//轉動冷卻時間
    float JumpAddTime = 90f;//同上
    bool isJump = false;
    bool isRotate = false;
    int RotateCode = -1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
        RotateController();
        JumpController();
    }
    void MoveController()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*MoveSpeed);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
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
