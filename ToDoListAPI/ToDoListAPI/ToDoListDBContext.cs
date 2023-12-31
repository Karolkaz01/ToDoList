﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

public partial class ToDoListDBContext : DbContext
{
    public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NoteDto> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NoteDto>(entity =>
        {
            entity.ToTable("Note");

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("Note");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}