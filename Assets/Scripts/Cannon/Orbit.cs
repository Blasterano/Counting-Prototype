using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private PlayerController player;

    public Transform pivot;    

    public float power;
    public int point;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cannon").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pivot == null)
            return;
        transform.RotateAround(pivot.position, Vector3.up, power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        //score point
        player.Hit(point);
        Destroy(this.gameObject);
    }
}
