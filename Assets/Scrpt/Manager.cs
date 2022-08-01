using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Vector3 rotationPoint;
    [SerializeField] public GameObject go;
    [SerializeField] private float previousTime;
    [SerializeField] private float fallTime = 0.8F;

    private bool _quickDown = false;
    public static int height = 5;
    public static int width = 3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTetromino()
    {

    }

    public void goToLeft()
    {
        go.transform.position += new Vector3(-1, 0, 0);
        if (!validMove())
            go.transform.position -= new Vector3(-1, 0, 0);
    }


    public void goToRight()
    {
        go.transform.position += new Vector3(1, 0, 0);
        if (!validMove())
            go.transform.position -= new Vector3(1, 0, 0);
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
        go.transform.RotateAround(go.transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
    }

    bool validMove()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float xBorder = 0.0f;
        float yBorder = 0.0f;

        int roundedStageX = Mathf.FloorToInt(stageDimensions.x);
        int roundedStageY = Mathf.FloorToInt(stageDimensions.y);
        float diffX = stageDimensions.x - roundedStageX;
        float diffY = stageDimensions.y - roundedStageY;


        if (diffX < 0.5)
            xBorder = roundedStageX;
        else if (diffX == 0.5 || diffX > 0.5)
            xBorder = roundedStageX + 0.5F;

        if (diffY < 0.5)
            yBorder = roundedStageY;
        else if (diffY == 0.5 || diffY > 0.5)
            yBorder = roundedStageY + 0.5F;
        yBorder = yBorder / 2;

        if (go.transform.position.x < (-xBorder) || go.transform.position.x > (xBorder)
             || go.transform.position.y < (-yBorder))
            return false;

        return true;
    }
}
