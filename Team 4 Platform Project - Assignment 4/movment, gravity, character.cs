using Raylib_cs;
using System.Numerics;
using System.Timers;

public class MoveGrav
{
    public Vector2 playerPosition = new Vector2(400, Raylib.GetScreenHeight()) / 2;
    public Vector2 playerVelocity;
    public Vector2 gravity = new Vector2(0, 5f);
    public bool hasJumped = false;
    public List<Vector2> playerPositions;
    public bool playerIsAlive = true;

    public MoveGrav()
    {
        playerPositions = new List<Vector2>();
    }

    //Character controller using a simple shape, which will be replaced by textures uploaded by other team members. 
    public void CharacterController()
    {
        Raylib.DrawCircleV(playerPosition, 25, Color.Blue);
        GravitySim();
        PlayerMovement();
        PlayerPositionTracking();
        
    }

    //When designing the roomba movement, I thought of it being akin to Moe in Walle, who follows exactly where walle went, so the roomba tracks all the positions the dustbunny went, so it can follow. 
    public void PlayerPositionTracking()
    {
        playerPositions.Add(new Vector2(playerPosition.X, playerPosition.Y));
    }

    //Addin gravity as we we want the bunny to be able to hop across the level
    public void GravitySim()
    {
        float deltaTime = Raylib.GetFrameTime();
        Vector2 gravityForce = deltaTime * gravity;
        playerVelocity += gravityForce;
        playerPosition += playerVelocity;
    }

    //Movement, the most challenge part was trying to add a timer on jumping, so the player couldn't just jump repeatidly. So it should be a 2 - 3 second timer between jumps.
    public void PlayerMovement()
    {
        if (playerIsAlive == true)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Space) && hasJumped == false)
            {
                playerPosition.Y -= 125;
                hasJumped = true;

                if (hasJumped == true)
                {
                    System.Timers.Timer runonce = new System.Timers.Timer(3000);
                    runonce.Start();
                    runonce.Elapsed += OnTimedEvent;
                    runonce.AutoReset = true;
                    runonce.Enabled = true;
                }

            }

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {

                playerPosition.X += 10;
            }
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {

                playerPosition.X -= 10;
            }
        }
    }
    //After realizing camera function would be less needed for our project
    //i decided on focusing on implimenting a restart fuction
    //Ben was here
    public void Restart ()
    {
        if (playerIsAlive == false) 
        {
            Console.WriteLine("Press R to Restart");
            Console.ReadLine("R");
            if (Raylib.IsKeyDown(KeyboardKey.R))
            {

            }
        }
    }

    // Tried to add camera function here, but didnt give myself enough to work with. wasnt famililar with Git at that point. - Ben
    public void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        hasJumped = false;

    }

}
