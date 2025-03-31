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

            public List<MessageDto> Messages { get; set; } = new();


            public class MessageDto
            {
                public string Content { get; set; } = string.Empty;

                public string TextChannelId { get; set; } = string.Empty;

                public string UserId { get; set; } = string.Empty;

                public DateTime TimeStamp { get; set; }
            }
        }

        public class MemberDto
        {
            public string UserId { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
        }
    }
}