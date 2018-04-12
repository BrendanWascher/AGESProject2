using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager 
{
    public GameObject blockInstance;
    public bool isActive;
    private TetrisMovement thisTetrisBlock;
    
    public void Setup()
    {
        thisTetrisBlock = blockInstance.GetComponent<TetrisMovement>();
        isActive = thisTetrisBlock.isActive;
    }

    public void UpdateThis()
    {
        isActive = thisTetrisBlock.isActive;
    }
}
