using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private string thisScene = "Level1";

    [SerializeField]
    private TetrisBlockSpawner thisSpawner;

    [SerializeField]
    private AudioSource soundSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            soundSource.Play();
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
            StartCoroutine(PlayDeathBeforeLoad());
        }
    }

    private IEnumerator PlayDeathBeforeLoad()
    {

        while (soundSource.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(thisScene);
        yield return null;
    }
}
