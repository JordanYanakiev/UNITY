using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGround : MonoBehaviour
{
    public int width, height;
    public GameObject Square0, Square1, Square2;
    private float offsetx = 7f;
    private float offset = 1f;
    private List<GameObject> Tiles = new List<GameObject>();
    private System.Random sluchaino = new System.Random();
    private int counter;
    
    
    void CreateTiles()
    {
        
        for (int i = 0; i < width; i++)
        {
            Tiles.Add(Instantiate(Square0));
            Tiles.Add(Instantiate(Square1));
            Tiles.Add(Instantiate(Square2));
            counter = sluchaino.Next(3);
            Vector2 pos = new Vector2(i * offsetx, 0);
            Instantiate(Tiles[counter], pos, Quaternion.identity);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        CreateTiles();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
           
        //}
        
    }
}
