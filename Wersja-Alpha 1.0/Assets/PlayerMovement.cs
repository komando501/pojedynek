using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private CharacterController player;

	public float Speed;

	void Start()
	{
		player = GetComponent<CharacterController>();
	}

	void Update()
	{
		Vector2 Move = Vector2.zero;
		Move.x = Input.GetAxis("Horizontal") * Speed;
		player.Move(Move * Time.deltaTime);
	}
}