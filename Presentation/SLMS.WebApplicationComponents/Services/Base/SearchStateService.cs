namespace SLMS.WebApplication.Services
{
    public class SearchStateService
    {
        private string? _searchTerm;
        public string? SearchTerm
        {
            get => _searchTerm;
            set { _searchTerm = value; NotifyStateChanged(); }
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
