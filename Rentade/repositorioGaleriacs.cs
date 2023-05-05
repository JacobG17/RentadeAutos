using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentade
{
    public class repositorioGaleriacs
    {
        private ObservableCollection<datosGaleria> galeria;
        public ObservableCollection<datosGaleria> OrderInfoCollection
        {
            get { return galeria; }
            set { galeria = value; }
        }

        public repositorioGaleriacs(string consultarcarro, DateTime Inicio, DateTime Fin, Boolean cond)
        {
            galeria = new ObservableCollection<datosGaleria>();
            this.LlenarGaleria(consultarcarro, Inicio, Fin, cond);
        }
        public void LlenarGaleria(string scarro, DateTime dtInicio, DateTime dtFin, Boolean bcond)
        {
            if (bcond)
            {
                pages.Historial his = new pages.Historial();
                opMongo op = new opMongo();

                DataTable dtTabla = new DataTable();
                dtTabla = op.ConsultarRegistroCarro(scarro);


                foreach (DataRow dr in dtTabla.Rows)
                {
                    galeria.Add(new datosGaleria(Convert.ToString(dr[2]), Convert.ToString(dr[6]), Convert.ToDateTime(dr[10]), Convert.ToDateTime(dr[11]), Convert.ToInt32(dr[9]), Convert.ToInt32(dr[12])));
                }
            }
            else
            {
                pages.Historial his = new pages.Historial();
                opMongo op = new opMongo();

                DataTable dtTabla = new DataTable();
                dtTabla = op.ConsultarRegistroFecha(dtInicio, dtFin);

                foreach (DataRow dr in dtTabla.Rows)
                {
                    galeria.Add(new datosGaleria(Convert.ToString(dr[2]), Convert.ToString(dr[6]), Convert.ToDateTime(dr[10]), Convert.ToDateTime(dr[11]), Convert.ToInt32(dr[9]), Convert.ToInt32(dr[12])));
                }
            }
        }
    }
}
