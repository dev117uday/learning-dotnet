using IProgram2;
public class Program7
{
    public static void EntryPoint()
    {
        IProgram2.Television television = new IProgram2.Television();
        IElectronicDevice TV = TVRemote.GetDevice();
        PowerButton pb = new PowerButton(TV);
        pb.Execute();
        pb.Undo();
    }
}

