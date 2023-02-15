using System.Collections.Generic;

namespace MVUx.Models;

public record Person(string FirstName, string LastName)
{
    public ICollection<Phone> Phones { get; } = new HashSet<Phone>();
}

public record Phone(string Number);
