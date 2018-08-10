using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicUp : MonoBehaviour
{
  // Speed of player.
  public int rotation_speed=7;

  // Update.
  void Update ()
  {
    // Rotate pick up element.
    this.transform.Rotate(new Vector3(15,30,45)*Time.deltaTime*rotation_speed);
	} // End of Update

} // End of PicUp
