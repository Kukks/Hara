using System;
namespace Hara.UI.Services
{
    public class UIStateService
    {
        private string _pageTitle;

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;   
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}