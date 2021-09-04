using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
   public  class GPS_DATA
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "GPS_DATAGetAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        context.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableGps = new DataTable();
                        da.Fill(tableGps);
                        if (tableGps.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableGps.Rows)
                            {
                                ML.GPS_DATA gps = new ML.GPS_DATA();

                                gps.Id = int.Parse(row[0].ToString());
                                gps.DateSystem = row[1].ToString();
                                gps.DateEvent = row[2].ToString();
                                gps.Latitude = float.Parse(row[3].ToString());
                                gps.Longitude = float.Parse(row[4].ToString());
                                gps.Battery = int.Parse(row[5].ToString());
                                gps.Source = int.Parse(row[6].ToString());
                                gps.Type = int.Parse(row[7].ToString());

                                result.Objects.Add(gps);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No hay registros";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result Add(ML.GPS_DATA gps)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "GPS_DATAAdd ";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("DateSystem", SqlDbType.DateTime);
                        collection[0].Value = gps.DateSystem;

                        collection[1] = new SqlParameter("DateEvent", SqlDbType.DateTime);
                        collection[1].Value = gps.DateEvent;

                        collection[2] = new SqlParameter("Latitude", SqlDbType.Float);
                        collection[2].Value = gps.Latitude;

                        collection[3] = new SqlParameter("Longitude", SqlDbType.Float);
                        collection[3].Value = gps.Longitude;

                        collection[4] = new SqlParameter("Battery", SqlDbType.Int);
                        collection[4].Value = gps.Battery;

                        collection[5] = new SqlParameter("Source", SqlDbType.Int);
                        collection[5].Value = gps.Source;

                        collection[6] = new SqlParameter("Type", SqlDbType.Int);
                        collection[6].Value = gps.Type;





                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la insercción del Gps";
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result Update(ML.GPS_DATA gps)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "GPS_DATAUpdate";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = Query;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("Id", SqlDbType.Int);
                        collection[0].Value = gps.Id;

                        collection[1] = new SqlParameter("DateSystem", SqlDbType.DateTime);
                        collection[1].Value = gps.DateSystem;

                        collection[2] = new SqlParameter("DateEvent", SqlDbType.DateTime);
                        collection[2].Value = gps.DateEvent;

                        collection[3] = new SqlParameter("Latitude", SqlDbType.Float);
                        collection[3].Value = gps.Latitude;

                        collection[4] = new SqlParameter("Longitude", SqlDbType.Float);
                        collection[4].Value = gps.Longitude;

                        collection[5] = new SqlParameter("Battery", SqlDbType.Int);
                        collection[5].Value = gps.Battery;

                        collection[6] = new SqlParameter("Source", SqlDbType.Int);
                        collection[6].Value = gps.Source;

                        collection[7] = new SqlParameter("Type", SqlDbType.Int);
                        collection[7].Value = gps.Type;


                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la modificacion del GPS";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        public static ML.Result Delete(ML.GPS_DATA gps)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        string Query = "GPS_DATADelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("Id", SqlDbType.Int);
                        collection[0].Value = gps.Id;



                        cmd.Parameters.AddRange(collection);

                        context.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al realizar la Eliminar el GPS";
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }
}
