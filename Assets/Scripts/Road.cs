using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour//three kinds of Road straight ,right ,left
{
    public Collider bound;
    GameObject player;
    RoadManager RM;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("parent: "+transform.parent+" Tag: "+transform.parent.tag);
        Debug.Log("parent_Parant : "+transform.parent.parent+ " Tag: "+transform.parent.parent.tag);
        if (transform.parent.tag == "Corner_Road_Left"||transform.parent.tag == "Corner_Road_Right"||transform.parent.tag == "Obstacle")
        {
            Debug.Log("A");
            RM = transform.parent.parent.GetComponent<RoadManager>();
            player = transform.parent.parent.GetComponent<RoadManager>().player;
        }
        else
        {
            Debug.Log("B");
            RM = transform.parent.GetComponent<RoadManager>();
            player = transform.parent.GetComponent<RoadManager>().player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Copy();
        }
    }
    void Copy()
    {//Use RoadManager to Maintain the multi Roads
        int r = Random.Range(0, RM.rm.Length);
        GameObject go = RM.rm[r];
        if (RM.CornerCount < 5&&RM.Obstacle <3)
        {
            r = 0;
            go = RM.rm[r];
            RM.Obstacle++;
            RM.CornerCount++;
        }
        else if(RM.CornerCount >=5 && RM.Obstacle <3)
        {
            while (go.tag == "Obstacle")
            {
                r = Random.Range(0, RM.rm.Length);
                go = RM.rm[r];
            }
            RM.Obstacle++;
        }else if(RM.CornerCount < 5 && RM.Obstacle >= 3)
        {
            while (go.tag == "Corner_Road_Right" || go.tag == "Corner_Road_Left")
            {
                r = Random.Range(0, RM.rm.Length);
                go = RM.rm[r];
            }
            RM.CornerCount++;
        }
        if (go.tag == "Corner_Road_Right" || go.tag == "Corner_Road_Left")
        {
            RM.CornerCount = 0;
        }
        if (go.tag == "Obstacle")
        {
            RM.Obstacle = 0;
        }


        Vector3 pos;
        Debug.Log(player.GetComponent<Player>().isX);
        Debug.Log(player.transform.rotation.eulerAngles.y);
        float nowAngle = player.transform.rotation.eulerAngles.y;
        if (nowAngle >= -10 && nowAngle <= 10)//0
        {
            float length;
            if (go.tag == "Corner_Road_Left"||go.tag == "Corner_Road_Right")//0,90,180,270
            {
                length = bound.bounds.extents.z * 5;
            }
            else
            {
                length = bound.bounds.extents.z * 2;
            }
            pos = transform.position + new Vector3(0, 0, length);
        }
        else if (nowAngle >= 260 && nowAngle <= 290)//270
        {
            float length;
            if (go.tag == "Corner_Road_Left" || go.tag == "Corner_Road_Right")//0,90,180,270
            {
                length = bound.bounds.extents.x * 5;
            }
            else
            {
                length = bound.bounds.extents.x * 2;
            }
            pos = transform.position + new Vector3(-length, 0, 0);
        }
        else if (nowAngle >= 170 && nowAngle <= 190)
        {
            float length;
            if (go.tag == "Corner_Road_Left" || go.tag == "Corner_Road_Right")//0,90,180,270
            {
                length = bound.bounds.extents.z * 5;
            }
            else
            {
                length = bound.bounds.extents.z * 2;
            }
            pos = transform.position + new Vector3(0, 0, -length);
        }
        else
        {
            float length;
            if (go.tag == "Corner_Road_Left"||go.tag == "Corner_Road_Right")//0,90,180,270
            {
                length = bound.bounds.extents.x * 5;
            }
            else
            {
                length = bound.bounds.extents.x * 2;
            }
            pos = transform.position + new Vector3(length, 0, 0);
        }

        if (transform.parent.tag == "Corner_Road_Left")
        {
            Debug.Log("Left!!!");

            RM.nowRotate -= 90f;
            if (RM.nowRotate == -180f)
            {
                RM.nowRotate = 180f;
            }
            if (RM.nowRotate == -90)
            {
                Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent.parent);
            }
            else if (RM.nowRotate == 0)
            {
                Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent.parent);
            }
            else if(RM.nowRotate == 90)
            {
                Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent.parent);
            }
            else
            {
                Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent.parent);
            }

        }
        else if (transform.parent.tag == "Corner_Road_Right")
        {
            Debug.Log("Right!!!");
            RM.nowRotate += 90f;
            if(RM.nowRotate == 270f)
            {
                RM.nowRotate = -90f;
            }
            if (RM.nowRotate == -90)
            {
                Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent.parent);
            }
            else if (RM.nowRotate == 0)
            {
                Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent.parent);
            }
            else if (RM.nowRotate == 90)
            {
                Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent.parent);
            }
            else
            {
                Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent.parent);
            }
        }
        else if(transform.parent.tag == "Obstacle")
        {
            Debug.Log("OBstacle!!!");

            if (RM.nowRotate == -90)
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent.parent);
                }
            }
            else if (RM.nowRotate == 0)
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent.parent);
                }
            }
            else if(RM.nowRotate == 90)
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent.parent);
                }
            }
            else
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent.parent);
                }
            }
        }
        else
        {
            Debug.Log("Middle!!!");

            if (RM.nowRotate == -90)
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent);
                }
            }
            else if (RM.nowRotate == 0)
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent);
                }
            }
            else if (RM.nowRotate == 90)
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[2].transform.rotation, transform.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[1].transform.rotation, transform.parent);
                }
            }
            else
            {
                if (go.tag == "Corner_Road_Left")
                {
                    Instantiate(go, pos, RM.rotate[0].transform.rotation, transform.parent);
                }
                else if (go.tag == "Corner_Road_Right")
                {
                    Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent);
                }
                else
                {
                    Instantiate(go, pos, RM.rotate[3].transform.rotation, transform.parent);
                }
            }
        }

    }
   
}
