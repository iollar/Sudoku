using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Field = new Field(this);
            //Field.Drow();

        }

        private Field Field;
        private DataSudoku DS= new DataSudoku();

        private void btnStart_Click(object sender, EventArgs e)
        {
            DS.Fill(Field.GetCellsValues());
            Field.Update(DS.Data);
            Field.Mode = "edit";
            button1.Enabled = true;
            btnStage1.Enabled = true;
            btnStage2.Enabled = true;
            btnStage3.Enabled = true;
            btnStage4.Enabled = true;
            btnPerebor.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Solution();
        }
        private void Solution()
        {
             DS.Solution();
            Field.Update(DS.Data);
            int[] k = DS.IterationOfSolution;
            if (Field.Done())
                MessageBox.Show
                    ($"Судоку успешно решён!\nметод 1: {k[0]} иттераций\nметод 2: {k[1]} иттераций\nметод 3: { k[2]} иттераций\nметод 4: { k[3]} иттераций");
            else
                MessageBox.Show
                    ($"Судоку не решён :(\nметод 1: {k[0]} иттераций\nметод 2: {k[1]} иттераций\nметод 3: { k[2]} иттераций\nметод 4: { k[3]} иттераций");
        }
        private void btnStage1_Click(object sender, EventArgs e)
        {
            DS.Stage1();
            if (!Field.Update(DS.Data))
                MessageBox.Show("исп. др. метод");
        }
        private void btnStage2_Click(object sender, EventArgs e)
        {
            DS.Stage2();
            if (!Field.Update(DS.Data))
                MessageBox.Show("исп. др. метод");
        }
        private void btnStage3_Click(object sender, EventArgs e)
        {
            DS.Stage3();
            if (!Field.Update(DS.Data))
                MessageBox.Show("исп. др. метод");
        }

        private void btnStage4_Click(object sender, EventArgs e)
        {
            DS.Stage4();
            if (!Field.Update(DS.Data))
                MessageBox.Show("исп. др. метод");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Field.Refresh();
            button1.Enabled = false;
            btnStage1.Enabled = false;
            btnStage2.Enabled = false;
            btnStage3.Enabled = false;
            btnStage4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] d = new string[9]
            {
                "9  3   5 ",
                " 58 49 23",
                "  2 5  4 ",
                "  12 78 5",
                "2 7   9  ",
                "8  91  7 ",
                "5  4 12  ",
                " 2 5 6 9 ",
                "1 97 3 86"
            };
            Field.Mode = "create";
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (d[i][j] == ' ')
                        Field[i, j].TextBox.Text = null;
                    else
                        Field[i, j].TextBox.Text = d[i][j].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] d = new string[9]
            {
                "    5    ",
                " 2 3894  ",
                " 1     68",
                "1   9  8 ",
                "28 67 1 4",
                "  48    5",
                " 3 7218  ",
                "   4     ",
                "8 2   3  "
            };
            Field.Mode = "create";

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                        if (d[i][j] == ' ')
                            Field[i, j].TextBox.Text = null;
                        else
                            Field[i, j].TextBox.Text = d[i][j].ToString();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            string[] d = new string[9]
            {
                "     7 9 ",
                "9 42     ",
                "   1    5",
                "  8   7  ",
                "      653",
                " 27   1  ",
                " 6  5  1 ",
                "7   63   ",
                " 3       "
            };
            /* {
                 "8        ",
                 "  36     ",
                 " 7  9 2  ",
                 " 5   7   ",
                 "    457  ",
                 "   1   3 ",
                 "  1    68",
                 "  85   1 ",
                 " 9    4  "
             };*/
            Field.Mode = "create";
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (d[i][j] == ' ')
                        Field[i, j].TextBox.Text = null;
                    else
                        Field[i, j].TextBox.Text = d[i][j].ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] d = new string[9]
            {
                 "8        ",
                 "  36     ",
                 " 7  9 2  ",
                 " 5   7   ",
                 "    457  ",
                 "   1   3 ",
                 "  1    68",
                 "  85   1 ",
                 " 9    4  "
             };
            Field.Mode = "create";
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (d[i][j] == ' ')
                        Field[i, j].TextBox.Text = null;
                    else
                        Field[i, j].TextBox.Text = d[i][j].ToString();
        }

        int ii=0, jj=0;

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DS.Generate(comboBox1.SelectedItem.ToString());
            Field.Update(DS.SolveData);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPerebor_Click(object sender, EventArgs e)
        {
            {
                DS.Solution();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        DS.OldData[i,j] = DS.Data[i,j];
                DS.Perebor(0,0);
                
                Field.Update(DS.Data);
            }
        }

    }
}
