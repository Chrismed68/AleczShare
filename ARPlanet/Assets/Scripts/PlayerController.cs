using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	private Animator anim;
	private CharacterController controller;


	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;
	private Vector2 touchStart, touchEnd;

	public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	// At the start of the game..
	void Start ()
	{
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 


		// Run the SetCountText function to update the UI (see below)


		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank

	}

	// Each physics step..
	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		// Swipe start
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			touchStart = Input.GetTouch(0).position;
			anim.SetInteger("AnimationPar", 1);
			Vector3 move = transform.right * x + transform.forward * z;
			controller.Move(move * speed * Time.deltaTime);

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
		// Swipe end
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			touchEnd = Input.GetTouch(0).position;
			float cameraFacing = Camera.main.transform.eulerAngles.y;
			Vector2 swipeVector = touchEnd - touchStart;
			Vector3 inputVector = new Vector3(swipeVector.x, 0.0f, swipeVector.y);
			Vector3 movement = Quaternion.Euler(0.0f, cameraFacing, 0.0f) * Vector3.Normalize(inputVector);
			rb.velocity = movement;
			anim.SetInteger("AnimationPar", 0);
		}
		
		
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved

}