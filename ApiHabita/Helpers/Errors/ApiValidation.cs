using System;
using ApiHabita.Helpers.Errors;

namespace ApiHabita.Helpers;

public class ApiValidation:ApiResponse
{
    public ApiValidation():base(400)
    {

    }

    public IEnumerable<string> Errors { get; set; }

}
