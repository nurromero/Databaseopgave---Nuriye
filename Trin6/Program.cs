namespace Trin6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // (Trin 6) Opret et object af DBClient og kald Start metoden
             DBClient dbClient = new DBClient();

            dbClient.Start();
        }
    }
}