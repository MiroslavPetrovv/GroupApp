using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Group
{
    public class GroupViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;

        public List<TextChannelDto> TextChannels { get; set; } = new();
        public List<MemberDto> GroupMembers { get; set; } = new();

        public class TextChannelDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;

            
        }

        public class MemberDto
        {
            public string UserId { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
        }
    }
}