using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Group
{
    public class GroupDisplayViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Banner { get; set; } = null!;

        public int GroupMemberCount { get; set; }
    }
}
