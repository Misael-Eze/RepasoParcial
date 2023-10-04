using PedidosSLN.datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSLN.datos.Interfaz
{
    internal interface IPedidosDAO
    {
        List<PedidoDTO> TraerPedidos(List<Parametro> lParametro);
        List<ClienteDTO> TraerClientes();
        bool EntregarPedido(int nroPedido);
        bool BorrarPedido(int nroPedido);
    }
}
