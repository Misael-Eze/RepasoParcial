using PedidosSLN.datos;
using PedidosSLN.datos.DTOs;
using PedidosSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PedidosSLN;
using PedidosSLN.datos.Interfaz;
using PedidosSLN.datos.Implementacion;

namespace PedidosSLN.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        IPedidosDAO dao;

        public Servicio()
        {
                dao = new PedidosDAO();
        }
        public bool BorrarPedido(int nroPedido)
        {
            return dao.BorrarPedido(nroPedido);
        }

        public bool EntregarPedido(int nroPedido)
        {
            return dao.EntregarPedido(nroPedido);
        }

        public List<ClienteDTO> ObtenerClientes()
        {
           return dao.TraerClientes();
        }

        public List<PedidoDTO> ObtenerPedidos(List<Parametro> lParametros)
        {
            return dao.TraerPedidos(lParametros);
        }
    }
}
