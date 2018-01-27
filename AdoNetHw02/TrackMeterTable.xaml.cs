using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AdoNetHw02
{
    /// <summary>
    /// Interaction logic for TrackMeterTable.xaml
    /// </summary>
    public partial class TrackMeterTable : Page
    {
        string _connectionString = @"Data Source=AMANKELDI-PC;Initial Catalog=MCS;Integrated Security=True";
        List<TrackMeter> list = new List<TrackMeter>();

        public TrackMeterTable()
        {
            InitializeComponent();
        }

        private void DTrackMeterBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "SELECT intEquipmentID, dMeterDate, intMeterReading, intHoursHoursOperation FROM TrackMeter WHERE dMeterDate BETWEEN \'"
                                   + DateBox1.Text + "\' AND \'" + DateBox2.Text + "\'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TrackMeter tm = new TrackMeter();

                    tm.intEquipmentID = (int)reader["intEquipmentID"];
                    tm.dMeterDate = reader["dMeterDate"].ToString();
                    tm.intMeterReading = reader["intMeterReading"].ToString();
                    tm.intHoursHoursOperation = reader["intHoursHoursOperation"].ToString();

                    list.Add(tm);
                    TrackMeterList.ItemsSource = list;
                }
            }
        }
    }

    class TrackMeter
    {
        public int intEquipmentID { get; set; }
        public string dMeterDate { get; set; }
        public string intMeterReading { get; set; }
        public string intHoursHoursOperation { get; set; }
    }
}
