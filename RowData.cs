using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoydCrudAdventures
{
    class RowData
    {
        public int custID { get; set; }
        public int addID { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffex { get; set; }
        public string companyName { get; set; }
        public string salesPerson { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string passhash { get; set; }
        public string passSalt { get; set; }
        public string addType { get; set; }
        public string addLine1 { get; set; }
        public string addLine2 { get; set; }
        public string city { get; set; }
        public string stateProv { get; set; }
        public string country { get; set; }
        public string postalc { get; set; }
        public string modDate { get; set; }

        public RowData(DataGridView selectedData)
        {
            if (selectedData.SelectedRows[0].Cells[0].Value != DBNull.Value)
            {
                custID = (Int32)selectedData.SelectedRows[0].Cells[0].Value;
            }
            if (selectedData.SelectedRows[0].Cells[12].Value != DBNull.Value ) 
            { 
                addID = (Int32)selectedData.SelectedRows[0].Cells[12].Value; 
            }
            
            var currect = selectedData.SelectedRows;
            foreach (DataGridViewRow cell in currect)
            {
                title = cell.Cells[1].Value.ToString();
                firstName = cell.Cells[2].Value.ToString();
                middleName = cell.Cells[3].Value.ToString();
                lastName = cell.Cells[4].Value.ToString();
                suffex = cell.Cells[5].Value.ToString();
                companyName = cell.Cells[6].Value.ToString();
                salesPerson = cell.Cells[7].Value.ToString();
                email = cell.Cells[8].Value.ToString();
                phone = cell.Cells[9].Value.ToString();
                passhash = cell.Cells[10].Value.ToString();
                passSalt = cell.Cells[11].Value.ToString();
                addType = cell.Cells[13].Value.ToString();
                addLine1 = cell.Cells[14].Value.ToString();
                addLine2 = cell.Cells[15].Value.ToString();
                city = cell.Cells[16].Value.ToString();
                stateProv = cell.Cells[17].Value.ToString();
                country = cell.Cells[18].Value.ToString();
                postalc = cell.Cells[19].Value.ToString();
                modDate = cell.Cells[21].Value.ToString();
            }
        }

    }
}
