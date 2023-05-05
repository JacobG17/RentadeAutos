using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace Rentade.pages;

public partial class Historial : ContentPage
{
	public Historial()
	{
		InitializeComponent();
	}
    string nombreCarro = "";
    private void cbAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbAuto.SelectedIndex == 1)
        {
            nombreCarro = "Tesla Model 3";
        }
        else if (cbAuto.SelectedIndex == 2)
        {
            nombreCarro = "Nissan Sentra";
        }
        else if (cbAuto.SelectedIndex == 3)
        {
             nombreCarro = "Nissan Versa";
        }
        else if (cbAuto.SelectedIndex == 4)
        {
             nombreCarro = "Camaro Coupe";
        }
        else if (cbAuto.SelectedIndex == 5)
        {
             nombreCarro = "Ford Mustang";
        }
        else if (cbAuto.SelectedIndex == 6)
        {
            nombreCarro = "Corvette Stingray";
        }
        else
        {
            nombreCarro = null;
        }       
    }
    

    private void ConsultarGananciasCarro_Clicked(object sender, EventArgs e)
    {
        string NombreCarro = nombreCarro;
        repositorioGaleriacs ob = new repositorioGaleriacs(nombreCarro, dtFechaGanancia1.Date, dtFechaGanancia2.Date, true);
        dataGrid.ItemsSource = ob.OrderInfoCollection;

        iGanancias = 0;
        opMongo op = new opMongo();

        DataTable dtTabla = new DataTable();
        dtTabla = op.ConsultarRegistroCarro(nombreCarro);

        foreach (DataRow dr in dtTabla.Rows)
        {
            iGanancias += (Convert.ToInt32(dr[12]));
        }

        tbGanancias.Text = iGanancias.ToString();
    }

    Int32 iGanancias = 0;

    private void ConsultarGananciasFecha_Clicked(object sender, EventArgs e)
    {
        string NombreCarro = nombreCarro;
        repositorioGaleriacs ob = new repositorioGaleriacs(NombreCarro, dtFechaGanancia1.Date, dtFechaGanancia2.Date, false);
        dataGrid.ItemsSource = ob.OrderInfoCollection;

        iGanancias = 0;
        opMongo op = new opMongo();

        DataTable dtTabla = new DataTable();
        dtTabla = op.ConsultarRegistroFecha(dtFechaGanancia1.Date, dtFechaGanancia2.Date);

        foreach (DataRow dr in dtTabla.Rows)
        {
            iGanancias += (Convert.ToInt32(dr[12]));
        }

        tbGanancias.Text = iGanancias.ToString();
    }

    private void dataGrid_CellDoubleTapped(object sender, Syncfusion.Maui.DataGrid.DataGridCellDoubleTappedEventArgs e)
    {
        var selectedRow = e.RowData;

        if (selectedRow != null)
        {
            var columna1 = selectedRow.GetType().GetProperty("Cliente").GetValue(selectedRow, null);
            var columna2 = selectedRow.GetType().GetProperty("Carro").GetValue(selectedRow, null);
            var columna3 = selectedRow.GetType().GetProperty("FechaInicio").GetValue(selectedRow, null);
            var columna4 = selectedRow.GetType().GetProperty("FechaFin").GetValue(selectedRow, null);

            pages.Registro.sCliente = Convert.ToString(columna1);
            pages.Registro.sCarro = Convert.ToString(columna2);
            pages.Registro.dtFechaP = Convert.ToDateTime(columna3);
            pages.Registro.dtFechaF = Convert.ToDateTime(columna4);

            pages.Registro.iCond = 2;

            var pantalla = (TabbedPage)Application.Current.MainPage;
            pantalla.CurrentPage = pantalla.Children[0];
        }
    }
}
