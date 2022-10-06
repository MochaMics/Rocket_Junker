using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{

	public float moveSpeed;
	public GameObject[] projectilePrefab;

	private Vector3 moveDirection;
	private StarterAssets.StarterAssetsInputs _input;
	

	void Start()
	{
		_input = GetComponent<StarterAssets.StarterAssetsInputs>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			int projectilePrefabIndex = Random.Range(0, projectilePrefab.Length);
			Instantiate(projectilePrefab[projectilePrefabIndex], transform.position, projectilePrefab[projectilePrefabIndex].transform.rotation);

		}

		//moveDirection = new Vector3(_input.move.x, 0, _input.move.y).normalized;
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
	}
}