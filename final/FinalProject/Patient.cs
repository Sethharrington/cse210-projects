public class Patient : Person
{
    private List<Test> _tests;
    public Patient(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}