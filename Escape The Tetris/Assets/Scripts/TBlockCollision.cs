using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement tBlock;

    [SerializeField]
    private Transform defaultLeftLeft;

    [SerializeField]
    private Transform defaultLeftUp;

    [SerializeField]
    private Transform defaultLeftDown;

    [SerializeField]
    private Transform defaultRightRight;

    [SerializeField]
    private Transform defaultRightUp;

    [SerializeField]
    private Transform defaultRightDown;

    [SerializeField]
    private Transform defaultMiddleDown;

    [SerializeField]
    private Transform defaultUpUp;

    [SerializeField]
    private Transform defaultUpLeft;

    [SerializeField]
    private Transform defaultUpRight;

    [SerializeField]
    private float oneBlockDistance = .1f;

    RaycastHit2D hit;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    RaycastHit2D hit4;

    // Update is called once per frame
    void Update()
    {
        if (tBlock.isActive == true)
        {
            if (tBlock.flipCount == 0)
                DefaultRaycast();
            else if (tBlock.flipCount == 1)
                OneFlipRaycast();
            else if (tBlock.flipCount == 2)
                TwoFlipRaycast();
            else if (tBlock.flipCount == 3)
                ThreeFlipRaycast();
        }
    }

    private void DefaultRaycast()
    {
        // check for side collision to be able to move left
        Debug.DrawRay(defaultLeftLeft.position, Vector2.left);
        Debug.DrawRay(defaultUpLeft.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeft.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultRightRight.position, Vector2.right);
        Debug.DrawRay(defaultUpRight.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveRight = true;
        }

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultLeftDown.position, Vector2.down);
        Debug.DrawRay(defaultRightDown.position, Vector2.down);
        Debug.DrawRay(defaultMiddleDown.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultMiddleDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        // check distance to bottom to see if you can rotate
        // check one blocks away from the bottom
    }

    private void OneFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultLeftDown.position, Vector2.left);
        Debug.DrawRay(defaultRightDown.position, Vector2.left);
        Debug.DrawRay(defaultMiddleDown.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultMiddleDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUpUp.position, Vector2.right);
        Debug.DrawRay(defaultRightUp.position, Vector2.right);
        Debug.DrawRay(defaultLeftUp.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultUpUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultRightRight.position, Vector2.down);
        Debug.DrawRay(defaultUpRight.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        // check distance on sides to see if you can rotate
        // check one blocks away from the left
    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultRightRight.position, Vector2.left);
        Debug.DrawRay(defaultUpRight.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveLeft = true;
        }

        //check for side collision to be able to move right
        Debug.DrawRay(defaultLeftLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpLeft.position, Vector2.right);
        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpUp.position, Vector2.down);
        Debug.DrawRay(defaultRightUp.position, Vector2.down);
        Debug.DrawRay(defaultLeftUp.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultUpUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        //check distance to bottom to see if you can rotate
        // check one blocks away from the top
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpUp.position, Vector2.left);
        Debug.DrawRay(defaultRightUp.position, Vector2.left);
        Debug.DrawRay(defaultLeftUp.position, Vector2.left);
        if (hit = Physics2D.Raycast(defaultUpUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultLeftDown.position, Vector2.right);
        Debug.DrawRay(defaultRightDown.position, Vector2.right);
        Debug.DrawRay(defaultMiddleDown.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultMiddleDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            tBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultLeftLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpLeft.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultUpLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                tBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        // check distance on sides to see if you can rotate 
        // check one block away from the right
    }
}
