﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class AuthSuccessResponse
    {
        public string Token{ get; set; }
        public string RefreshToken { get; set; }
    }
}
