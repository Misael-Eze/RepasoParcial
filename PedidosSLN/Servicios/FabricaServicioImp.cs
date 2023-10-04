using PedidosSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PedidosSLN.Servicios.Implementacion;

namespace PedidosSLN.Servicios
{
    public class FabricaServicioImp : FabricaServicio
    {
        public override IServicio ObtenerServicio()
        {
            return new Servicio();
        }
    }
}
