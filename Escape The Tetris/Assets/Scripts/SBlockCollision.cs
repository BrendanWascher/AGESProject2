using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement sBlock;

    [SerializeField]
    private Transform defaultUpLeft;

    [SerializeField]
    private Transform defaultUpRight;

    [SerializeField]
    private Transform defaultDownLeft;

    [SerializeField]
    private Transform defaultDownRight;

    [SerializeField]
    private float oneBlockDistance;

    // Update is called once per frame
    void Update()
    {
        if (sBlock.isActive == true)
        {
            if (sBlock.flipCount == 0)
                DefaultRaycast();
            else if (sBlock.flipCount == 1)
                OneFlipRaycast();
            else if (sBlock.flipCount == 2)
                TwoFlipRaycast();
            else if (sBlock.flipCount == 3)
                ThreeFlipRaycast();
        }
    }

    private void DefaultRaycast()
    {
        // check for side collision to be able to move left
        Debug.DrawRay(defaultUpLeft.position, Vector2.left);
        Debug.DrawRay(defaultDownLeft.position, Vector2.left);
        //RaycastHit2D hit = Physics2D.Raycast(defaultUpLeft.position, Vector2.left, oneBlockDistance);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownRight.position, Vector2.right);
        Debug.DrawRay(defaultUpRight.position, Vector2.right);

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultDownLeft.position, Vector2.down);
        Debug.DrawRay(defaultDownRight.position, Vector2.down);

        // check distance to bottom to see if you can rotate
        // check two blocks away from the bottom 
        // check two blocks away from the top
    }

    private void OneFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultDownLeft.position, Vector2.left);
        Debug.DrawRay(defaultDownRight.position, Vector2.left);
        Debug.DrawRay(defaultUpRight.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpRight.position, Vector2.right);
        Debug.DrawRay(defaultUpLeft.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpRight.position, Vector2.down);
        Debug.DrawRay(defaultDownRight.position, Vector2.down);

        // check distance on sides to see if you can rotate
        // check one block away from the left
    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultDownRight.position, Vector2.left);
        Debug.DrawRay(defaultUpRight.position, Vector2.left);

        //check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpLeft.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpRight.position, Vector2.down);

        //check distance to bottom to see if you can rotate
        // check two blocks away from the bottom
        // check two blocks away from the top
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpLeft.position, Vector2.left);
        Debug.DrawRay(defaultDownLeft.position, Vector2.left);
        Debug.DrawRay(defaultUpRight.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpRight.position, Vector2.right);
        Debug.DrawRay(defaultDownRight.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultDownLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpLeft.position, Vector2.down);

        // check distance on sides to see if you can rotate
        // check one block away from the right
    }
}
