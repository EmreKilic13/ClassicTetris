using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows, cols, tileSize = 1;
    Vector2 pos;
    public GameObject referenceTile;
    
    public static float leftBorder = 0.5f, rightBorder, downBorder;

    // Start is called before the first frame update
    void Start()
    {
        
        setBoundaries();
        
        generateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setBoundaries()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        cols = Mathf.FloorToInt(stageDimensions.x);
        rows = Mathf.FloorToInt(stageDimensions.y);

    }
    void generateGrid()
    {
        //TODO: GRID deki alt kismi listeye ekle
        GameObject tmpGo;
        int _counter = 0;
        rightBorder = cols - Mathf.RoundToInt((float)(cols * 0.2));
        downBorder = rows - Mathf.RoundToInt((float)(rows * 0.5));
        for (float i = leftBorder; i < rightBorder + 1; i=i+0.25F)
        {

            for (float j =0; j < downBorder; j=j+0.25F)
            {
                tmpGo = Instantiate(referenceTile, new Vector3(i, j + Mathf.RoundToInt((float)(rows * 0.5))), Quaternion.identity);
                tmpGo.GetComponent<Transform>().localScale = new Vector3(0.20F, 0.20F, 0.20F);
                tmpGo.transform.name = "Tile_" + _counter;
                //tmpGo.GetComponent<SpriteRenderer>().forceRenderingOff = false;
                _counter++;
            }
        }

       

    }
}
