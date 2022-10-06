using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	private Vector3 moveDirection;
	private StarterAssets.StarterAssetsInputs _input;

	void Start ()
    {
		_input = GetComponent<StarterAssets.StarterAssetsInputs>();
	}

	void Update () 
	{
		moveDirection = new Vector3(_input.move.x,0, _input.move.y).normalized;
		//moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
	}

	void FixedUpdate () 
	{
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
	}
}