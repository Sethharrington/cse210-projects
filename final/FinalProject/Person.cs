public class Person
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phone;
    private int _age;
    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }
    public Person(string firstName, string lastName, string email, string phone, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _phone = phone;
        _age = age;
    }
}