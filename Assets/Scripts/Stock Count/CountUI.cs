using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountUI : MonoBehaviour
{
    public int redCount, greenCount;
    [SerializeField] TextMeshProUGUI red,green;

    // Start is called before the first frame update
    void Start()
    {
        redCount = greenCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        red.text = "Red Stock: " + redCount;
        green.text = "Green Stock: " + greenCount;
    }
}
