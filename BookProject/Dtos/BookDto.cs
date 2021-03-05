﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public DateTime? DatePublished { get; set; }
        public string Description{get;set;}
        public string ImageUrl{get;set; }

    }
}
