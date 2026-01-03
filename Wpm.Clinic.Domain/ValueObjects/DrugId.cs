namespace Wpm.Clinic.Domain.ValueObjects;

public record DrugId
{
    public Guid Value { get; init; }

    public DrugId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("value", "The identifier is not valid");
        }

        Value = value;
    }

    public static implicit operator DrugId(Guid value)
    {
        return new DrugId(value);
    }
}
