namespace WebAPI
{
    public class DealModel
    {
        public Int64 DealId { get; set; }
        public Int64 DateSeq { get; set; }
        public DateTime DealDate { get; set; }
        public string Item { get; set; }
        public object UserId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total => Amount + Tax;
        //public decimal? Total { get; set; }
        public decimal? AmountDaySum { get; set; }
        public decimal? AmountDayPercent { get; set; }
        public decimal? AmountDaySubTotal { get; set; }
        public string? Note { get; set; }
        public string? ServerName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}