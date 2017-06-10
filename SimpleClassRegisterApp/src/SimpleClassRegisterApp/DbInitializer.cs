﻿using SimpleClassRegisterApp.Models;
using SimpleClassRegisterApp.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp
{
    public static class DbInitializer
    {
        public static void Initialize(ClassRegisterDataContext context)
        {
            if (context.Classes.Any())
            {
                return;
            }

            var classes = new Class[]
            {
                new Class{Identification="1 A"},
                new Class{Identification="1 B"},
                new Class{Identification="2 A"},
                new Class{Identification="2 B"},
                new Class{Identification="3 A"},
                new Class{Identification="3 B"}
            };

            foreach (Class element in classes)
            {
                context.Classes.Add(element);
            }
            context.SaveChanges();

            var subjects = new Subject[]
            {
                new Subject{Name="Math"},
                new Subject{Name="English"},
                new Subject{Name="Polish"},
                new Subject{Name="Chemistry"},
                new Subject{Name="Biology"},
                new Subject{Name="Geography"},
                new Subject{Name="Physics" }
            };

            foreach (Subject element in subjects)
            {
                context.Subjects.Add(element);
            }
            context.SaveChanges();
        }
    }
}