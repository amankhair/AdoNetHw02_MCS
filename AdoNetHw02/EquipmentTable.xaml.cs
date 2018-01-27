using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AdoNetHw02
{
    /// <summary>
    /// Interaction logic for EquipmentTable.xaml
    /// </summary>
    public partial class EquipmentTable : Page
    {
        string _connectionString = @"Data Source=AMANKELDI-PC;Initial Catalog=MCS;Integrated Security=True";

        List<newEquipment> list = new List<newEquipment>();

        public EquipmentTable()
        {
            InitializeComponent();


            string sqlExpression = "SELECT intEquipmentID, intGarageRoom, intManufacturerID, intModelID, strManufYear, strSerialNo FROM newEquipment";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        newEquipment eq = new newEquipment();

                        eq.intEquipmentID = (int)reader["intEquipmentID"];
                        eq.intGarageRoom = reader["intGarageRoom"].ToString();
                        eq.intManufacturerID = (int)reader["intManufacturerID"];
                        eq.intModelID = (int)reader["intModelID"];
                        eq.strManufYear = reader["strManufYear"].ToString();
                        eq.strSerialNo = reader["strSerialNo"].ToString();

                        list.Add(eq);
                        EquipmentList.ItemsSource = list;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string update = "UPDATE newEquipment SET intGarageRoom=\'" + GarageRoomBox.Text + "\', intManufacturerID=" +
                            int.Parse(ManIdBox.Text)
                            + ", intModelID=" + int.Parse(ModelIdBox.Text) + ", strManufYear=" + ManufYearBox.Text +
                            ", strSerialNo=\'" + SerialNoBox.Text
                            + "\', WHERE intEquipmentID=" + int.Parse(EqIdBox.Text);

            if (FormGrid.DataContext != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(update, connection);

                        MessageBox.Show("Данные успешно обновлены");
                        TextBoxClear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Oops!");
            }

        }

        private void TextBoxClear()
        {
            GarageRoomBox.Clear();
            ManufYearBox.Clear();
            ManIdBox.Clear();
            ModelIdBox.Clear();
            SerialNoBox.Clear();
            EqIdBox.Clear();
        }
    }

    public class newEquipment
    {
        public int intEquipmentID { get; set; }
        public string intGarageRoom { get; set; }
        public int intManufacturerID { get; set; }
        public int intModelID { get; set; }
        public string strManufYear { get; set; }
        public string strSerialNo { get; set; }
    }
}
