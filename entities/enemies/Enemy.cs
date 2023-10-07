using Godot;
using System;

public partial class Enemy : Area2D
{
	public int speed = 50;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Randomize();
		Position = new Vector2(GD.RandRange(0, 400), 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, (float)(Position.Y + speed * delta));
	}

	public void _on_area_entered(Area2D area)
	{

		if (area.Name == "BulletArea")
		{
			area.GetParent().QueueFree();
			QueueFree();
		}
	}
}

