using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int count = 0;
    private float timer = 20;

    public float speed = 10.0f;
    public float cannonSpeed = 10.0f;

    public Transform cannon;
    public GameObject cannonBallPrefab;
    public GameObject gameOver;
    public TextMeshProUGUI score, time;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontal * speed);
        cannon.transform.Rotate(Vector3.left * vertical * speed/2);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //shoot cannon
            ShootCannon();
        }

        timer -= Time.deltaTime;
        time.text = "Time Left: " + Mathf.Round(timer);

        if(timer<=0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void ShootCannon()
    {
        Quaternion rotation = Quaternion.Euler(-cannon.transform.localRotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180, cannon.transform.localRotation.eulerAngles.z);
        Debug.Log(rotation.eulerAngles);
        GameObject cannonBall = Instantiate(cannonBallPrefab, transform.position, rotation);
        cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * cannonSpeed, ForceMode.Impulse);
    }

    public void Hit(int c)
    {
        count += c;
        score.text = "Score: " + count;
    }
}
