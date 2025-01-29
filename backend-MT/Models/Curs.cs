using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Curs
    {
        [Key]
        public int cursId { get; set; }
        public string denumire { get; set; }
        public string descriere { get; set; }
        public int nrSedinte { get; set; }
        public int pret { get; set; }
    }
}