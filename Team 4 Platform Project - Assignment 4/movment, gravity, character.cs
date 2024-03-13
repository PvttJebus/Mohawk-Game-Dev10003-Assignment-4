using Raylib_cs;
using System.Numerics;
using System.Timers;

internal class MoveGrav
{
    public Vector2 playerPosition = new Vector2(400, Raylib.GetScreenHeight()) / 2;
    public Vector2 playerVelocity;
    public Vector2 gravity = new Vector2(0, 5f);
    public bool hasJumped = false;



    public void CharacterController()
    {
        Raylib.DrawCircleV(playerPosition, 25, Color.Blue);
        GravitySim();
        PlayerMovement();
    }

    public void GravitySim()
    {
        float deltaTime = Raylib.GetFrameTime();
        Vector2 gravityForce = deltaTime * gravity;
        playerVelocity += gravityForce;
        playerPosition += playerVelocity;
    }

    public void PlayerMovement()
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

    public void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        hasJumped = false;
        
    }

}
