namespace AutoRia.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public bool Archived { get; set; }

        // -------- navigation property ----------

        public Category Category { get; set; }

    }

    //Relationship: One To Many

    
}
