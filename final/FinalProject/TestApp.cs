public class TestApp
{
    public int InputInt(int min, int max, string message)
    {
        Console.Write(message);
        int userInt;
        do
        {
            try
            {
                userInt = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please type a number.");
                userInt = max + 1;
            }
        } while (userInt > max || userInt < min);
        return userInt;
    }
}