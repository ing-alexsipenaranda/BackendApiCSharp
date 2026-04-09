using ApiBackendCsharp.Services;
using MyApp.Namespace;

namespace ApiBackendCsharp;

public class PeopleService : IPeopleService
{
    public bool Validate(People people)
    {
        if (string.IsNullOrEmpty(people.Name))
        {
            return false;
        }
        return true;
    }
}