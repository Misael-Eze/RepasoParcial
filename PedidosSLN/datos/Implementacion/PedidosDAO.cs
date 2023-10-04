using PedidosSLN.datos.DTOs;
using PedidosSLN.datos.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosSLN.datos.Implementacion
{
    internal class PedidosDAO : IPedidosDAO
    {
        public bool BorrarPedido(int nroPedido)
        {
            bool aux = true;
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@codigo", nroPedido));
            if (HelperDB.ObtenerInstancia().EjecutarSQL("SP_REGISTRAR_BAJA", lista) == 0)
            {
                aux = false;
            }
            return aux;
        }

        public bool EntregarPedido(int nroPedido)
        {
            bool aux = true;
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@codigo", nroPedido));
            if (HelperDB.ObtenerInstancia().EjecutarSQL("SP_REGISTRAR_ENTREGA", lista) == 0)
            {
                aux = false;
            }
            return aux;
        }

        public List<ClienteDTO> TraerClientes()
        {
            DataTable tabla;
            List<ClienteDTO> lClientes = new List<ClienteDTO>();
            tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_CLIENTES", null);
            foreach (DataRow fila in tabla.Rows)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Id = int.Parse(fila["id_cliente"].ToString());
                cliente.NombreCompleto = (fila["nombre"].ToString() + "," + fila["apellido"].ToString());
                lClientes.Add(cliente);
            }
            return lClientes;
        }

        public List<PedidoDTO> TraerPedidos(List<Parametro> lParametro)
        {
            DataTable tabla;
            List<PedidoDTO> lPedido = new List<PedidoDTO>();
            tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PEDIDOS", null);
            
            foreach (DataRow fila in tabla.Rows)
            {
                PedidoDTO pedido = new PedidoDTO();
                pedido.Codigo = int.Parse(fila["codigo"].ToString());
                pedido.FechaEntrega = DateTime.Parse(fila["fec_entrega"].ToString());
                pedido.Cliente = fila["cliente"].ToString();
                lPedido.Add(pedido);
            }
            return lPedido;
        }
    }
}
