using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedPiece : MonoBehaviour
{
    public bool isHitByPlayer = false;
    public bool isHitByGround = false;
    public bool shouldKillPlayer = false;

    [SerializeField]
    private GameObject attachedPiece;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TetrisBlock" && collision.gameObject != attachedPiece)
        {
            isHitByGround = true;
        }
        else if (collision.gameObject.tag == "Player")
        {
            isHitByPlayer = true;
            if (PlayerMovement.isOnGround == true)
            {

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isHitByPlayer = false;
    }
}
