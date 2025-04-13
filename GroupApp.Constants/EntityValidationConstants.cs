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
            public const int descriptionMaxLenght = 300;
            public const int DescriptionMinlength = 50;

            

            public const int TitleMaxLength = 100;
            

        }

        public static class GroupMember
        {
            public const int nickNameMaxLength = 50;

        }

        public static class TextChannel
        {
            public const int NameMaxLength = 20;
            public const int DescriptionMaxLength = 100;
        }

        public static class Message
        {
            public const int ContentMaxLength = 250;
        }

        public static class Course
        {
            public const int TitleMaxLength = 75;
            public const int TItleMinLength = 5;

            public const int DescriptionMaxLength = 350;
            public const int DescriptionMinLength = 30;
        }

        public static class Module
        {
            public const int TitleMaxLength = 100;
        }

        public static class Lesson
        {
            public const int TitleMaxLength = 100;
            public const int TitleMinLentgh = 8;

            public const int ContentMaxLength = 300;
            public const int ContentMinLenth = 20;

        }
        
        

    }

    
}
