using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Aula
    {
        public Aula()
        {

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NivelId { get; set; }
        public virtual Nivel Nivel { get; set; }
    }
}
