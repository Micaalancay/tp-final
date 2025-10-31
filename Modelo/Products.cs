using System.ComponentModel.DataAnnotations;

namespace tp_final.Modelo
{
    public class Products
    {
        public string ProductName { get; set; }

        public int CategoryID { get; set; }
        [Key]
        public int ProductID { get; set; }
    }
}
