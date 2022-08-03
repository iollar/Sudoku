using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuPro
{
    class Field
    {
        string mode, edit = "edit", create = "create";
        int _borderWidth;
        int _fildWidth;
        Cell[,] _textBoxes;

        private TableLayoutPanel _tlpCells;
        private int _PrimaryFontSize;
        private int _SecondaryFontSize;
        private Color _UserColor = Color.SteelBlue;
        private Color _PrimaryColor = Color.DimGray;
        private Color _SelectionColor = Color.PaleGoldenrod;
        private Color _SelectionDarkColor = Color.Khaki;
        private Color _CellColor = Color.White;
        private Color _BorderColor = Color.Black;
        private Color _SecondaryColor = Color.DarkGray;
        private Font _PrimaryFont;
        private Font _SecondaryFont;

        public string Mode
        {
            get { return mode; }
            set
            {
                if (value == edit || value == create)
                    mode = value;
                else
                    MessageBox.Show("всё плохо");
            }
        }

        public Field(Form1 form)
        {
            _fildWidth = form.Height*9/10;
            _borderWidth = _fildWidth / 400;
            _textBoxes = new Cell[9, 9];

            _PrimaryFontSize = _fildWidth * 2 / 27;
            _SecondaryFontSize = _PrimaryFontSize / 4;
            _PrimaryFont = new Font("Arial", _PrimaryFontSize);
            _SecondaryFont = new Font("Arial", _SecondaryFontSize);
            Drow();
            form.Controls.Add(_tlpCells);
            _tlpCells.SizeChanged += new EventHandler(Field_SizeChanged); 
        }

        public Cell this[int i, int j]
        {
             get => _textBoxes[i, j];
             set => _textBoxes[i, j] = value;
        }

        public string[,] GetCellsValues()
        {
            string[,] values = new string[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    values[i, j] = _textBoxes[i, j].TextBox.Text;
            return values;
        }
        public void Square()
        { 

        }
        public void Resize()
        {
        }
        public void Drow()
        {
            int n = 0;
            _tlpCells = new TableLayoutPanel()
            {
                Size = new Size(_fildWidth, _fildWidth),
                Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left,
                Location = new Point(10, 10),
                BackColor = _BorderColor,
                Padding = new Padding(_borderWidth)
            };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    _tlpCells.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    _tlpCells.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

                    TableLayoutPanel tlp = new TableLayoutPanel()
                    {
                        Name = $"{i * 3 + j}",
                        Dock = DockStyle.Fill,
                        //BackColor = _SecondaryColor,
                        Margin = new Padding(_borderWidth)
                    };
                    _tlpCells.Controls.Add(tlp, j, i);

                    for (int k = 0; k < 3; k++)
                    {
                        tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    }
                    for (int i1 = 0; i1 < 3; i1++)
                    {
                        for (int j1 = 0; j1 < 3; j1++)
                        {
                            TextBox tb = new TextBox()
                            {
                                Name = $"textBox{i1 + i * 3}{j1 + j * 3}",
                                TextAlign = HorizontalAlignment.Center,
                                Text = $"{n}",
                                Multiline = true,
                                Font = _PrimaryFont,
                                ForeColor = _UserColor,
                                BackColor = _CellColor,
                                Dock = DockStyle.Fill,
                                Margin = new Padding(0)
                            };
                            ((TableLayoutPanel)_tlpCells.Controls[i * 3 + j]).Controls.Add(tb, j1, i1);
                            tb.TextChanged += new EventHandler(TextBox_TextChanged);
                            tb.Click += new EventHandler(TextBox_Click);
                            tb.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                            tb.Enter += new EventHandler(TextBox_Active);
                            tb.Leave += new EventHandler(TextBox_Leave);
                            //form.Controls.Add(tb);
                            _textBoxes[i1 + i * 3, j1 + j * 3] = new Cell(i1 + i * 3, j1 + j * 3, tb);
                            n++;
                        }
                    }
                }

           // int n = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++) ;
                    
        }
        public bool Update(string[,] data)
        {
            bool result = false;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    string newText = ToCellText(data[i, j]);
                    if (newText != _textBoxes[i, j].TextBox.Text)
                    {
                        _textBoxes[i, j].TextBox.Text = newText;
                        result = true;
                    }
                }

            return result;
        }
        private string ToCellText(string value)
        {
            if (value!=null)
            { if (value.Length == 1)
                    return value;

                StringBuilder text = new StringBuilder("1  2  3\r\n4  5  6\r\n7  8  9");
                for (int i = 1; i < 10; i++)
                    if (!value.Contains(i.ToString()))
                        text.Replace(i.ToString(), "  ");
                return text.ToString(); 
            }
            return null;
        }
        public void Refresh()//81 ок
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    _textBoxes[i, j].TextBox.Clear();
            mode = create;
        }
        public bool Done()
        {
            //bool result = false;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (this[i, j].TextBox.Text.Length != 1)
                        return false;
            return true;
        }
        private void Field_SizeChanged(object sender, EventArgs e)
        {
            //_tlpCells.Size.Width = _tlpCells.Size.Height;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (Mode == create)
                if (tb.Text.Length == 1)
                {
                    tb.Font = _PrimaryFont;
                    tb.ForeColor = _UserColor;
                }
                else
                {
                    tb.Font = _SecondaryFont;
                    tb.ForeColor = _SecondaryColor;
                }
            else
                if (tb.Text.Length == 1)
                {
                    tb.Font = _PrimaryFont;
                    tb.ForeColor = _PrimaryColor;
                }
                else
                {
                    tb.Font = _SecondaryFont;
                    tb.ForeColor = _SecondaryColor;
                }
        }
        private void TextBox_Active(object sender, EventArgs e)
        {
            int c = int.Parse(((TextBox)sender).Name.Last().ToString());
            int r = int.Parse(((TextBox)sender).Name[((TextBox)sender).Name.Length-2].ToString());
            string value = ((TextBox)sender).Text;
            for (int i = 0; i < 9; i++)
            {
                _textBoxes[i, c].TextBox.BackColor = _SelectionColor;
                _textBoxes[r, i].TextBox.BackColor = _SelectionColor;
            }
            if (value.Length > 0)
                for (int i = 0; i < 9; i++)
                {

                    for (int j = 0; j < 9; j++)
                    {

                        if (_textBoxes[i, j].TextBox.Text == value)
                            _textBoxes[i, j].TextBox.BackColor = _SelectionDarkColor;
                    }
                }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            int c = int.Parse(((TextBox)sender).Name.Last().ToString());
            int r = int.Parse(((TextBox)sender).Name[((TextBox)sender).Name.Length - 2].ToString());
            string value = ((TextBox)sender).Text;
            for (int i = 0; i < 9; i++)
            {
                _textBoxes[i, c].TextBox.BackColor = _CellColor;
                _textBoxes[r, i].TextBox.BackColor = _CellColor;
            }
            if (value.Length > 0)
                for (int i = 0; i < 9; i++)
                {

                    for (int j = 0; j < 9; j++)
                    {

                        if (_textBoxes[i, j].TextBox.Text == value)
                            _textBoxes[i, j].TextBox.BackColor = _CellColor;

                    }
                }
        }
        private void TextBox_Click(object sender, EventArgs e)
        {

        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && e.KeyChar != '0')
            {
                ((TextBox)sender).Text = e.KeyChar.ToString();
                e.Handled = true;
            }
            else
                e.Handled = true;
        }
    }
}
