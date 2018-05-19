﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfy : AIManager
{
	public GameObject player;
	[HideInInspector]
	public bool isWolfVisible;
	public float wolfForce = 100;
	bool panic = false;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}



	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y >= -2 && panic == false)
		{
			panic = true;
		}
		if (transform.position.y < -2)
		{
			panic = false;
		}

		if (rb.velocity.magnitude > maxMagnitude)
		{
			rb.velocity = rb.velocity / (rb.velocity.magnitude / maxMagnitude);
		}
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player")
		{
			Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
			Invoke("EnableCollisions", 0.2f);
			if (collision.contacts.Length > 0)
			{
				Vector2 impactPoint = new Vector2(collision.contacts[0].point.x - transform.position.x, collision.contacts[0].point.y - transform.position.y);
				Vector2 impactSpeed = new Vector2(collision.contacts[0].relativeVelocity.x - rb.velocity.x, collision.contacts[0].relativeVelocity.y - rb.velocity.y);

				impactPoint = -impactPoint.normalized;
				float magnitude = Mathf.Sqrt(impactSpeed.magnitude) * playerForce;
				if (magnitude < minMagnitude)
					magnitude = minMagnitude;
				rb.AddForce(impactPoint * magnitude);

			}
		}
		else if (collision.gameObject.tag == "Cow")
		{
			if (collision.contacts.Length > 0)
			{

				Vector2 impactPoint = new Vector2(collision.contacts[0].point.x - transform.position.x, collision.contacts[0].point.y - transform.position.y);

				impactPoint = -impactPoint.normalized;

				rb.AddForce(impactPoint * wolfForce);
				collision.gameObject.GetComponent<Rigidbody2D>().AddForce(impactPoint * cowForce);
			}
		}
	}

	void EnableCollisions () {
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
	}

	private void OnBecameVisible () {
		isWolfVisible = true;
	}
}