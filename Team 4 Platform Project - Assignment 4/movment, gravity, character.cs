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
    public Texture2D DbunnyTexture;



    public MoveGrav()
    {
        playerPositions = new List<Vector2>();

        Texture2D DbunnyTexture = Raylib.LoadTexture("/../../../resources/visuals/DustBunny_Sheet.png");
}

    public void CharacterController()
    {
        Raylib.DrawTexture(DbunnyTexture, 0,0, Color.RayWhite);
        GravitySim();
        PlayerMovement();
        PlayerPositionTracking();

    }

    public void PlayerPositionTracking()
    {
        playerPositions.Add(new Vector2(playerPosition.X, playerPosition.Y));
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

    public void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        hasJumped = false;

    }

}
