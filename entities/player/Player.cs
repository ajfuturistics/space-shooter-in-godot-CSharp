using Godot;
using System;

public partial class Player : Node2D
{
	public int direction = 0;
	public int speed = 10;
	public int playerHalfWidth = 16;
	private PackedScene bulletScene = ResourceLoader.Load<PackedScene>("res://entities/bullet/bullet.tscn");
	public float shootTimer = 1.0f;
	public float shootCounter = 0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		shootCounter += (float)delta;
		if (Input.IsActionPressed("shoot") && shootCounter > shootTimer)
			if (Input.IsActionPressed("shoot") && shootCounter > shootTimer)
			{
				shootCounter = 0;

				// Create an instance of the bullet scene
				Node2D bulletInstance = bulletScene.Instantiate<Node2D>();

				// Set the position of the bullet instance
				bulletInstance.Position = new Vector2(Position.X, Position.Y - 20);

				// Add the bullet instance as a child of the current node
				GetParent().GetNode("Bullets").AddChild(bulletInstance);


			}
		if (Input.IsActionPressed("move_left"))
		{
			direction--;
		}
		else if (Input.IsActionPressed("move_right"))
		{
			direction++;
		}
		else
		{
			direction = 0;
		}

		// Position = new Vector2((float)(Position.X + (direction * speed * delta)), Position.Y);
		Position = new Vector2((float)Mathf.Clamp(Position.X + (direction * speed * delta), playerHalfWidth, 400 - playerHalfWidth), Position.Y);

	}
}
