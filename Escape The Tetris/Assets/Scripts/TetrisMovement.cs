using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisMovement : MonoBehaviour
{
    [SerializeField]
    private float delayTime = 0.75f;

    [SerializeField]
    private float movementTime = 0.75f;

    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private AttachedPiece attachedPiece;

    [SerializeField]
    private GameObject gameObject;

    public bool isActive = true;

    private bool horizontalButtonPushed = false;
    private bool verticalButtonPushed = false;
    private bool isHitByPlayer = false;
    private bool isConnected = false;

    private Vector3 rotation;
    private Vector3 true0 = new Vector3(0f,0f,0f);
    private Vector3 true90 = new Vector3(0f, 0f, 90f);
    private Vector3 true180 = new Vector3(0f,0f, 180f);
    private Vector3 true270 = new Vector3(0f,0f,270f);

	void Start ()
    {
        if(attachedPiece != null)
        {
            isConnected = true;
        }
        InvokeRepeating("BlockFall", delayTime, movementTime);
	}
	
	void Update ()
    {
        if (isActive)
        {
            CheckInput();
            CheckAngles();
            CheckReset();
            if(isConnected)
            {
                CheckAttached();
            }
        }
	}

    private void CheckInput()
    {
        if(Input.GetAxis("TetrisHorizontal") != 0)
        {
            MoveBlockHorizontal();
        }
        else
        {
            horizontalButtonPushed = false;
        }

        if(Input.GetAxis("TetrisVertical") != 0)
        {
            MoveBlockVertical();
        }
        else
        {
            verticalButtonPushed = false;
        }

        if(Input.GetButtonDown("TetrisRotate"))
        {
            RotateBlock();
        }
    }

    private void CheckReset()
    {

    }

    private void CheckAngles()
    {
        if (isHitByPlayer)
        {
            if ((rotation.z < 88 || rotation.z > 271) && rotation.z != 0)
            {
                rotation = true0;
            }
            else if(rotation.z < 0)
            {
                rotation = true0;
            }
            else if ((rotation.z < 178 || rotation.z > 1) && rotation.z != 90)
            {
                rotation = true90;
            }
            else if ((rotation.z < 268 || rotation.z > 91) && rotation.z != 180)
            {
                rotation = true180;
            }
            else if ((rotation.z < 358 || rotation.z > 181) && rotation.z != 270)
            {
                rotation = true270;
            }
            else
            {
                rotation = rigidbody2D.transform.eulerAngles;
            }
            rigidbody2D.transform.eulerAngles = rotation;
        }
    }

    private void CheckAttached()
    {
        if(attachedPiece.isHitByGround == true)
        {
            CancelInvoke("BlockFall");
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            isActive = false;
        }
    }

    private void BlockFall()
    {
        //rigidbody2D.MovePosition(rigidbody2D.position - new Vector2(0f, 0.25f));
        gameObject.transform.Translate(0f, -.5f, 0f, Space.World);
    }

    private void MoveBlockHorizontal()
    {
        if (!horizontalButtonPushed)
        {
            if (Input.GetAxis("TetrisHorizontal") > 0)
            {
                gameObject.transform.Translate(.5f, 0f, 0f, Space.World);
                //rigidbody2D.
                //rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(0.5f, 0f));
            }
            else if (Input.GetAxis("TetrisHorizontal")<0)
            {
                gameObject.transform.Translate(-.5f, 0f, 0f, Space.World);
                //rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(-0.5f, 0f));
            }
            horizontalButtonPushed = true;
        }
    }

    private void MoveBlockVertical()
    {
        if(!verticalButtonPushed)
        {
            if(Input.GetAxis("TetrisVertical") < 0)
            {
                gameObject.transform.Translate(0f, -.5f, 0f, Space.World);
                //rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(0, -0.5f));
            }
            verticalButtonPushed = true;
        }
    }

    private void DropBlock()
    {

    }

    private void RotateBlock()
    {
        gameObject.transform.Rotate(0f, 0f, -90f, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Object Hit");
        if (isActive)
        {
            if (collision.gameObject.tag == "TetrisBlock")
            {
                CancelInvoke("BlockFall");
                rigidbody2D.bodyType = RigidbodyType2D.Static;
                isActive = false;
            }
            else if (collision.gameObject.tag == "Player")
            {
                rotation = rigidbody2D.transform.eulerAngles;
                rigidbody2D.freezeRotation = true;
                isHitByPlayer = true;
                if (PlayerMovement.isOnGround == true)
                {

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
                rigidbody2D.freezeRotation = false;
                rigidbody2D.transform.eulerAngles = rotation;
                isHitByPlayer = false;
            }
        }
    }

}
