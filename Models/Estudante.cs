using System.Collections.Generic;
using vylexAPI.Models;

namespace vylexAPI.Models
{
    public class Estudante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public ICollection<Avaliacao>? Avaliacoes { get; set; }
    }
}
