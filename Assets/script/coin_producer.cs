using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_producer : MonoBehaviour
{
    public Transform coin;
    List<Transform> coinList;
    Random r;

    // Start is called before the first frame update
    void Start()
    {
        coinList = new List<Transform>();

        for (int i = 0; i < 5; i++)
        {
            Transform t = Instantiate(coin);
            Transform p = transform.GetChild((int) Random.Range(0 ,  transform.childCount) );

            t.parent = p;
            t.localPosition = p.localPosition;

            coinList.Add(t);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
