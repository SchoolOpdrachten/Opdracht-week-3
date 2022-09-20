using System;

namespace Program;

public static class Logger
{
    public static async void Write(string text)
    {
        StreamWriter writer = new StreamWriter("log.txt", true);
        writer.WriteLine(text);
    }
    public static void Open()
    {

    }
}