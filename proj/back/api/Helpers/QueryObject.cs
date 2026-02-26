using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.Helpers
{
    public class QueryObjectFacility
    {
        public string? Name { get; set; } = null;
        public string? Type { get; set; } = null;
        public string? ColumnType { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }

    public class QueryObjectEmployee
    {
        public string? Surname { get; set; } = null;
        public string? Position { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }

}