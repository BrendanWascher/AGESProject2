using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject iBlockPrefab;

    [SerializeField]
    private GameObject jBlockPrefab;

    [SerializeField]
    private GameObject lBlockPrefab;

    [SerializeField]
    private GameObject oBlockPrefab;

    [SerializeField]
    private GameObject sBlockPrefab;

    [SerializeField]
    private GameObject tBlockPrefab;

    [SerializeField]
    private GameObject zBlockPrefab;

    [SerializeField]
    private Transform blockSpawnPoint;

    [HideInInspector]
    public bool shouldMakeNew = true;

    private GameObject clone;
    private TetrisMovement activeBlock;

    void FixedUpdate ()
    {
        CheckInstance();
	}

    private void CheckInstance()
    {
        if(shouldMakeNew)
        {
            clone = Instantiate(zBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
            activeBlock = clone.GetComponentInChildren<TetrisMovement>();
            shouldMakeNew = false;
        }

        if (!activeBlock.isActive)
        {
            Destroy(activeBlock);
            activeBlock = null;
            shouldMakeNew = true;
        }
    }
}
