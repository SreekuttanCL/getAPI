﻿using System;
namespace getAPI.Models
{
    public class Posts
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public Posts()
        {
        }
    }
}
