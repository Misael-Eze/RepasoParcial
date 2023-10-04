using PedidosSLN.datos;
using PedidosSLN.datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSLN.Servicios.Interfaz
{
    public interface IServicio
    {
        List<PedidoDTO> ObtenerPedidos(List<Parametro> lParametros);

        List<ClienteDTO> ObtenerClientes();
        bool EntregarPedido(int nroPedido);
        bool BorrarPedido(int nroPedido);
    }
}
