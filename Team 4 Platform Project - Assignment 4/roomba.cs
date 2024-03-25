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


    //public Texture2D RoombaTexture = Raylib.LoadTexture("../../../resources/visuals/Roomba_Sheet.png");

    public void RoombaManager(MoveGrav moveGrav)
    {
        if (moveGrav.playerPositions.Count > 200)
        {
            roombaActive = true;
        }

        if (roombaActive == true)
        {
            for (int i = 0; i < moveGrav.playerPositions.Count; i++)
            {
                Raylib.DrawCircleV(moveGrav.playerPositions[i], 40, Color.Black);
                moveGrav.playerPositions.RemoveAt(i);
                if (roombaActive == true)
                {
                    float distance = Vector2.Distance(moveGrav.playerPositions[i], moveGrav.playerPosition);
                    float radii = 25;
                    if (distance < radii)
                    {
                        moveGrav.playerIsAlive = false;
                        
                        
                    }
                }
                GameOver(moveGrav);
                break;
            }
            





        }
        
    }

   

    public void GameOver(MoveGrav moveGrav)
    {
        
        if (moveGrav.playerIsAlive == false)
        {
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Color.Black);
            Raylib.DrawText($"Game Over", Raylib.GetScreenWidth() / 2 - 40, Raylib.GetScreenHeight() / 2 - 40, 20, Color.Red);
        }
        
    }
}
