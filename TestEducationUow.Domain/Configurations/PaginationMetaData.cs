using System;

namespace TestEducationCenterUoW.Domain.Configurations
{
    public class PaginationMetaData
    {
        public PaginationMetaData(int totalCount, PaginationParams @params)
        {
            CurrentPage = @params.PageIndex;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)@params.PageSize);
        }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
