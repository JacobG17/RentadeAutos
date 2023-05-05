using MongoDB.Driver.Core.Misc;
using Syncfusion.Maui.Calendar;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
namespace Rentade.pages;

public partial class Registro : ContentPage
{

    Boolean bCond = false;
    public static Int32 iNumeroCarro;
    public static Int32 iCond;
    public static String sCliente;
    public static String sCarro;
    public static DateTime dtFechaP;
    public static DateTime dtFechaF;
    public Registro()
    {
        InitializeComponent();

    }

    void LimpiarCampos()
    {
        tbID.Text = "";
        tbNombre.Text = "";
        tbApellido.Text = "";
        tbTelefono.Text = "";
        tbDomicilio.Text = "";
        cbAuto.SelectedIndex = 0;
        tbNombreCarro.Text = "";
        tbMarca.Text = "";
        tbModelo.Text = "";
        tbPrecio.Text = "";
        tbTotal.Text = "";

    }

    private async void registrar_Clicked(Object sender, EventArgs e)
    {
        if (tbID.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el ID del Cliente", "Aceptar");
        }
        else if (tbNombre.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Nombre", "Aceptar");
        }
        else if (tbApellido.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Apellido", "Aceptar");
        }
        else if (tbTelefono.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Telefono", "Aceptar");
        }
        else if (tbDomicilio.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Domicilio", "Aceptar");
        }
        else if (tbNombreCarro.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Nombre del Auto", "Aceptar");
        }
        else if (tbMarca.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese la Marca del Auto", "Aceptar");
        }
        else if (tbModelo.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Modelo del Auto", "Aceptar");
        }
        else if (tbPrecio.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Precio por día", "Aceptar");
        }
        else if (tbTotal.Text == null)
        {
            await DisplayAlert("ERROR", "Ingrese el Total de la Renta", "Aceptar");
        }
        else
        {

            opMongo InsertMongo = new opMongo();

            Int32 IdRenta = Convert.ToInt32(tbID.Text);
            String Nombre = tbNombre.Text;
            String Apellido = tbApellido.Text;
            String Telefono = tbTelefono.Text;
            String Domicilio = tbDomicilio.Text;
            String NombreCarro = tbNombreCarro.Text;
            String Marca = tbMarca.Text;
            Int32 Modelo = Convert.ToInt32(tbModelo.Text);
            Int32 PrecioDia = Convert.ToInt32(tbPrecio.Text);
            Int32 PrecioTotal = Convert.ToInt32(tbTotal.Text);

            if (tbID.Text != null || Nombre != null || Telefono != null || Domicilio != null || NombreCarro != null || Marca != null || tbModelo.Text != null || tbPrecio.Text != null || tbTotal.Text != null)
            {
                if (InsertMongo.Insertar(IdRenta, Nombre, Apellido, Telefono, Domicilio, NombreCarro, Marca, Modelo, PrecioDia, dpFechaInicio.Date, dpFechaFinal.Date, PrecioTotal))
                {
                    await DisplayAlert("LISTO", "Registrado correctamente", "Aceptar");
                    LimpiarCampos();
                }
                else
                {
                    await DisplayAlert("ERROR", InsertMongo.sLastError, "Aceptar");
                }
            }
        }
    }

    private async void eliminar_Clicked(object sender, EventArgs e)
    {
        opMongo DeleteMongo = new opMongo();
        if (tbID.Text != null)
        {
            if (DeleteMongo.Delete(tbNombre.Text))
            {
                await DisplayAlert("LISTO", "Eliminado correctamente", "Aceptar");
                LimpiarCampos();
            }
            else
            {
                await DisplayAlert("ERROR", DeleteMongo.sLastError, "Aceptar");
            }
        }
        else
        {
            await DisplayAlert("ADVERTENCIA", "Ingrese el ID Cliente que desea eliminar", "Aceptar");
        }
    }

    private void cbAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbAuto.SelectedIndex == 1)
        {
            tbNombreCarro.Text = "Tesla Model 3";
            tbMarca.Text = "Tesla";
            tbModelo.Text = "2018";
            tbPrecio.Text = "1000";
        }
        else if (cbAuto.SelectedIndex == 2)
        {
            tbNombreCarro.Text = "Nissan Sentra";
            tbMarca.Text = "Nissan";
            tbModelo.Text = "2023";
            tbPrecio.Text = "350";
        }
        else if (cbAuto.SelectedIndex == 3)
        {
             tbNombreCarro.Text = "Nissan Versa";
             tbMarca.Text = "Nissan";
             tbModelo.Text = "2015";
             tbPrecio.Text = "350";
        }
        else if (cbAuto.SelectedIndex == 4)
        {
             tbNombreCarro.Text = "Camaro Coupe";
             tbMarca.Text = "Chevrolet";
             tbModelo.Text = "2017";
             tbPrecio.Text = "900";
        }
        else if (cbAuto.SelectedIndex == 5)
        {
             tbNombreCarro.Text = "Ford Mustang";
             tbMarca.Text = "Ford";
             tbModelo.Text = "2022";
             tbPrecio.Text = "1,500";
        }
        else if (cbAuto.SelectedIndex == 6)
        {
             tbNombreCarro.Text = "Corvette Stingray";
             tbMarca.Text = "Chevrolet";
             tbModelo.Text = "2015";
             tbPrecio.Text = "800";
        }
        else
        {
              tbNombreCarro.Text = null;
              tbMarca.Text = null;
              tbModelo.Text = null;
               tbPrecio.Text = null;
        }
    }




    private void tbTotal_Focused(object sender, FocusEventArgs e)
    {
        DateTime Inicio = dpFechaInicio.Date;
        DateTime Final = dpFechaFinal.Date;
        TimeSpan resultado = Final - Inicio;
        int dias = resultado.Days;
        int total = dias * Convert.ToInt32(tbPrecio.Text);
        tbTotal.Text = $"{total}";
    }

    private async void tbID_Completed(object sender, EventArgs e)
    {
        MongoClient cliente = new MongoClient("mongodb://192.168.1.85:27017/");
        IMongoDatabase db = cliente.GetDatabase("testdb");
        var cars = db.GetCollection<BsonDocument>("cars");
        int ID = Convert.ToInt32(tbID.Text);
        var filtro = Builders<BsonDocument>.Filter.Eq("IdRenta", ID);
        var resultado = cars.Find(filtro).FirstOrDefault();

        if (resultado != null)
        {
            tbID.Text = resultado["IdRenta"].ToString();
            tbNombre.Text = resultado["Nombre"].ToString();
            tbApellido.Text = resultado["Apellido"].ToString();
            tbTelefono.Text = resultado["Telefono"].ToString();
            tbDomicilio.Text = resultado["Direccion"].ToString();
            tbNombreCarro.Text = resultado["NombreCarro"].ToString();
            tbMarca.Text = resultado["Marca"].ToString();
            tbModelo.Text = resultado["Modelo"].ToString();
            tbPrecio.Text = resultado["PrecioDia"].ToString();
            dpFechaInicio.Date = Convert.ToDateTime(resultado["FechaInicio"]);
            dpFechaFinal.Date = Convert.ToDateTime(resultado["FechaFinal"]);
            tbTotal.Text = resultado["PrecioTotal"].ToString();
        }
        else
        {
            await DisplayAlert("Incorrecto", "Algo salio mal", "Aceptar");
        }
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        if (iCond == 1)
        {
            cbAuto.SelectedIndex = iNumeroCarro;

            iCond = 0;
        }

        if (iCond == 2)
        {
            opMongo op = new opMongo();
            DataTable dataTable = new DataTable();
            dataTable = op.ConsultarRegistroHistorial(sCliente, sCarro, dtFechaP, dtFechaF);

            foreach (DataRow dr in dataTable.Rows)
            {
                tbID.Text = Convert.ToString(dr["IdRenta"]);
                tbNombre.Text = Convert.ToString(dr["Nombre"]);
                tbApellido.Text = Convert.ToString(dr["Apellido"]);
                tbTelefono.Text = Convert.ToString(dr["Telefono"]);
                tbDomicilio.Text = Convert.ToString(dr["Direccion"]);

                if (Convert.ToString(dr["NombreCarro"]) == "Tesla Model 3")
                {
                    cbAuto.SelectedIndex = 1;
                }
                else if (Convert.ToString(dr["NombreCarro"]) == "Nissan Sentra")
                {
                    cbAuto.SelectedIndex = 2;
                }
                else if (Convert.ToString(dr["NombreCarro"]) == "Nissan Versa")
                {
                    cbAuto.SelectedIndex = 3;
                }
                else if (Convert.ToString(dr["NombreCarro"]) == "Camaro Coupe")
                {
                    cbAuto.SelectedIndex = 4;
                }
                else if (Convert.ToString(dr["NombreCarro"]) == "Ford Mustang")
                {
                    cbAuto.SelectedIndex = 5;
                }
                else if (Convert.ToString(dr["NombreCarro"]) == "Corvette Stingray")
                {
                    cbAuto.SelectedIndex = 6;
                }
                else
                {
                    
                }
                dpFechaInicio.Date = Convert.ToDateTime(dr["FechaInicio"]);
                dpFechaFinal.Date = Convert.ToDateTime(dr["FechaFinal"]);
                tbTotal.Text = Convert.ToString(dr["PrecioTotal"]);
            }

            iCond = 0;
        }
        else
        {
            iCond = 0;
        }
    }

    void Cancelar_Clicked(System.Object sender, System.EventArgs e)
    {
        LimpiarCampos();
    }

    private async void actualizar_Clicked(System.Object sender, System.EventArgs e)
    {
        opMongo opMongo = new opMongo();

        Int32 IdRenta = Convert.ToInt32(tbID.Text);
        String Nombre = tbNombre.Text;
        String Apellido = tbApellido.Text;
        String Telefono = tbTelefono.Text;
        String Domicilio = tbDomicilio.Text;
        String NombreCarro = tbNombreCarro.Text;
        String Marca = tbMarca.Text;
        Int32 Modelo = Convert.ToInt32(tbModelo.Text);
        Int32 PrecioDia = Convert.ToInt32(tbPrecio.Text);
        Int32 PrecioTotal = Convert.ToInt32(tbTotal.Text);

        if (tbID.Text != null || Nombre != null || Apellido != null || Telefono != null || Domicilio != null || NombreCarro != null || Marca != null || tbModelo.Text != null || tbPrecio.Text != null || tbTotal.Text != null)
        {
            if (opMongo.Actualizardatos(IdRenta, Nombre, Apellido, Telefono, Domicilio, NombreCarro, Marca, Modelo, PrecioDia, dpFechaInicio.Date, dpFechaFinal.Date, PrecioTotal))
            {
                await DisplayAlert("LISTO", "Actualizacion realizada correctamente", "Aceptar");
                LimpiarCampos();
            }
            else
            {
                await DisplayAlert("ERROR", opMongo.sLastError, "Aceptar");
            }


        }

    }

}



