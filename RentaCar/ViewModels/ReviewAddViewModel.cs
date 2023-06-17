using Entity;

namespace RentaCar.ViewModels
{
    public class ReviewAddViewModel
    {
        public int CarId { get; set; }
        public string ReviewContent { get; set; }
        public int[] FeelingIds { get; set; }
    }
}
