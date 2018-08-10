using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* Info:
 * To run some triggers on collision, gameobject must have checked is_trigger in box_collider component.
 * To make static coliders (default all objects have statick collider) to be dynamic collider 
 * add RigidBody to GameObject. Static coliders position are recalculated evry time they move, so cache
 * memory will be usless if u move static objects. If u want to move game object make them dynamic.
 * If u dont want to make triggers for rigidbody of dynamic gameobject click IsKinematic on rigidbody. 
 * Kinematic rigidbidy will not react to physics forces, bu will be animated by for eg. rotation.
*/
public class Player : MonoBehaviour
{
  // Player rigidbody.
  private Rigidbody rb;

  // Counter text.
  public Text counter_text;

  // Time text.
  public Text time_text;

  // End game text.
  public Text end_game_text;

  // Information if game has ended.
  private bool is_game_ended;

  // Speed of player.
  public int speed=7;

  // Count of picked up object.
  private int counter;

  // Timer.
  private float timer;

  // Initialization.
  void Start()
  {
    // Default game has not ended.
    is_game_ended=false;
    // Get the rigidbody of player.
    this.rb = this.GetComponent<Rigidbody>();
    // Set the counter;
    this.counter=0;
    // Set the counter text.
    CounterTextSet();
    // Set the timer.
    this.timer=0.0f;
    // Set time text.
    TimeTextSet();
    // Set the end game text.
    this.end_game_text.text="";
  } // End of Start

  // Update.
  private void Update()
  {
    // If game ended then exit from function.
    if(this.is_game_ended)
    {
      return;
    }
    // Actualize timer.
    this.timer+=Time.deltaTime;
    // Set time text.
    TimeTextSet();
  } // End of Update

  // Called before performing any physics calculations.
  void FixedUpdate()
  {    
    // If game ended then exit from function.
    if(this.is_game_ended)
    {
      return;
    }
    // Get input position.
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");
    // Creat a movment vector;
    Vector3 movment = new Vector3(x,0.0f,z);
    // Add a force to player rigidbody.
    this.rb.AddForce(movment*this.speed);


    // Debug.
    //Debug.Log("Input x="+x+" Input y="+z);
    //Debug.Log("Force="+this.rb.velocity.ToString());
  } // End of FixedUpdate

  // Event that triiger on collision.
  private void OnTriggerEnter(Collider other)
  {
    // If player collided with pick up element.
    if(other.gameObject.CompareTag("pick_up"))
    {
      // Deactivate collided pick up element.
      other.gameObject.SetActive(false);
      // Increment counter.
      this.counter++;
      // Set the counter text.
      CounterTextSet();
      // Set the count text.
      this.counter_text.text="Count = "+counter.ToString();
      // If player collects all pick ups.
      if(counter>14)
      {
        // Set game as ended.
        this.is_game_ended=true;
        // Stop movment of the ball.
        this.rb.velocity=Vector3.zero;
        // Place the ball on the center.
        this.transform.position=new Vector3(0,0,0);
        // Disable ball.
        //this.GetComponent<GameObject>().SetActive(false);
        this.GetComponent<MeshRenderer>().enabled=false;
        // Set end game text.
        this.end_game_text.text="YOU WIN";
      }
    }

  } // End of OnTriggerEnter

  // Actualize counter text.
  void CounterTextSet()
  {
    // Set the count text.
    this.counter_text.text="Count = "+this.counter.ToString();
  } // End of CounterTextSet

  // Actualize time text.
  void TimeTextSet()
  {
    // Set the count text.
    this.time_text.text="Time = "+this.timer.ToString();
  } // End of TimeTextSet

} // End of Player
