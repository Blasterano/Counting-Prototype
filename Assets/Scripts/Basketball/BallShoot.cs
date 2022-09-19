using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallShoot : MonoBehaviour
{
    Vector3 mousePos;
    Rigidbody rb;

    bool shot = false;
    float t = 3;
    float timer = 60;
    int count = 0;

    public TextMeshProUGUI basketText;
    public TextMeshProUGUI timerText;
    public GameObject Gameover;

    public float force = 100.0f;
    public float mouseZ;
    public float leftBound, rightBound;
    public float topBound, bottomBound;

    // Start is called before the first frame update
    void Start()
    {
        leftBound = 7.0f;
        rightBound = -8.5f;
        topBound = 10.0f;
        bottomBound = 1.0f;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.Round(timer);
        if(timer<=0)
        {
            Gameover.SetActive(true);
            Time.timeScale = 0;
        }
        if (!shot)
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseZ));
            MouseBound();
            transform.position = mousePos;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            //StartCoroutine(ResetPos());
            t -= Time.deltaTime;
            if (t <= 0)
            {
                shot = false;
                t = 5;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shot = true;
            float randomForce = Random.Range(force / 2, force + 1);
            rb.velocity = new Vector3(0, mousePos.y/10, -0.5f) * randomForce;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Green"))
        {
            basketText.text = "Basket: " + (++count);
        }
    }
    /*IEnumerator ResetPos()
    {
        while (shot)
        {
            t -= Time.deltaTime;
            Debug.Log(Mathf.Round(t));
            yield return new WaitForSeconds(5.0f);
            shot = false;
            t = 5;
        }
    }*/

    void MouseBound()
    {
        if(mousePos.x>leftBound)
            mousePos.x = leftBound;
        else if (mousePos.x < rightBound)
            mousePos.x = rightBound;

        if (mousePos.y > topBound)
            mousePos.y = topBound;
        else if (mousePos.y < bottomBound) 
            mousePos.y= bottomBound;
    }
}
