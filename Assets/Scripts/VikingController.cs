using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    public Vector3 Turning;
   // MeshRenderer mr;
    [SerializeField] float MovingSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //   mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //   transform.position += Time.deltaTime * MovingSpeed * MovingDirection;
        //  mr.material.color = new Color((int)Time.time%2*255f,255f,255f);
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.forward;
        }if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.up;
        }
    }
}
