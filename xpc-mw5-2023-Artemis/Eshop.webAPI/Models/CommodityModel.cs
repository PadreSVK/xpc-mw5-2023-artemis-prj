﻿namespace Eshop.webAPI.Models
{
    public class CommodityModel : ModelBase
    {
        private readonly List<ReviewModel> _reviews = new List<ReviewModel>();

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public float? Weight { get; set; }
        public int StockQuantity { get; set; }
        public float? AverageRating
        {
            get
            {
                int sum = 0;
                foreach (ReviewModel review in _reviews)
                {
                    sum = sum + review.Stars;
                }
                return sum / _reviews.Count();
            }
        }
        public CategoryModel Category { get; }
        public ManufacturerModel Manufacturer { get; set; }
        
        public List<ReviewModel>? Reviews { get { return _reviews; }}

        // todo-other
        public List<ReviewModel>? Reviews =>  _reviews;
        //todo-other (and use only private setter)
        public List<ReviewModel>? Reviews { get;  private set;}

        public CommodityModel()
        {
            // todo-cleancode
            Id= Guid.NewGuid();
        }
        //todo-cleancode
        public void addReview(ReviewModel review)
        {
            _reviews.Add(review);
        }

    }
}
