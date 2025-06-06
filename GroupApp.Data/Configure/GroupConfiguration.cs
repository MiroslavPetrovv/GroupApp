﻿using GroupApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupApp.Data.Configure
{
    using static GroupApp.Common.EntityValidationConstants.Group;
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //Fluent API
            builder.HasKey(g => g.Id);

            builder.Property(g => g.OwnerId)
                .IsRequired();

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(descriptionMaxLenght);

            builder.HasOne(g => g.Owner)
                .WithMany(o=>o.OwnedGroups)
                .HasForeignKey(g => g.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g=>g.GroupMembers)
                .WithOne(gm => gm.Group)
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g => g.TextChannels)
                .WithOne(cr => cr.Group)
                .HasForeignKey(cr => cr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g=> g.Courses)
                .WithOne(c=>c.Group)
                .HasForeignKey(c=>c.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        
    }
    
    
}
