using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameManager : MonoBehaviour
{
    private Vector3 mousePos;
    private GameObject piece = null;

    public GameObject[] pieces;

    public float mouseZ;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y));
        if(piece != null)
            piece.transform.position = mousePos + offset;
    }

    public void CreatePiece(int id)
    {
        //create piece according to button pressed
        piece = Instantiate(pieces[id], mousePos, pieces[id].transform.rotation);
    }

    public void Straight()
    {
        CreatePiece(0);
    }
    public void Plus()
    {
        CreatePiece(1);
    }
    public void L()
    {
        CreatePiece(2);
    }
}
