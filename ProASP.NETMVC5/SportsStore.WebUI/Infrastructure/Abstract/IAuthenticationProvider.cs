﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.WebUI.Infrastructure.Abstract
{
    public interface IAuthenticationProvider
    {
        bool Authenticate(String username, String password);
    }
}
