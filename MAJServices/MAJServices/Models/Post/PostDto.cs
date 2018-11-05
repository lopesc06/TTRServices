﻿using System;
using System.Collections.Generic;

namespace MAJServices.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public ICollection<FilePathDto> FilePaths { get; set; } = new List<FilePathDto>();
        public UserWithoutPostsDto Publisher { get; set; }
    }
}