using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement oBlock;

    [SerializeField]
    private Transform defaultUpLeftLeft;

    [SerializeField]
    private Transform defaultUpLeftUp;

    [SerializeField]
    private Transform defaultUpRightRight;

    [SerializeField]
    private Transform defaultUpRightUp;

    [SerializeField]
    private Transform defaultDownLeftLeft;

    [SerializeField]
    private Transform defaultDownLeftDown;

    [SerializeField]
    private Transform defaultDownRightRight;

    [SerializeField]
    private Transform defaultDownRightDown;

    [SerializeField]
    private float oneBlockDistance = .1f;

    RaycastHit2D hit;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    RaycastHit2D hit4;

    // Update is called once per frame
    void Update()
    {
        if (oBlock.isActive == true)
        {
            if (oBlock.flipCount == 0)
                DefaultRaycast();
            else if (oBlock.flipCount == 1)
                OneFlipRaycast();
            else if (oBlock.flipCount == 2)
                TwoFlipRaycast();
            else if (oBlock.flipCount == 3)
                ThreeFlipRaycast();
        }
    }

    private void DefaultRaycast()
    {
        // check for side collision to be able to move left
        Debug.DrawRay(defaultUpLeftLeft.position, Vector2.left);
        Debug.DrawRay(defaultDownLeftLeft.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultUpLeftLeft.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownLeftLeft.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else
        {
            oBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUpRightRight.position, Vector2.right);
        Debug.DrawRay(defaultDownRightRight.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultUpRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else
        {
            oBlock.canMoveRight = true;
        }

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultDownLeftDown.position, Vector2.down);
        Debug.DrawRay(defaultDownRightDown.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultDownLeftDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
    }

    private void OneFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultDownLeftDown.position, Vector2.left);
        Debug.DrawRay(defaultDownRightDown.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultDownLeftDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else
        {
            oBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUpLeftUp.position, Vector2.right);
        Debug.DrawRay(defaultUpRightUp.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultUpLeftUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else
        {
            oBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpRightRight.position, Vector2.down);
        Debug.DrawRay(defaultDownRightRight.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultUpRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpRightRight.position, Vector2.left);
        Debug.DrawRay(defaultDownRightRight.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultUpRightRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else
        {
            oBlock.canMoveLeft = true;
        }

        //check for side collision to be able to move right
        Debug.DrawRay(defaultUpLeftLeft.position, Vector2.right);
        Debug.DrawRay(defaultDownLeftLeft.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultUpLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else
        {
            oBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpLeftUp.position, Vector2.down);
        Debug.DrawRay(defaultUpRightUp.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultUpLeftUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpLeftUp.position, Vector2.left);
        Debug.DrawRay(defaultUpRightUp.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultUpLeftUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveLeft = false;
            }
        }
        else
        {
            oBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeftDown.position, Vector2.right);
        Debug.DrawRay(defaultDownRightDown.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultDownLeftDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.canMoveRight = false;
            }
        }
        else
        {
            oBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultDownLeftLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpLeftLeft.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultDownLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                oBlock.Deactivate();
            }
        }
    }
}
