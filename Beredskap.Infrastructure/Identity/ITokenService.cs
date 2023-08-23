﻿using Beredskap.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beredskap.Infrastructure.Identity
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync(TokenRequest request);
    }
}
