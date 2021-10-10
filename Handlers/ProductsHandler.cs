using System.Collections.Generic;
using System.Data.SqlClient;
using Laboratorio8.Models;
using System.Configuration;
using System;
using System.Web;
using System.Data;
using System.IO;


public class ProductsHandler
{
    private SqlConnection connection;
    private string connectionRoute;

    public ProductsHandler() {
        connectionRoute = ConfigurationManager.ConnectionStrings["ProductsConnection"].ToString();
        connection = new SqlConnection(connectionRoute);
    }

    private DataTable CreateTableFromQuery(string query)
    {
        SqlCommand queryCommand = new SqlCommand(query, connection);
        SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
        DataTable queryTable = new DataTable();
        connection.Open();
        tableAdapter.Fill(queryTable);
        connection.Close();
        return queryTable;
    }

    public IEnumerable<Products> GetAll()
    {
        
        List<Products> productsList = new List<Products>();

        string query = "SELECT * FROM Products ";
        DataTable resultingTable = CreateTableFromQuery(query);
        foreach (DataRow column in resultingTable.Rows)
        {
            productsList.Add( new Products { 
                Id=Convert.ToInt32(column["id"]),
                Quantity=Convert.ToInt32(column["quantity"]),
                Name=Convert.ToString(column["name"]),
                Price=Convert.ToInt32(column["price"])
            });
        }
        IEnumerable<Products> productsIEList  = productsList;
        return (productsIEList);
    }
}