namespace Eshop.webAPI.DTO
{
    public class CreateReviewDTO
    {
        public int Stars { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    
    //todo-maintability tu plati že duplikacia je lepšie ako dedičnosť, tieto modely majú rovnaké fieldy ale služia komplet inym use cases
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }


}
