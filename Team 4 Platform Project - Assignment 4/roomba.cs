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

    

    //As mentioned in the player script, the movement is intended to follow the players exact path. So the player could be smart and plan their route to give themselves more time. 
    //To avoid an instant game-over, the Roomba doesn't activiate until 200 player positions have been tracked
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

   //Tried to add a restart function within game over but could not make it work. - Ben
    //Game over, simple. Potential to expand to a more robust screen if team is interested/want to adjust scope. 
    public void GameOver(MoveGrav moveGrav)
    {
        
        if (moveGrav.playerIsAlive == false)
        {
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), Color.Black);
            Raylib.DrawText($"Game Over", Raylib.GetScreenWidth() / 2 - 40, Raylib.GetScreenHeight() / 2 - 40, 20, Color.Red);
        }
        
    }
}
