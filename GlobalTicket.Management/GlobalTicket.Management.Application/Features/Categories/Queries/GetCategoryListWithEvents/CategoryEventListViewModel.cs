﻿namespace GlobalTicket.Management.Application.Features.Categories.Queries
{
    using System;
    using System.Collections.Generic;
    public class CategoryEventListViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
