using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement iBlock;

    [SerializeField]
    private Transform defaultLeftLeft;

    [SerializeField]
    private Transform defaultLeftUp;

    [SerializeField]
    private Transform defaultLeftDown;

    [SerializeField]
    private Transform defaultRightUp;

    [SerializeField]
    private Transform defaultRightDown;

    [SerializeField]
    private Transform defaultRightRight;

    [SerializeField]
    private Transform defaultLeftMiddleUp;

    [SerializeField]
    private Transform defaultLeftMiddleDown;

    [SerializeField]
    private Transform defaultRightMiddleUp;

    [SerializeField]
    private Transform defaultRightMiddleDown;

    [SerializeField]
    private float oneBlockDistance = .1f;

    RaycastHit2D hit;
	
	// Update is called once per frame
	void Update ()
    {
        if (iBlock.isActive == true)
        {
            if (iBlock.flipCount == 0)
                DefaultRaycast();
            else if (iBlock.flipCount == 1)
                OneFlipRaycast();
            else if (iBlock.flipCount == 2)
                TwoFlipRaycast();
            else if (iBlock.flipCount == 3)
                ThreeFlipRaycast();
        }
	}

    private void DefaultRaycast()
    {
        // check for side collision to be able to move left
        Debug.DrawRay(defaultLeftLeft.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
            }
            else if(hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultRightRight.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(this);
            }
        }
        else
        {
            iBlock.canMoveRight = true;
        }

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultLeftDown.position, Vector2.down);
        Debug.DrawRay(defaultRightDown.position, Vector2.down);
        Debug.DrawRay(defaultLeftMiddleDown.position, Vector2.down);
        Debug.DrawRay(defaultRightMiddleDown.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if(hit = Physics2D.Raycast(defaultRightDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if(hit = Physics2D.Raycast(defaultLeftMiddleDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if(hit = Physics2D.Raycast(defaultRightMiddleDown.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
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
        Debug.DrawRay(defaultLeftMiddleDown.position, Vector2.left);
        Debug.DrawRay(defaultRightMiddleDown.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
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
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftMiddleDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightMiddleDown.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultLeftUp.position, Vector2.right);
        Debug.DrawRay(defaultRightUp.position, Vector2.right);
        Debug.DrawRay(defaultLeftMiddleUp.position, Vector2.right);
        Debug.DrawRay(defaultRightMiddleUp.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultLeftUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
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
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftMiddleUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightMiddleUp.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultRightRight.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        // check distance on sides to see if you can rotate
        // check one block away from the left
        // check two blocks away from the right

    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultRightRight.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultRightRight.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveLeft = true;
        }

        //check for side collision to be able to move right
        Debug.DrawRay(defaultLeftLeft.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultLeftUp.position, Vector2.down);
        Debug.DrawRay(defaultRightUp.position, Vector2.down);
        Debug.DrawRay(defaultLeftMiddleUp.position, Vector2.down);
        Debug.DrawRay(defaultRightMiddleUp.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
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
                iBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftMiddleUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightMiddleUp.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
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
        Debug.DrawRay(defaultLeftUp.position, Vector2.left);
        Debug.DrawRay(defaultRightUp.position, Vector2.left);
        Debug.DrawRay(defaultLeftMiddleUp.position, Vector2.left);
        Debug.DrawRay(defaultRightMiddleUp.position, Vector2.left);

        if (hit = Physics2D.Raycast(defaultLeftUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
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
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftMiddleUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightMiddleUp.position, Vector2.left, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveLeft = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveLeft = true;
        }

        // check for side collision to be able to move right
        Debug.DrawRay(defaultLeftDown.position, Vector2.right);
        Debug.DrawRay(defaultRightDown.position, Vector2.right);
        Debug.DrawRay(defaultLeftMiddleDown.position, Vector2.right);
        Debug.DrawRay(defaultRightMiddleDown.position, Vector2.right);

        if (hit = Physics2D.Raycast(defaultLeftDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
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
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultLeftMiddleDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else if (hit = Physics2D.Raycast(defaultRightMiddleDown.position, Vector2.right, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.canMoveRight = false;
            }
            else if (hit.transform.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            iBlock.canMoveRight = true;
        }

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultLeftLeft.position, Vector2.down);

        if (hit = Physics2D.Raycast(defaultLeftLeft.position, Vector2.down, oneBlockDistance))
        {
            if (hit.transform.tag == "TetrisBlock")
            {
                iBlock.Deactivate();
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
