using Godot;
using System;

public partial class Bullet : Node2D
{
	public int bulletSpeed = 200;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, (float)(Position.Y - bulletSpeed * delta));

		if (Position.Y < 0)
		{
			QueueFree();
		}
	}
}
