using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Forms;


    public class BaseDeDatos
    {
    private string connection = string.Empty;
    private SqlConnection connect;
    private SqlCommand command;
    private SqlDataAdapter da;
    private DataTable dt;
    private DataSet ds;

    public BaseDeDatos()
    {
        connect = new SqlConnection();
        try
        {
            connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        catch
        {
            connection = ConfigurationManager.AppSettings.Get("connection");
        }
    }
    private SqlConnection connecttodb()
    {
        if (connect.State != ConnectionState.Open)
        {
            try
            {
                connect.ConnectionString = connection;
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        return connect;
    }
    private void closeconnection()
    {
        if (connect.State != ConnectionState.Closed)
            connect.Close();
    }
    public string selectstring(string query)
    {
        string cadena = string.Empty;
        try
        {
            connecttodb();
            command = new SqlCommand(query, connect);
            cadena = command.ExecuteScalar().ToString();
        }
        catch
        {
            cadena = string.Empty;
        }
        finally
        {
            closeconnection();
        }
        return cadena;
    }

    public bool executecommand(string query)
    {
        bool exito;
        try
        {
            connecttodb();
            command = new SqlCommand(query, connect);
            command.ExecuteNonQuery();
            exito = true;
        }
        catch
        {
            exito = false;
        }
        finally
        {
            closeconnection();
        }
        return exito;
    }

    public bool ExecuteStoreProcedure(string namestoreprocedure)
    {
        try
        {
            connecttodb();
            command = new SqlCommand(namestoreprocedure, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            closeconnection();
        }
    }

    public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
    {
        dt = new DataTable();
        try
        {
            connecttodb();
            command = new SqlCommand(namestoreprocedure, connect);//
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            closeconnection();
        }
        return dt;
    }
    public DataTable SelectDataTable(string query)
    {
        dt = new DataTable();
        try
        {
            connecttodb();
            da = new SqlDataAdapter(query, connect);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            connecttodb();
        }
        return dt;
    }

    public DataSet SelectDataSet(string query, string table)
    {
        ds = new DataSet();
        try
        {
            connecttodb();
            da = new SqlDataAdapter(query, connect);
            da.Fill(ds, table);
        }
        catch //(Exception ex)
        {
            // ds = null;
        }
        finally
        {
            closeconnection();
        }
        return ds;
    }

}

