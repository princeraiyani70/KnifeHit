using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RangeSpeed",0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }


    public void RangeSpeed()
    {
        speed = speed == 150 ? speed = -150 : speed = 150;
        //speed = Random.Range(-100, 100);
    }
}
