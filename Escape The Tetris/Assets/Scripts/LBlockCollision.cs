using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement lBlock;

    [SerializeField]
    private Transform defaultLeft;

    [SerializeField]
    private Transform defaultRight;

    [SerializeField]
    private Transform defaultMiddle;

    [SerializeField]
    private Transform defaultUp;

    [SerializeField]
    private float oneBlockDistance;

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
        Debug.DrawRay(defaultLeft.position, Vector2.left);
        Debug.DrawRay(defaultUp.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultRight.position, Vector2.right);
        Debug.DrawRay(defaultUp.position, Vector2.right);

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultLeft.position, Vector2.down);
        Debug.DrawRay(defaultRight.position, Vector2.down);
        Debug.DrawRay(defaultMiddle.position, Vector2.down);

        // check distance to bottom to see if you can rotate
        // check two blocks away from the bottom 
        // check two blocks away from the top
    }

    private void OneFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultLeft.position, Vector2.left);
        Debug.DrawRay(defaultRight.position, Vector2.left);
        Debug.DrawRay(defaultMiddle.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUp.position, Vector2.right);
        Debug.DrawRay(defaultLeft.position, Vector2.right);
        Debug.DrawRay(defaultMiddle.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultRight.position, Vector2.down);
        Debug.DrawRay(defaultUp.position, Vector2.down);

        // check distance on sides to see if you can rotate
        // check one blocks away from the left
        // check two block away from the right

    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultRight.position, Vector2.left);
        Debug.DrawRay(defaultUp.position, Vector2.left);

        //check for side collision to be able to move right
        Debug.DrawRay(defaultLeft.position, Vector2.right);
        Debug.DrawRay(defaultUp.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUp.position, Vector2.down);
        Debug.DrawRay(defaultLeft.position, Vector2.down);
        Debug.DrawRay(defaultMiddle.position, Vector2.down);

        //check distance to bottom to see if you can rotate
        // check two blocks away from the bottom
        // check two blocks away from the top
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUp.position, Vector2.left);
        Debug.DrawRay(defaultLeft.position, Vector2.left);
        Debug.DrawRay(defaultMiddle.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultLeft.position, Vector2.right);
        Debug.DrawRay(defaultRight.position, Vector2.right);
        Debug.DrawRay(defaultMiddle.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultLeft.position, Vector2.down);
        Debug.DrawRay(defaultUp.position, Vector2.down);

        // check distance on sides to see if you can rotate
        // check two blocks away from the left
        // check one block away from the right
    }
}
