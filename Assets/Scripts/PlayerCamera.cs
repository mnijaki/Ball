using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  // Player.
  public GameObject player;

  // Offset of the player camera.
  private Vector3 offset;

	// Initialization.
	void Start()
  {
    // Get the offset between players camera and player.
    this.offset=this.transform.position-player.transform.position;
    // Disable main camera.
    Camera.main.gameObject.SetActive(false);
    //Camera.main.enabled=false;
    //Camera.main.GetComponent<AudioListener>().enabled=false;
  } // End of Start

  // Update called after all 'Upadte()' methods.
  void LateUpdate()
  {
    // Calculate new player camera position.
    this.transform.position=player.transform.position+offset;
  } // End of LateUpdate

} // End of PlayerCamera
