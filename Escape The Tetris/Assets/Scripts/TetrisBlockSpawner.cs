using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private string thisScene = "Level1";

    [HideInInspector]
    public bool shouldMakeNew = true;

    private GameObject clone;
    private TetrisMovement activeBlock;

    private int randomNumber;

    void FixedUpdate ()
    {
        CheckInstance();
	}

    private void CheckInstance()
    {
        if(shouldMakeNew)
        {
            randomNumber = Random.Range(0, 6);
            MakeBlock(randomNumber);
            shouldMakeNew = false;
        }

        if (!activeBlock.isActive || activeBlock == null)
        {
            if (activeBlock.hasMoved == false)
            {
                TopEntered();
            }
            else
            {
                Destroy(activeBlock);
                activeBlock = null;
                shouldMakeNew = true;
            }
        }
    }

    private void MakeBlock(int choice)
    {
        switch(choice)
        {
            case 0:
                clone = Instantiate(iBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            case 1:
                clone = Instantiate(jBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            case 2:
                clone = Instantiate(lBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            case 3:
                clone = Instantiate(oBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            case 4:
                clone = Instantiate(sBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            case 5:
                clone = Instantiate(tBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            case 6:
                clone = Instantiate(zBlockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);
                break;

            default:
                Debug.Log("error in switch");
                break;
        }

        activeBlock = clone.GetComponentInChildren<TetrisMovement>();
    }

    private void TopEntered()
    {
        SceneManager.LoadScene(thisScene);
    }
}
