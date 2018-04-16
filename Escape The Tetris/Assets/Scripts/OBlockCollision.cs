using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBlockCollision : MonoBehaviour
{
    [SerializeField]
    private TetrisMovement oBlock;

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
        Debug.DrawRay(defaultUpLeft.position, Vector2.left);
        Debug.DrawRay(defaultDownLeft.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUpRight.position, Vector2.right);
        Debug.DrawRay(defaultDownRight.position, Vector2.right);

        // check for bottom collison to stop moving
        Debug.DrawRay(defaultDownLeft.position, Vector2.down);
        Debug.DrawRay(defaultDownRight.position, Vector2.down);
    }

    private void OneFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultDownLeft.position, Vector2.left);
        Debug.DrawRay(defaultDownRight.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultUpLeft.position, Vector2.right);
        Debug.DrawRay(defaultUpRight.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpRight.position, Vector2.down);
        Debug.DrawRay(defaultDownRight.position, Vector2.down);
    }

    private void TwoFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpRight.position, Vector2.left);
        Debug.DrawRay(defaultDownRight.position, Vector2.left);

        //check for side collision to be able to move right
        Debug.DrawRay(defaultUpLeft.position, Vector2.right);
        Debug.DrawRay(defaultDownLeft.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultUpLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpRight.position, Vector2.down);
    }

    private void ThreeFlipRaycast()
    {
        //check for side collision to be able to move left
        Debug.DrawRay(defaultUpLeft.position, Vector2.left);
        Debug.DrawRay(defaultUpRight.position, Vector2.left);

        // check for side collision to be able to move right
        Debug.DrawRay(defaultDownLeft.position, Vector2.right);
        Debug.DrawRay(defaultDownRight.position, Vector2.right);

        // check for bottom collision to stop moving
        Debug.DrawRay(defaultDownLeft.position, Vector2.down);
        Debug.DrawRay(defaultUpLeft.position, Vector2.down);
    }
}
