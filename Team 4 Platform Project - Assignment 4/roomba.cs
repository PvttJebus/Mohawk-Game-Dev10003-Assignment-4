using Raylib_cs;
using System.Numerics;
using System.Timers;

public class Roomba
{
    public MoveGrav moveGrav;
    
    public bool roombaActive = false;

    public Roomba()
    {
        moveGrav = new MoveGrav();
        
    }

    


    public void RoombaManager(MoveGrav moveGrav)
    {
        if (moveGrav.playerPositions.Count > 100)
        {
            roombaActive = true;
        }

        if (roombaActive == true)
        {
            for (int i = 0; i < moveGrav.playerPositions.Count; i++)
            {
                Raylib.DrawCircleV(moveGrav.playerPositions[i], 40, Color.Black);
                moveGrav.playerPositions.RemoveAt(i);
            }
            





        }
    }
}
