using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement lBlock;

    [SerializeField]
    private Transform defaultLeftLeft;

    [SerializeField]
    private Transform defaultLeftUp;

    [SerializeField]
    private Transform defaultLeftDown;

    [SerializeField]
    private Transform defaultRightRight;

    [SerializeField]
    private Transform defaultRightDown;

    [SerializeField]
    private Transform defaultMiddleUp;

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

    // Update is called once per frame
    void Update()
    {
        if (lBlock.isActive == true)
        {
            if (lBlock.flipCount == 0)
                DefaultRaycast();
            else if (lBlock.flipCount == 1)
                OneFlipRaycast();
            else if (lBlock.flipCount == 2)
                TwoFlipRaycast();
            else if (lBlock.flipCount == 3)
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
                lBlock.canMoveLeft = false;
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
                lBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultRightRight.position, Vector2.right);
        Debug.DrawRay(defaultUpRight.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveRight = false;
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
                lBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveRight = true;
        }

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultLeftDown.position, Vector2.down);
        Debug.DrawRay(defaultRightDown.position, Vector2.down);
        Debug.DrawRay(defaultMiddleDown.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.Deactivate();
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
                lBlock.Deactivate();
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
                lBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        // check distance to bottom to see if you can rotate
        // check two blocks away from the bottom 
        // check two blocks away from the top
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
                lBlock.canMoveLeft = false;
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
                lBlock.canMoveLeft = false;
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
                lBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUpUp.position, Vector2.right);
        Debug.DrawRay(defaultLeftUp.position, Vector2.right);
        Debug.DrawRay(defaultMiddleUp.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultUpUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveRight = false;
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
                lBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultMiddleUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultRightRight.position, Vector2.down);
        Debug.DrawRay(defaultUpRight.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.Deactivate();
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
                lBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        // check distance on sides to see if you can rotate
        // check one blocks away from the left
        // check two block away from the right

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
                lBlock.canMoveLeft = false;
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
                lBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveLeft = true;
        }

        //check for side collision to be able to move right
        Debug.DrawRay(defaultLeftLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpLeft.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveRight = false;
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
                lBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpUp.position, Vector2.down);
        Debug.DrawRay(defaultLeftUp.position, Vector2.down);
        Debug.DrawRay(defaultMiddleUp.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultUpUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.Deactivate();
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
                lBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultMiddleUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        //check distance to bottom to see if you can rotate
        // check two blocks away from the bottom
        // check two blocks away from the top
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpUp.position, Vector2.left);
        Debug.DrawRay(defaultLeftUp.position, Vector2.left);
        Debug.DrawRay(defaultMiddleUp.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultUpUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveLeft = false;
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
                lBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultMiddleUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultLeftDown.position, Vector2.right);
        Debug.DrawRay(defaultRightDown.position, Vector2.right);
        Debug.DrawRay(defaultMiddleDown.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.canMoveRight = false;
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
                lBlock.canMoveRight = false;
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
                lBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultLeftLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpLeft.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                lBlock.Deactivate();
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
                lBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }

        // check distance on sides to see if you can rotate
        // check two blocks away from the left
        // check one block away from the right
    }
}
