using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewMAUIApp.Library.ViewModels
{
    public class LifecyclePageViewModel
    {
        private ICommand _PushedPageCommand;
        public ICommand PushedPageCommand
        {
            get
            {
                return _PushedPageCommand ?? (_PushedPageCommand = new Command(async () => await PushPage()));
            }
        }

        private async Task PushPage()
        {
            await Shell.Current.GoToAsync("PushedPage");
        }
    }
}
