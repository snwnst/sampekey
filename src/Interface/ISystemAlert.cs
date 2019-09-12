using System;

namespace Sampekey.Interface
{
    public interface ISystemAlert
    {
        Object GetUnauthorizedMenssageFromActiveDirectory();
        Object GetUnauthorizedMenssageFromSampeKey();
        Object GetUnauthorizedMenssage();
        Object GetValidationProblemMenssage();
    }
}

