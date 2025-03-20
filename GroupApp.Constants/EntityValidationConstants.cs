using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Group
        {
            public const int descriptionMaxLenght = 100;
            public const int TitleMaxLength = 100;
            
        }

        public static class GroupMember
        {
            public const int nickNameMaxLength = 50;

        }

        public static class TextChannel
        {
            public const int NameMaxLength = 20;
            public const int DescriptionMaxLength = 50; 
        }
        
        

    }

    
}
