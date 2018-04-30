using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    /*
    [SerializeField]
    private Transform minHeight;
    */

    [SerializeField]
    private Transform maxHeight;

    [SerializeField]
    private Transform camera;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        CheckHeight();
	}

    private void CheckHeight()
    {
        if(player.position.y > maxHeight.position.y)
        {
            camera.position.Set(camera.position.x,
                player.position.y, camera.position.z);
        }
    }
}
