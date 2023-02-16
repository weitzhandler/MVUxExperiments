using System.Collections.Generic;

namespace MVUx.Models;

public record Person(string FirstName, string LastName)
{
    public ICollection<Phone> Phones { get; } = new HashSet<Phone>();

    public override string ToString() => $"{FirstName} {LastName}";
}

public record Phone(string Number)
{
    public override string ToString() => Number;
}
