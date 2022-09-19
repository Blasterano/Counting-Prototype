using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCount : MonoBehaviour
{
    private int greenCount, redCount;
    private GameManager gameManager;

    public TextMeshProUGUI greenText, redText, gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        greenCount = redCount = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver)
        {
            switch(gameManager.playerChoice)
            {
                case "Green": 
                    if(greenCount > redCount)
                    {
                        gameOverText.text = "You Won the bet...";
                        gameOverText.color = Color.green;
                    }
                    else if(redCount > greenCount)
                    {
                        gameOverText.text = "You lost the bet...";
                        gameOverText.color = Color.green;
                    }
                    else
                    {
                        gameOverText.text = "Draw";
                        gameOverText.color = Color.green;
                    }
                    break;
                case "Red":
                    if (greenCount < redCount)
                    {
                        gameOverText.text = "You Won the bet...";
                        gameOverText.color = Color.red;
                    }
                    else if (redCount < greenCount)
                    {
                        gameOverText.text = "You lost the bet...";
                        gameOverText.color = Color.red;
                    }
                    else
                    {
                        gameOverText.text = "Draw";
                        gameOverText.color = Color.red;
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Green"))
        {
            greenText.text = "Green Ball: " + ++greenCount;
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            redText.text = "Red Ball: " + ++redCount;
        }

    }
}
