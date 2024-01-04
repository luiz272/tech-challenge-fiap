using Domain.Base;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : IAggregateRoot
{
    public string Name { get; private set; }
    public CPF CPF { get; private set; }

    public User(string name, CPF cPF)
    {
        Name = name;
        CPF = cPF;

        ValidateEntity();
    }

    private void ValidateEntity()
    {
        AssertionConcern.AssertArgumentNotEmpty(Name, "The name cant be empty");
    }
}