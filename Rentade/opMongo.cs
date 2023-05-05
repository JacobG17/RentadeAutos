using System;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Rentade
{
	public class opMongo
	{
        public Boolean bAllOk = false;
        public String sLastError = "";
        static MongoClient cliente = new MongoClient("mongodb://192.168.1.85:27017/");

        public Boolean Insertar(Int32 IdRenta, String Nombre, String Apellido, String Telefono, String Direccion, String NombreCarro, String Marca, Int32 Modelo, Int32 PrecioDia, DateTime FechaInicio, DateTime FechaFin, Int32 PrecioTotal)
        {
            bAllOk = false;
            try
            {
                IMongoDatabase db = cliente.GetDatabase("testdb");
                var cars = db.GetCollection<BsonDocument>("cars");

                var doc = new BsonDocument
                {
                    {"IdRenta", IdRenta },
                    {"Nombre", Nombre },
                    {"Apellido", Apellido},
                    {"Telefono", Telefono },
                    {"Direccion", Direccion },
                    {"NombreCarro", NombreCarro },
                    {"Marca", Marca },
                    {"Modelo", Modelo },
                    {"PrecioDia", PrecioDia },
                    {"FechaInicio", FechaInicio },
                    {"FechaFinal", FechaFin },
                    {"PrecioTotal", PrecioTotal }
                };
                cars.InsertOne(doc);
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
                bAllOk = false;
            }
            return bAllOk;
        }

        public Boolean Actualizardatos(Int32 IdRenta, String Nombre, String Apellido, String Telefono, String Direccion, String NombreCarro, String Marca, Int32 Modelo, Int32 PrecioDia, DateTime FechaInicio, DateTime FechaFin, Int32 PrecioTotal)
        {
            bAllOk = false;
            try
            {
                MongoClient client = new MongoClient("mongodb://192.168.1.85:27017/");

                IMongoDatabase db = client.GetDatabase("testdb");
                var cars = db.GetCollection<BsonDocument>("cars");
                var filter = Builders<BsonDocument>.Filter.Eq("IdRenta", IdRenta);
                var update = Builders<BsonDocument>.Update.
                 Set("IdRenta", IdRenta).Set("Nombre", Nombre).Set("Apellido", Apellido).Set("Telefono", Telefono).Set("Direccion", Direccion).Set("NombreCarro", NombreCarro).Set("Marca", Marca).Set("Modelo", Modelo).Set("PrecioDia", PrecioDia).Set("FechaInicio", FechaInicio).Set("FechaFinal", FechaFin).Set("PrecioTotal", PrecioTotal);
                cars.UpdateOne(filter, update);

                bAllOk = true;
            }
            catch (Exception ex)
            {
                bAllOk = false;
                sLastError = ex.ToString();
            }
            return bAllOk;

        }

        public Boolean Delete(String Nombre)
        {
            bAllOk = false;
            try
            {
                IMongoDatabase db = cliente.GetDatabase("testdb");
                var cars = db.GetCollection<BsonDocument>("cars");

                var builder = Builders<BsonDocument>.Filter;
                var filter = Builders<BsonDocument>.Filter.Eq("Nombre", Nombre);
                cars.DeleteMany(filter);
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
                bAllOk = false;
            }
            return bAllOk;
        }
        public DataTable ConsultarRegistroFecha(DateTime fechainicio, DateTime fechafinal)
        {
            DataTable datos = new DataTable();

            IMongoDatabase db = cliente.GetDatabase("testdb");
            var consultar = db.GetCollection<BsonDocument>("cars");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Gte("FechaInicio", fechainicio),
                builder.Lte("FechaFinal", fechafinal));

            var docs = consultar.Find(filter).ToList();

            if (docs.Count > 0)
            {
                foreach (var document in docs)
                {
                    var row = datos.NewRow();

                    foreach (var element in document.Elements)
                    {
                        if (datos.Columns[element.Name] == null)
                        {
                            datos.Columns.Add(element.Name);
                        }

                        row[element.Name] = element.Value;
                    }

                    datos.Rows.Add(row);
                }

                bAllOk = true;
            }
            else
            {
                bAllOk = false;
            }

            return datos;
        }

        public DataTable ConsultarRegistroCarro(string carro)
        {
            DataTable datos = new DataTable();

            IMongoDatabase db = cliente.GetDatabase("testdb");
            var consultar = db.GetCollection<BsonDocument>("cars");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("NombreCarro", carro);

            var docs = consultar.Find(filter).ToList();

            if (docs.Count > 0)
            {
                foreach (var document in docs)
                {
                    var row = datos.NewRow();

                    foreach (var element in document.Elements)
                    {
                        if (datos.Columns[element.Name] == null)
                        {
                            datos.Columns.Add(element.Name);
                        }

                        row[element.Name] = element.Value;
                    }

                    datos.Rows.Add(row);

                }

                bAllOk = true;
            }
            else
            {
                bAllOk = false;
            }

            return datos;
        }

        public DataTable ConsultarRegistroHistorial(string scliente, string carro, DateTime fechainicio, DateTime fechafinal)
        {
            DataTable datos = new DataTable();

            IMongoDatabase db = cliente.GetDatabase("testdb");
            var consultar = db.GetCollection<BsonDocument>("cars");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Eq("Nombre", scliente),
                builder.Eq("NombreCarro", carro),
                builder.Eq("FechaInicio", fechainicio),
                builder.Eq("FechaFinal", fechafinal));

            var docs = consultar.Find(filter).ToList();

            if (docs.Count > 0)
            {
                foreach (var document in docs)
                {
                    var row = datos.NewRow();

                    foreach (var element in document.Elements)
                    {
                        if (datos.Columns[element.Name] == null)
                        {
                            datos.Columns.Add(element.Name);
                        }

                        row[element.Name] = element.Value;
                    }

                    datos.Rows.Add(row);
                }

                bAllOk = true;
            }
            else
            {
                bAllOk = false;
            }

            return datos;
        }
    }
}


