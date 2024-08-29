using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record Address
{
    private Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public string Street { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;

    public static Result<Address, Error> Create(string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street) || street.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Street");
        }

        if (string.IsNullOrWhiteSpace(city) || city.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("City");
        }

        if (string.IsNullOrWhiteSpace(state) || state.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("State");
        }

        if (string.IsNullOrWhiteSpace(zipCode) || zipCode.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("ZipCode");
        }

        return new Address(street, city, state, zipCode);
    }
};