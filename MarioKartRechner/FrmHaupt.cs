using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioKartRechner
{
    public partial class FrmHaupt : Form
    {
        public FrmHaupt()
        {
            InitializeComponent();
        }

        private void listBoxSchueler_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGame_1_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_1);
        }

        private void btnGame_2_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_2);

        }

        private void btnGame_3_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_3);
        }

        private void btnGame_4_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_4);
        }

        private void btnGame_5_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_5);
        }

        private void btnGame_6_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_6);
        }

        private void btnGame_7_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_7);
        }

        private void btnGame_8_Click(object sender, EventArgs e)
        {
            addSchuelerToGame(listBoxGame_8);
        }

        private void addSchuelerToGame(ListBox listBox)
        {
            if (listBoxSchueler.SelectedIndices.Count == 0)
                return;
            listBox.Items.Clear();
            foreach (int i in listBoxSchueler.SelectedIndices)
            {
                listBox.Items.Add(listBoxSchueler.Items[i]);

            }

            //lstClientes.Items.Remove(selectedItems[i]);asd
        }
    }
}
