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

    public static int levelNumber = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player is at door");

            if (Input.GetAxis("Vertical") > 0)
            {
                levelNumber++;
                doorSound.Play();
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
