using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

class Program
{
    static List<Ball> balls = [];
    static Random random = new();

    static int r, g, b;
    static Sound vineBoom = Raylib.LoadSound("assets/sounds/VINE BOOM.wav");
    static bool gravity = true;

    static void Main()
    {
        Raylib.InitWindow(800, 600, "physics");
        Raylib.SetTargetFPS(60);
        Raylib.InitAudioDevice();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void Draw()
    {        
        Raylib.ClearBackground(Color.Black);
        if (Raylib.IsMouseButtonPressed(MouseButton.Left) || (Raylib.IsMouseButtonDown(MouseButton.Left) && Raylib.IsKeyDown(KeyboardKey.LeftShift)))
        {
            r = random.Next(30, 256);
            g = random.Next(30, 256);
            b = random.Next(30, 256);
            Vector2 mousePos = Raylib.GetMousePosition();
            balls.Add(new Ball(mousePos.X, mousePos.Y, 20, new Color(r, g, b), -200, (float)(random.NextDouble() * 10 - 5), gravity));
            if (balls.Count > 200)
            {
                balls.RemoveAt(0);
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.E))
        {
            Raylib.PlaySound(vineBoom);
            foreach (var ball in balls)
            {
                ball.xVelocity = random.Next(-10, 10);
                ball.yVelocity = random.Next(-2000, 2000);
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            gravity = !gravity;
            foreach (var ball in balls)
            {
                ball.gBool = gravity;
            }
        }

        foreach (var ball in balls)
        {
            ball.Draw();
        }
    }
}