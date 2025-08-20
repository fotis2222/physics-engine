using System.Numerics;
using Raylib_cs;

class Program
{
    static List<Ball> balls = [];
    static Random random = new();

    static int r, g, b;

    static void Main()
    {
        Raylib.InitWindow(800, 600, "physics");
        Raylib.SetTargetFPS(60);

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
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            r = random.Next(30, 256);
            g = random.Next(30, 256);
            b = random.Next(30, 256);
            Vector2 mousePos = Raylib.GetMousePosition();
            balls.Add(new Ball(mousePos.X, mousePos.Y, 20, new Color(r, g, b)));
        }

        foreach (var ball in balls)
        {
            ball.Draw();
        }
    }
}