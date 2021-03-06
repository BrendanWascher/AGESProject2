﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisMovement : MonoBehaviour
{
    [SerializeField]
    private float delayTime = 0.75f;

    [SerializeField]
    private float movementTime = 0.75f;

    [SerializeField]
    private string thisScene = "Level1";

    [SerializeField]
    private Rigidbody2D rigidbody2D;

    /*
    [SerializeField]
    private AttachedPiece attachedPiece;
    */

    [SerializeField]
    private GameObject gameObject;

    public bool isActive = true;
    public bool canFlip = true;
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool hasMoved = false;
    public int flipCount = 0;

    public static bool isTwoPlayer = false;

    private int playerNumber = 1;
    private bool horizontalButtonPushed = false;
    private bool verticalButtonPushed = false;
    //private bool isHitByPlayer = false;
    //private bool isConnected = false;

	void Start ()
    {
        InvokeRepeating("BlockFall", delayTime, movementTime);
        if(isTwoPlayer)
        {
            playerNumber = 2;
        }
        else
        {
            playerNumber = 1;
        }
	}
	
	void Update ()
    {
        if (isActive)
        {
            CheckInput();
            CheckReset();
        }
	}

    private void CheckInput()
    {
        if(Input.GetAxis("TetrisHorizontal"+playerNumber) != 0)
        {
            MoveBlockHorizontal();
        }
        else
        {
            horizontalButtonPushed = false;
        }

        if(Input.GetAxis("TetrisVertical" + playerNumber) != 0)
        {
            MoveBlockVertical();
        }
        else
        {
            verticalButtonPushed = false;
        }

        if(Input.GetButtonDown("TetrisRotate" + playerNumber))
        {
            if (canFlip)
            {
                RotateBlock();
                flipCount++;
                if (flipCount == 4)
                    flipCount = 0;
            }
        }
    }

    private void CheckReset()
    {

    }

    private void BlockFall()
    {
        gameObject.transform.Translate(0f, -.5f, 0f, Space.World);
        hasMoved = true;
    }

    private void MoveBlockHorizontal()
    {
        if (!horizontalButtonPushed)
        {
            if (Input.GetAxis("TetrisHorizontal" + playerNumber) > 0 && canMoveRight)
            {
                gameObject.transform.Translate(.5f, 0f, 0f, Space.World);
            }
            else if (Input.GetAxis("TetrisHorizontal" + playerNumber) <0 && canMoveLeft)
            {
                gameObject.transform.Translate(-.5f, 0f, 0f, Space.World);
            }
            horizontalButtonPushed = true;
        }
    }

    private void MoveBlockVertical()
    {
        if(!verticalButtonPushed)
        {
            if(Input.GetAxis("TetrisVertical" + playerNumber) < 0)
            {
                gameObject.transform.Translate(0f, -.5f, 0f, Space.World);
            }
            verticalButtonPushed = true;
        }
    }

    private void DropBlock()
    {

    }

    /*
    private void KillPlayer()
    {
        SceneManager.LoadScene("Level" + ExitDoor.levelNumber);
    }
    */

    private void RotateBlock()
    {
        gameObject.transform.Rotate(0f, 0f, -90f, Space.World);
    }

    public void Deactivate()
    {
        isActive = false;
        CancelInvoke("BlockFall");
        rigidbody2D.bodyType = RigidbodyType2D.Static;

    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Object Hit");
        if (isActive)
        {
            if (collision.gameObject.tag == "Player")
            {
                isHitByPlayer = true;
                if (PlayerMovement.isOnGround == true)
                {
                    //KillPlayer();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isActive)
        {
            if (collision.gameObject.tag == "Player")
            {
                isHitByPlayer = false;
            }
        }
    }
    */

}
