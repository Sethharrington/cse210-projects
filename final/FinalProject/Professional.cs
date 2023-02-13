public class Professional : Person
{
    private string _profession;
    private List<Patient> _tests;
    public Professional(string firstName, string lastName) : base(firstName, lastName)
    {
        _profession = "Psychologist";
    }
    public Professional(string firstName, string lastName, string profession) : base(firstName, lastName)
    {
        _profession = profession;
    }
}