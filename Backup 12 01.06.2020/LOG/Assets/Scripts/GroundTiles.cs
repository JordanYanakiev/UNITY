using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiles : MonoBehaviour
{
    public GameObject tile1, tile2, tile3, tile4, tile5, tile6;
    public GameObject ceiling;
    public GameObject ObstacleTile;
    private float ceilingLength;
    private float ceilingPos;
    public int width;
    public int heigth;
    int offsetCube = 10;
    Vector3 position;

    List<GameObject> solidGround = new List<GameObject>();
    System.Random genNumber = new System.Random();

    

    void CreateTiles()
    {
        solidGround.Add(tile1);
        solidGround.Add(tile2);
        solidGround.Add(tile3);
        solidGround.Add(tile4);
        solidGround.Add(tile5);
        solidGround.Add(tile6);

        ceilingLength = width * 7.1f;
        ceilingPos = (ceilingLength / 2f) - 7f;

        ceiling.GetComponent<Transform>().localScale = new Vector3(ceilingLength, 1);
        ceiling.GetComponent<Transform>().position = new Vector3(ceilingPos, 7, 0);
        
        //GameObject.Instantiate(ceiling, position, Quaternion.identity);

        for (int j = 0; j <= width; j++)
        {
            offsetCube = j;
            int rNumber = genNumber.Next(6);
            position = new Vector3(7 * offsetCube, 0, 0);
            GameObject.Instantiate(solidGround[rNumber], position, Quaternion.identity);

            //Create obstacle on the Green Tile
            if(solidGround[rNumber].CompareTag("Green"))
            {
                position = new Vector3((offsetCube*7) + 4.5f, 3.49f, 0);
                GameObject.Instantiate(ObstacleTile, position, Quaternion.identity);
            }
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        CreateTiles();
    }

    //Update is called once per frame
    void Update()
    {

    }
}
