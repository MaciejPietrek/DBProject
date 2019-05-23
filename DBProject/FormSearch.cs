using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class FormSearch : Form
    {
        public List<Tuple<Label, TextBox>> Fields { get; set; }
        public Button button;

        private int index = 0;

        public FormSearch(List<string> fields)
        {
            InitializeComponent();
            Fields = new List<Tuple<Label, TextBox>>();
            for(int index = 0; index < fields.Count; index++)
            {
                var newLabel = new Label();
                var newTextBox = new TextBox();

                newTextBox.Location = new System.Drawing.Point(-1, 20 + 50 * index);
                newTextBox.Name = "textBox" + index.ToString();
                newTextBox.Size = new System.Drawing.Size(200, 20);
                newTextBox.TabIndex = 0;

                newLabel.AutoSize = true;
                newLabel.Location = new System.Drawing.Point(-1, 0 + 50 * index);
                newLabel.Name = "label" + index.ToString();
                newLabel.Size = new System.Drawing.Size(200, 20);
                newLabel.TabIndex = 0;
                newLabel.Text = fields[index];

                this.Controls.Add(newLabel);
                this.Controls.Add(newTextBox);

                Fields.Add(new Tuple<Label, TextBox>(newLabel, newTextBox));
            }
            button = new Button();
            button.AutoSize = true;
            button.Location = new System.Drawing.Point(-2, fields.Count * 50);
            button.Name = "button";
            button.Size = new System.Drawing.Size(200, 20);
            button.TabIndex = 0;
            button.Text = "Szukaj";
            button.UseVisualStyleBackColor = true;

            this.Controls.Add(button);
        }

        public bool isEmptyAt(int index)
        {
            return Fields[index].Item2.Text == "";
        }

        public bool isNotEmptyAt(int index)
        {
            return Fields[index].Item2.Text != "";
        }

        public int getIntAtBox(int index)
        {
            return int.Parse(Fields[index].Item2.Text);
        }

        public float getFloatAtBox(int index)
        {
            return float.Parse(Fields[index].Item2.Text);
        }

        public string getStringAtBox(int index)
        {
            return Fields[index].Item2.Text;
        }

        public DateTime getDateTimeAtBox(int index)
        {
            return DateTime.Parse(Fields[index].Item2.Text);
        }

        public bool atCursorIsEmpty()
        {
            return Fields[index].Item2.Text == "";
        }

        public bool atCursorIsNotEmpty()
        {
            return Fields[index].Item2.Text != "";
        }

        public int getIntAtCursor()
        {
            return int.Parse(Fields[index].Item2.Text);
        }

        public float getFloatAtCursor()
        {
            return float.Parse(Fields[index].Item2.Text);
        }

        public string getStringAtCursor()
        {
            return Fields[index].Item2.Text;
        }

        public DateTime getDateTimeAtCursor()
        {
            return DateTime.Parse(Fields[index].Item2.Text);
        }

        public void resetCursor()
        {
            index = 0;
        }

        public void advanceCursor()
        {
            index++;
        }
    }
}
