using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalPlayerController : MonoBehaviour
{

	public float moveSpeed;
	float jumpForce = 0f;
	public bool onGround = true;

	public GameObject[] projectilePrefab;

	private Vector3 moveDirection;
	
	private StarterAssets.StarterAssetsInputs _input;

	private Animator _animator;

	public GameManager gameManager;

	//public float sphereRadius;

	void Start()
	{
		_input = GetComponent<StarterAssets.StarterAssetsInputs>();

		_animator = GetComponent<Animator>();


		//gameManager = Find.GetComponent<GameManager>();
		//gameManager = GetComponent<GameManager>();
	}
	/*
	void OnCollisionEnter(Collider col)
	{
		
		if (col.CompareTag("Terrain"))
		{
			onGround = true;
			Debug.Log("on ground");
        }
        else
        {
			onGround = false;
			Debug.Log("not on ground");
        }
		

		Debug.Log("hi");
	}
	*/

	void OnCollisionEnter(Collision toucher)
	{
		if (toucher.gameObject.tag == "Terrain")
		{
			jumpForce = 0;
			onGround = true;
			Debug.Log("on ground");
		}
		/*else
		{
			onGround = false;
			Debug.Log("not on ground");
		}

		Debug.Log("hi");*/
	}

	void Update()
	{
		float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");
		float moveMagnitude = new Vector3(horizontalMovement, 0, verticalMovement).magnitude;

		if (gameManager.gameOver == true)
        {
			return;
        }

		if (Input.GetKeyDown(KeyCode.F))
		{
			int projectilePrefabIndex = Random.Range(0, projectilePrefab.Length);
			Instantiate(projectilePrefab[projectilePrefabIndex], transform.position, projectilePrefab[projectilePrefabIndex].transform.rotation);

		}

		if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
			jumpForce += 20f;
			Debug.Log("we up");
			onGround = false;
        }

			//moveDirection = new Vector3(_input.move.x, 0, _input.move.y).normalized;

		moveDirection = new Vector3(horizontalMovement, jumpForce, verticalMovement).normalized;

		//horizontalMovement = Input.GetAxis("Horizontal");
		//verticalMovement = Input.GetAxis("Vertical");

		//Vector3 jumpMagnitude = new Vector3(0, jumpForce, 0);

		Debug.Log(moveMagnitude);

		_animator.SetFloat("Speed", moveMagnitude * 4);
		_animator.SetFloat("MotionSpeed", moveMagnitude);
	}

	void FixedUpdate()
	{
		if (gameManager.gameOver == true)
		{
			return;
		}
		
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
		

        //else
        {
			//moveSpeed = 0;
			//GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
		}


	}
}