using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record LoginResponseDto(bool IsSuccess,
    string Token,
    string UserType,
    DateTime Expiration,
    string ErrorMessage = "");
