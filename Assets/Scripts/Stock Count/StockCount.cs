using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockCount : MonoBehaviour
{
    public GameObject plane;
    public float speed = 20.0f;

    CountUI count;
    Rigidbody rb;
    bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = GameObject.Find("Canvas").GetComponent<CountUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
            rb.velocity= ((plane.transform.position - this.transform.position).normalized)*Time.deltaTime * speed;
        //transform.Translate(((plane.transform.position - this.transform.position).normalized) * Time.deltaTime * speed);

        /*if(this.gameObject.CompareTag("Red"))
        {
            transform.Translate(((plane.transform.position - this.transform.position).normalized) * Time.deltaTime);
        }
        if (this.gameObject.CompareTag("Green"))
        {
            transform.Translate((plane.transform.position - this.transform.position)*Time.deltaTime);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 offsetR = new Vector3(Random.Range(-22.0f, 22.0f), 0.5f, Random.Range(-45.0f, -25.0f));
        Vector3 offsetG = new Vector3(Random.Range(-22.0f, 22.0f), 0.5f, Random.Range(45.0f, 25.0f));
        if (other.gameObject.CompareTag("Red") && this.gameObject.CompareTag("Red"))
        {
            this.transform.position = offsetR;
            stop = true;
            speed = 0;
            count.redCount++;
        }
        else if (other.gameObject.CompareTag("Green") && this.gameObject.CompareTag("Green"))
        {
            this.transform.position = offsetG;
            stop = true;
            speed = 0;
            count.greenCount++;
        }

    }

    Vector3 GenerateRandomPos()
    {
        return new Vector3(Random.Range(-22.0f, 22.0f), 0.5f, Random.Range(-45.0f, -25.0f));
    }
}
