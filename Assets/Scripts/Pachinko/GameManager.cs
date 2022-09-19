using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private int ballCount = 0;
    private float zBound = 5.0f, yPos=22.0f;

    public string playerChoice;
    public bool gameOver = false;

    public GameObject[] balls;
    public GameObject startScreen;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void StartGame()
    {
        InvokeRepeating("RandomBallGenerator", 2.0f, 1.0f);        
    }

    void RandomBallGenerator()
    {
        if (ballCount <= 20)
        {
            int randomId = Random.Range(0, balls.Length);
            float randomZ = Random.Range(-zBound, zBound);
            Instantiate(balls[randomId], new Vector3(balls[randomId].transform.position.x, yPos, randomZ), balls[randomId].transform.rotation);
            ballCount++;
        }
        else
        {
            gameOver = true;
            gameOverScreen.gameObject.SetActive(true);
        }
    }

    public void Green()
    {
        playerChoice = "Green";
        startScreen.SetActive(false);
        StartGame();
    }
    public void Red()
    {
        playerChoice = "Red";
        startScreen.SetActive(false);
        StartGame();
    }
    
}
