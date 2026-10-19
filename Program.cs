using System;
using System.Numerics;
using Raylib_cs;

internal static class Program
{
    private static float EcuacionDeLaRecta(float x, float m, float b)
    {
        return m * x + b;
    }

    private static void DdaSimetrico(
        int x0, int y0, int x1, int y1, Color color)
    {
        int dx = x1 - x0;
        int dy = y1 - y0;

        int pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));

        if (pasos == 0)
        {
            Raylib.DrawPixel(x0, y0, color);
            return;
        }

        float incrementoX = (float)dx / pasos;
        float incrementoY = (float)dy / pasos;

        float x = x0;
        float y = y0;

        for (int i = 0; i <= pasos; i++)
        {
            Raylib.DrawPixel(
                (int)MathF.Round(x),
                (int)MathF.Round(y),
                color
            );

            x += incrementoX;
            y += incrementoY;
        }
    }

    public static void Main()
    {
        // Ejemplo de la ecuación de la recta
        float x = 5;
        float m = 2;
        float b = 1;

        float y = EcuacionDeLaRecta(x, m, b);
        Console.WriteLine(y); // Muestra 11

        Raylib.InitWindow(800, 600, "Algoritmo DDA Simetrico");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Línea desde (5, 7) hasta (10, 15)
            DdaSimetrico(5, 7, 10, 15, Color.Black);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}