namespace api.Helpers
{
    public class QueryObjectForUser
    {
        public string? Role { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
    }
}
