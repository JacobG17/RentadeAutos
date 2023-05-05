using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentade
{
    public class datosGaleria
    {
        private String sCliente;
        private String sCarro;
        private DateTime dtFechaInicio;
        private DateTime dtFechaFinal;
        private Int32 iDias;
        private Int32 iTotalPagado;

        public String Cliente
        {
            get { return sCliente; }
            set { this.sCliente = value; }
        }

        public String Carro
        {
            get { return sCarro; }
            set { this.sCarro = value; }
        }

        public DateTime FechaInicio
        {
            get { return dtFechaInicio; }
            set { this.dtFechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return dtFechaFinal; }
            set { this.dtFechaFinal = value; }
        }

        public Int32 Dias
        {
            get { return iDias; }
            set { this.iDias = value; }
        }

        public Int32 TotalPagado
        {
            get { return iTotalPagado; }
            set { this.iTotalPagado = value; }
        }

        public datosGaleria(String cliente, String carro, DateTime fechainicio, DateTime fechafinal, Int32 dias, Int32 totalpagado)
        {
            this.Cliente = cliente;
            this.Carro = carro;
            this.FechaInicio = fechainicio;
            this.FechaFin = fechafinal;
            this.Dias = dias;
            this.TotalPagado = totalpagado;
        }
    }
}
