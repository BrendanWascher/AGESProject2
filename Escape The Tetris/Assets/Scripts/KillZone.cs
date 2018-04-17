using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private string thisScene = "Level1";

    [SerializeField]
    private TetrisBlockSpawner thisSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(thisScene);
        }
    }
}
