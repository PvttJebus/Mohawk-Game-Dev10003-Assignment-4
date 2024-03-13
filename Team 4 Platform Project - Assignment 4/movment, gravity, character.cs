using Raylib_cs;
using System.Numerics;

internal class MoveGrav
{
    public Vector2 playerPosition = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) / 2;
    public Vector2 playerVelocity { get; set; }
    public Vector2 gravity = new Vector2(0, 5f);



    public void CharacterController()
    {
        Raylib.DrawCircleV(playerPosition, 25, Color.Blue);
        //GravitySim();
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

    }


}
