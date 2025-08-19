using Raylib_cs;

class Ball
{
    public float x, y;
    public int radius;
    public float xVelocity, yVelocity = 0;
    public Color color;

    public Ball(float x, float y, int radius, Color color)
    {
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.color = color;
        this.xVelocity = 0;
        this.yVelocity = 0;
    }

    public void DoPhysicsStuff()
    {
        float g = 980f;
        float dt = Raylib.GetFrameTime();

        // do the physics
        yVelocity += g * dt;
        y += yVelocity * dt;

        if (y + radius > Raylib.GetScreenHeight())
        {
            y = Raylib.GetScreenHeight() - radius;
            yVelocity *= -0.7f;
        }
    }

    public void Draw()
    {
        DoPhysicsStuff();
        Raylib.DrawCircle((int)Math.Floor(x), (int)Math.Floor(y), radius, color);
    }
}