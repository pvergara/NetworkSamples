namespace NetworkingExercise4Server;

public class MainServer
{
    private static void Main()
    {
        var shiftServer = new ShiftServer();
        shiftServer.Init();
    }
}