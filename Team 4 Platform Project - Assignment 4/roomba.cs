using Raylib_cs;
using System.Numerics;
using System.Timers;

public class Roomba
{
    public MoveGrav moveGrav;
    public List<Vector2> playerPositions;
    public bool roombaActive = false;

    public Roomba()
    {
        moveGrav = new MoveGrav();
    }

    public void PlayerPositionTracking()
    {
        playerPositions.Add(new Vector2(moveGrav.playerPosition.X, moveGrav.playerPosition.Y));
    }


    public void RoombaManager()
    {
        PlayerPositionTracking();

        if (playerPositions.Count > 10)
        {
            roombaActive = true;
        }

        if (roombaActive = true)
        {
            foreach (Vector2 position in playerPositions)
            {
                Raylib.DrawCircleV(position, 40, Color.Black);

            }
        }
    }
}
