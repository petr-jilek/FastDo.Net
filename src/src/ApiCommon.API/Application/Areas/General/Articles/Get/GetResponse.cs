﻿namespace ApiCommon.API.Application.Areas.General.Articles.Get
{
    public class GetResponse
    {
        public List<GetArticlesItemResponse>? Items { get; set; }
        public int TotalCount { get; set; }
    }
}
