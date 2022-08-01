using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridManager;
//using static spawner;

public class TetrisBlock : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool 
        leftFlag = false, 
        rightFlag = false, 
        rightFlagPD = false, 
        leftFlagPD = false, 
        rotateFlag = false;

    [SerializeField] public Vector3 rotationPoint;
    [SerializeField] public GameObject[] Tetrominos;

    [SerializeField] private float previousTime;
    [SerializeField] private float fallTime = 0.1F;
    private float shiftingTime = 1F;
    public static List<Transform> grids = new List<Transform>();
    public static bool _quickDown = false;
    static int xBorder = 0;
    static int yBorder = 0;
    GameObject bigShape;
    void Start()
    {
    }

    void Update()
    {

        

        if (Time.time - previousTime > (_quickDown ? fallTime/10 : fallTime))
        {
            transform.position += new Vector3(0, -0.25F , 0);
            if (!validMove())
            {
                transform.position -= new Vector3(0, -0.25F, 0);
                addGrid(transform);
                this.enabled = false;
                FindObjectOfType<spawner>().spawnTetromino();
            }
                
            previousTime = Time.time;

        }
        if (leftFlag == true) goToLeft(); leftFlag = false; 
       if(rightFlag == true) goToRight(); rightFlag = false;
       if(rotateFlag == true) rotate(); rotateFlag = false;
    }
    
    

    public void goToLeft()
    {
        transform.position += new Vector3(-0.25F, 0, 0);
        if(!validMove())
            transform.position -= new Vector3(-0.25F, 0, 0);
    }


    public void goToRight()
    {
        transform.position += new Vector3(0.25F, 0, 0);
        if (!validMove())
            transform.position -= new Vector3(0.25F, 0, 0);
    }

    public void quickDownPressDown()
    {
        _quickDown = true;
    }

    public void quickDownPressUp()
    {
        _quickDown = false;
    }

    public void rotate()
    {
        //checkLine();
        if (transform.name != "OTetromino(Clone)")
        {
           
            if (transform.position.x < 1F) // leftBorder
            {
                while (transform.position.x < 1F)
                {
                    transform.position += new Vector3(0.25f, 0, 0);
                }

            }

            if (transform.position.x >= (rightBorder + 0.75f)) // rightborder
            {
                transform.position += new Vector3(-0.25F, 0, 0);
            }

            if (transform.position.y == (downBorder))
            {
                while (transform.position.y <= downBorder)
                {
                    transform.position += new Vector3(0, 0.25F, 0);
                }

            }

            // Carpisma onlemesi
            for (int i = 0; i < grids.Count; i++)
            {
                if (grids[i].position.y == transform.position.y)
                {
                    transform.position += new Vector3(0, 0.25F, 0);
                }

            }

            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 0.25f), 90);

        }
        
    }

    bool checkGrid(Vector3 pos)
    {
        for (int i = 0; i < grids.Count; i++)
        {
            if (grids[i].position.x == pos.x && grids[i].position.y == pos.y)
                return true;
            
        }
        return false;
    }
    

    void addGrid(Transform parent) 
    {
        //bigShape = transform.gameObject;
        transform.parent = GameObject.Find("BigShape").transform;
        bigShape = GameObject.Find("BigShape");

        for(int child = 0; child < bigShape.transform.childCount; child++)
        {
            if(bigShape.transform.GetChild(child).position.x == 0.75)
            {
                Debug.Log("IFE GIRDI");
                for (int i = 0; i < grids.Count; i++)
                {
                    //if (grids[i].Equals(bigShape.transform.GetChild(child)))
                    {
                        Debug.Log("GRID REMOVE");
                        //grids.RemoveAt(i);
                    }
                        

                }
                Destroy(bigShape.transform.GetChild(child).gameObject);

            }
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            grids.Add(parent.GetChild(i).transform);
        }
    }
    /*
    void checkLine()
    {
        Debug.Log("CHECKLINE");
        for(int i = 0; i < grids.Count; i++)
        {
            Debug.Log("GRID ITEM: " + grids[i].position.x + " - " + grids[i].position.y);
            //if(grids[i].position.x == 0.5F && grids[i].position.y == 5F)
            {
                Debug.Log("CHECKLINE 2");
                Destroy(grids[i].gameObject);
            }
        }

    }
    */

    bool validMove()
    {
        GridManager obj = new GridManager();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).position.x <= 0.25f  || 
                transform.GetChild(i).position.x > (rightBorder + 0.75f))
            {
                return false;
            }
                
            
            if (transform.GetChild(i).position.y < downBorder)
            {
                addGrid(transform.GetChild(i));
                return false;
            }

            if (checkGrid(transform.GetChild(i).position) == true)
            {
                return false;
            }
                
        }

        
        return true;
    }
}


