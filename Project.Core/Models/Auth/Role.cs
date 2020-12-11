using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Models.Auth
{
    public class Role:IdentityRole<Guid>
    {
    }
}
