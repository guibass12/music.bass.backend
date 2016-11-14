using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class ConteudoAula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Info { get; set; }
        public int AulaId { get; set; }
        public virtual Aula Aula { get; set; }
    }
}
