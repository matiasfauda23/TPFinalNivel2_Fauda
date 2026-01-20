using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //Sobreescribo el metodo ToString para que me muestre la descripcion de la marca en el ComboBox
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
