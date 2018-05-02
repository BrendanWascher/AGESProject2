using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField]
    private string loadSceneName = "Level1";

    [SerializeField]
    private AudioSource doorSound;

    public static int levelNumber = 0;
    public static int totalLevels = 5;

    private bool canEnter = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canEnter)
        {
            //Debug.Log("Player is at door");

            if (Input.GetAxis("Vertical") > 0)
            {
                levelNumber++;
                doorSound.Play();
                canEnter = false;
                StartCoroutine(EnterDoor());
            }
        }
    }

    private IEnumerator EnterDoor()
    {

        while (doorSound.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(loadSceneName);
        yield return null;
    }


}
