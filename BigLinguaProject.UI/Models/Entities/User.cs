﻿using System;

namespace BigLinguaProject.UI.Models.Entities {
    public class User {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String PasswordHash { get; set; }
    }
}