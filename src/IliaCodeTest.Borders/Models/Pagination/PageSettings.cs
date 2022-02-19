namespace IliaCodeTest.Borders.Models.Pagination
{
    public class PageSettings
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        public PageSettings()
        {
            PageNumber = 1;
            PageSize = 10;

        }
    }
}
