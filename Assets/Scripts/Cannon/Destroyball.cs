using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyball : MonoBehaviour
{

    //public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Red"))
        {
            Destroy(collision.gameObject);
            //score point
            count++;
            Destroy(this.gameObject);
        }
    }*/
}
