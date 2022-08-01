using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TetrisBlock;

public class spawner : MonoBehaviour
{

    [SerializeField] public GameObject[] Tetrominos;
    // Start is called before the first frame update
    void Start()
    {
        spawnTetromino();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnTetromino()
    {
        Instantiate(Tetrominos[Random.Range(0, Tetrominos.Length)], transform.position, Quaternion.identity);
    }

    public void goToLeft()
    {
        leftFlag = true;
    }
    public void goToLeftPressDown()
    {
        leftFlagPD = true;
    }

    public void goToLeftPressUp()
    {
        leftFlagPD = false;
    }

    public void goToRight()
    {
        rightFlag = true;
    }
    public void goToRightPressDown()
    {
        rightFlagPD = true;
    }

    public void goToRightPressUp()
    {
        rightFlagPD = false;
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
        rotateFlag = true;
    }
}
