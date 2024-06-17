namespace QuickBuck.Repository.Specifications
{
    public class JobPostParams
    {
        public int? Id { get; set; }
        public int? JobProviderId { get; set; }
        public int PageIndex { get; set; } = 1;
        private int PageSize = 5;
        public int pageSize
        {
            get { return  PageSize; }
            set { PageSize = value > 10 ? 10 : value; }
        }

    }
}
