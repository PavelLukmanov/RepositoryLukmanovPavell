using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Newtonsoft;
using System.IO;
using Newtonsoft.Json;

namespace TransportForm
{
    /// <summary>
    /// Представляет информацию о транспорте в форме
    /// </summary>
    public partial class MainForm : Form
    {
        public List<IVehicle> Vehicle;
        public MainForm()
        {
            InitializeComponent();
            Vehicle = new List<IVehicle>();
        }
       /// <summary>
       /// Заполнение таблицы
       /// </summary>
        private void FillingTable()
        {
            TransportGrid.Rows.Clear(); // Очищаем таблицу
            foreach (IVehicle transport in Vehicle) // Заполнение таблицы
            {
                int number = TransportGrid.RowCount;
                TransportGrid.Rows.Add(transport.GetType().ToString().Split('.').Last(), transport.ModelName, transport.DateOfManufacture, transport.Distance);
            }
        }

        /// <summary>
        /// Добавление данных при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransport_Click(object sender, EventArgs e)
        {
            AddTransport form = new AddTransport();
            form.Owner = this;
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var vehicle = form.Vehicle;
                //DataGridViewRow row = new DataGridViewRow();//(DataGridViewRow)TransportGrid.Rows[0].Clone();
                //row.Cells[0].Value = vehicle.GetType().ToString().Split('.').Last();
                //row.Cells[1].Value = vehicle.ModelName;
                //row.Cells[2].Value = vehicle.Distance;
                //row.Cells[3].Value = vehicle.DateOfManufacture;
                //if (vehicle is Car)
                //    row.Cells[0].Value = "Car";
                //if (vehicle is Helicopter)
                //    row.Cells[0].Value = "Helicopter";
                //if (vehicle is Hybrid)
                //    row.Cells[0].Value = "Hybrid";
                //TransportGrid.Rows.Add(row);
                TransportGrid.Rows.Add(vehicle.GetType().ToString().Split('.').Last(), vehicle.ModelName, vehicle.Distance, vehicle.DateOfManufacture);
            }
        }
        
        /// <summary>
        /// Удаление данных при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTransport_Click(object sender, EventArgs e)
        {
            if (TransportGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow row = TransportGrid.SelectedRows[0];
                Vehicle.RemoveAt(row.Index);
                TransportGrid.Rows.RemoveAt(row.Index);
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "myfile files (*.myfile)|*.myfile|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filename = saveFileDialog.FileName;
                    var serializer = new JsonSerializer()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Formatting.Indented
                    };

                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            serializer.Serialize(writer, Vehicle);
                        }
                    }
                }
            }
            catch
            {

            }
      
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "myfile files (*.myfile)|*.myfile|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filename = openFileDialog.FileName;
                    var deserializer = new JsonSerializer()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Formatting.Indented
                    };

                    using (StreamReader sr = new StreamReader(filename))
                    {
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            Vehicle = deserializer.Deserialize<List<IVehicle>>(reader);
                        }
                    }
                }
                FillingTable(); // Заполняем таблицу
            }
            catch
            {

            }
        }
    }
}