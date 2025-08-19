using System.Numerics;
using Raylib_cs;

class Program
{
    static List<Ball> balls = [];

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
            Vector2 mousePos = Raylib.GetMousePosition();
            balls.Add(new Ball(mousePos.X, mousePos.Y, 20, Color.White));
        }

        foreach (var ball in balls)
        {
            ball.Draw();
        }
    }
}