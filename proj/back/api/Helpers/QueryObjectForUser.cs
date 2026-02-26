using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Helpers
{
    public class QueryObjectForUser
    {
        public string? Role { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
    }
}
