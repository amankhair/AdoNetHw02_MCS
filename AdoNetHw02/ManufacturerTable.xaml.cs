using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AdoNetHw02
{
    /// <summary>
    /// Interaction logic for ManufacturerTable.xaml
    /// </summary>
    public partial class ManufacturerTable : Page
    {
        string _connectionString = @"Data Source=AMANKELDI-PC;Initial Catalog=MCS;Integrated Security=True";
        private List<TablesManufacturer> list = new List<TablesManufacturer>();

        public ManufacturerTable()
        {
            InitializeComponent();

            string sqlExpression =
                "SELECT intManufacturerID, strManufacturerChecklistId, strName FROM TablesManufacturer";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TablesManufacturer tb = new TablesManufacturer();
                        tb.intManufacturerID = (int)reader["intManufacturerID"];
                        tb.strManufacturerChecklistId = reader["strManufacturerChecklistId"].ToString();
                        tb.strName = reader["strName"].ToString();

                        list.Add(tb);
                        ManufacturerList.ItemsSource = list;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void EditDataBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "EditData";

            if (EditManChListIdBox.Text == "" || EditNameBox.Text == "")
            {
                MessageBox.Show("Чтобы изменить данные выберите из списка");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter strManufacturerChecklistIdParam = new SqlParameter
                        {
                            ParameterName = "@strManufacturerChecklistId",
                            Value = EditManChListIdBox.Text
                        };
                        command.Parameters.Add(strManufacturerChecklistIdParam);

                        SqlParameter strNameParam = new SqlParameter
                        {
                            ParameterName = "@strName",
                            Value = EditNameBox.Text
                        };
                        command.Parameters.Add(strNameParam);

                        MessageBox.Show("Данные успешно обновлены");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddNewDataBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "AddNewData";


            if (AddManChListIdBox.Text == "" || AddNameBox.Text == "")
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter strManufacturerChecklistIdParam = new SqlParameter
                        {
                            ParameterName = "@strManufacturerChecklistId",
                            Value = AddManChListIdBox.Text
                        };
                        command.Parameters.Add(strManufacturerChecklistIdParam);

                        SqlParameter strNameParam = new SqlParameter
                        {
                            ParameterName = "@strName",
                            Value = AddNameBox.Text
                        };
                        command.Parameters.Add(strNameParam);

                        MessageBox.Show("Данные успешно добавлены");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    class TablesManufacturer
    {
        public int intManufacturerID { get; set; }
        public string strManufacturerChecklistId { get; set; }
        public string strName { get; set; }
    }
}
