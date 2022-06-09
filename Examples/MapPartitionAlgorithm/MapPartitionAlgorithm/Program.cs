// See https://aka.ms/new-console-template for more information

using Common;
using CommonServer.WorldManagement;
using System.Numerics;

Vector2 playerPos = new Vector2(50, 50);
MapPartitionManagement mapPartitionManagement = new MapPartitionManagement();

static void Draw(MapPartitionManagement mapPartitionManagement, Vector2 playerPos)
{
	int max = 300;
	int xSize = 12;
	int ySize = 7;

	mapPartitionManagement.UpdatePlayerPartitionRegistrations(new Common.Protocol.Map.PlayerStateMessage()
	{
		Position = playerPos
	});

	var registered = mapPartitionManagement.GetRegisteredPartitions();

	var partition = new Vector2Int(playerPos);
	for (int x = max; x >= -max; x -= MapConfiguration.MapAreaSize)
	{
		for (int y = max; y >= -max; y -= MapConfiguration.MapAreaSize)
		{
			bool isPlayerPos = partition.X == x && partition.Y == y;

			bool isRegistered = registered.Contains(new Vector2Int(x, y));

			var dist = Math.Max(Math.Abs(partition.X - x), Math.Abs(partition.Y - y));
			bool isFar = dist > MapConfiguration.MapAreaSize;
			ConsoleRectangle.Draw(xSize - 2, ySize - 2, new System.Drawing.Point((x + max) / MapConfiguration.MapAreaSize * xSize, (y + max) / MapConfiguration.MapAreaSize * ySize), isPlayerPos ? ConsoleColor.Magenta : !isRegistered ? ConsoleColor.Red : isFar ? ConsoleColor.Yellow : ConsoleColor.DarkGreen);
		}
	}
}

while(true)
{
	Console.Clear();
	Draw(mapPartitionManagement, playerPos);
	string input = Console.ReadLine();

	if (input == "a")
		playerPos.X -= 100;
	else if (input == "d")
		playerPos.X += 100;
	else if (input == "w")
		playerPos.Y -= 100;
	else if (input == "s")
		playerPos.Y += 100;
	else
		break;
}


Draw(mapPartitionManagement, playerPos);
Console.ReadLine();
