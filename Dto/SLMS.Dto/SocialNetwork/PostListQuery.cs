using System;
using System.Collections.Generic;
using System.Text;

namespace SLMS.Dto.SocialNetwork
{
    public class PostListQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool? OnlyMyFollowings { get; set; } = null;
        public string? SearchTerm { get; set; } = null;
    }
}
