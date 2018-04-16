using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement zBlock;

    [SerializeField]
    private Transform defaultUpLeftLeft;

    [SerializeField]
    private Transform defaultUpLeftUp;

    [SerializeField]
    private Transform defaultUpLeftDown;

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
    private Transform defaultDownRightUp;

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
        if (zBlock.isActive == true)
        {
            if (zBlock.flipCount == 0)
                DefaultRaycast();
            else if (zBlock.flipCount == 1)
                OneFlipRaycast();
            else if (zBlock.flipCount == 2)
                TwoFlipRaycast();
            else if (zBlock.flipCount == 3)
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
                zBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownLeftLeft.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else
        {
            zBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownRightRight.position, Vector2.right);
        Debug.DrawRay(defaultUpRightRight.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultUpRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else
        {
            zBlock.canMoveRight = true;
        }

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultDownLeftDown.position, Vector2.down);
        Debug.DrawRay(defaultDownRightDown.position, Vector2.down);
        Debug.DrawRay(defaultUpLeftDown.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultDownLeftDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }

        // check distance to bottom to see if you can rotate
        // check two blocks away from the bottom 
        // check two blocks away from the top
    }

    private void OneFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultDownLeftDown.position, Vector2.left);
        Debug.DrawRay(defaultDownRightDown.position, Vector2.left);
        Debug.DrawRay(defaultUpLeftDown.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultDownLeftDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else
        {
            zBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownRightUp.position, Vector2.right);
        Debug.DrawRay(defaultUpRightUp.position, Vector2.right);
        Debug.DrawRay(defaultUpLeftUp.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultDownRightUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else
        {
            zBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpRightRight.position, Vector2.down);
        Debug.DrawRay(defaultDownRightRight.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultUpRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }

        // check distance on sides to see if you can rotate
        // check one block away from the right
    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultDownRightRight.position, Vector2.left);
        Debug.DrawRay(defaultUpRightRight.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultDownRightRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else
        {
            zBlock.canMoveLeft = true;
        }

        //check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeftLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpLeftLeft.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultDownLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else
        {
            zBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpLeftUp.position, Vector2.down);
        Debug.DrawRay(defaultUpRightUp.position, Vector2.down);
        Debug.DrawRay(defaultDownRightUp.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultUpLeftUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }

        //check distance to bottom to see if you can rotate
        // check two blocks away from the bottom
        // check two blocks away from the top
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpLeftUp.position, Vector2.left);
        Debug.DrawRay(defaultDownRightUp.position, Vector2.left);
        Debug.DrawRay(defaultUpRightUp.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultUpLeftUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRightUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveLeft = false;
            }
        }
        else
        {
            zBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeftDown.position, Vector2.right);
        Debug.DrawRay(defaultUpLeftDown.position, Vector2.right);
        Debug.DrawRay(defaultDownRightDown.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultDownLeftDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else if (hit = Physics2D.Raycast(defaultDownRightDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.canMoveRight = false;
            }
        }
        else
        {
            zBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultDownLeftLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpLeftLeft.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultDownLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                zBlock.Deactivate();
            }
        }

        // check distance on sides to see if you can rotate
        // check one block away from the left
    }
}
