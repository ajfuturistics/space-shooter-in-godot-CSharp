using Godot;
using System;
using System.Threading;

public partial class EnemySpawner : Node
{
	private PackedScene enemyScene = ResourceLoader.Load<PackedScene>("res://entities/enemies/enemy.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Area2D boundary = GetParent().GetNode<Area2D>("Boundary");
		boundary.AreaEntered += _TheEnd;

		Godot.Timer timer = new Godot.Timer();
		AddChild(timer);
		timer.WaitTime = 1.5f;
		timer.Timeout += () => _SpawnEnemy();
		timer.Start();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _SpawnEnemy()
	{
		Node2D enemyInstance = enemyScene.Instantiate<Node2D>();
		GetParent().GetNode("Enemies").AddChild(enemyInstance);
	}

	private void _TheEnd(Area2D area)
	{
		// Your code for handling the "area_entered" signal goes here
		if (area is Enemy)
		{
			GD.Print("You Lose!");
			GetTree().Paused = true;
		}
	}
}
