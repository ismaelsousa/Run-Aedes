using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	public Vector2 startPos;
	public Vector2 direction;
	public PlayerController scriptPlayer;
	private bool action = false;
	private int count = 0;



	void Update()
	{

	
		// Track a single touch as a direction control.
		if (Input.touchCount > 0){

			count++;

			Vector2 touch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			// Handle finger movements based on touch phase.
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				action = false;
				// Record initial touch position.			
				startPos = new Vector2 (touch.x, touch.y);
			}
			if (count > 3 && action == false) {
				count = 0;
				if (Input.GetTouch (0).phase == TouchPhase.Moved && action == false) { 
					action = true;
					// Determine direction by comparing the current touch position with the initial one.
					direction = touch;

					if (direction.y > startPos.y) {
						scriptPlayer.touchJump ();
					} else {
						scriptPlayer.touchslide ();
					}

				}
			}

			/*/ Handle finger movements based on touch phase.
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				// Record initial touch position.

			}

			if(Input.GetTouch(0).phase ==TouchPhase.Moved){ 
				// Determine direction by comparing the current touch position with the initial one.		
				direction = touch - startPos;
				// Report that a direction has been chosen when the finger is lifted.
				if (direction.y < touch.y) {
					//Up
					scriptPlayer.touchJump ();
				} else {
					//Down
					scriptPlayer.touchslide ();
				}
			}

			if(Input.GetTouch(0).phase == TouchPhase.Ended){
				
			}*/
		}

	}

}
