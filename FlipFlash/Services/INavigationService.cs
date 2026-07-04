using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Services
{
    public interface INavigationService
    {
        Task GoToAsync(string location);
        Task GoToAsync(string location, bool animate);
        Task GoToAsync(string location, Dictionary<string, object> paramters);
        Task GoToAsync(string location, bool animate, Dictionary<string, object> paramters);
    }
}
