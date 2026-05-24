using System;
using System.Collections.Generic;
using System.Text;

namespace SLMS.WebApplicationComponents.Services.Base
{
    public class FeedStateService
    {
        public event Func<Task>? OnPostAdded;

        // متدی برای فراخوانی رویداد از هر کامپوننت دیگر
        public async Task NotifyPostAddedAsync()
        {
            if (OnPostAdded != null)
                await OnPostAdded.Invoke();
        }
    }
}
