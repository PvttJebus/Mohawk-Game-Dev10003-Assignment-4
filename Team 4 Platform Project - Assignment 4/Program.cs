using Raylib_cs;
using System.Numerics;

namespace Team_4_Platform_Project___Assignment_4
{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Game Title";


        static MoveGrav moveGrav = new MoveGrav();
        static Roomba roomba = new Roomba();

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(1680, 1050, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.RayWhite);

                // Your game code here. This is a function YOU define.
                Update();

                // Stop drawing to the canvas, begin displaying the frame
                 Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            moveGrav = new MoveGrav();
            roomba = new Roomba();
            // Your one-time setup code here
        }

        static void Update()
        {
            moveGrav.CharacterController();
            roomba.RoombaManager(moveGrav);
            TestBlocks();
            
            // Your game code run each frame here
        }


        static void TestBlocks()
        {
            
            Raylib.DrawRectangle(0,450,350,50,Color.Black);
            

            Vector2 rectanglePosition = new Vector2(0,450);
            Vector2 rectangleSize = new Vector2(350,50);

            float leftEdge = rectanglePosition.X;
            float rightEdge = rectanglePosition.X + rectangleSize.X;
            float topEdge = rectanglePosition.Y-20;
            float bottomEdge = rectanglePosition.Y-20 + rectangleSize.Y;

            bool isWithinX = moveGrav.playerPosition.X > leftEdge && moveGrav.playerPosition.X < rightEdge;
            bool isWithinY = moveGrav.playerPosition.Y > topEdge && moveGrav.playerPosition.Y < bottomEdge;
            bool isWithinRectangle = isWithinX && isWithinY;
            bool isBelowBlock = moveGrav.playerPosition.Y + 25 >= 450;
            bool isTravelingDown = moveGrav.playerVelocity.Y > 0;

            if (isWithinRectangle)
            {
                
                if (isBelowBlock && isTravelingDown)
                {
                    moveGrav.playerPosition.Y = 450 -20;
                    moveGrav.playerVelocity = Vector2.Zero;
                }
            }
        }
    }
}