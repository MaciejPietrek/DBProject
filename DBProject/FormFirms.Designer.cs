﻿namespace DBProject
{
    partial class FormFirms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BottomPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.BottomPanelLeft = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.BottomPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(960, 411);
            this.dataGridView1.TabIndex = 9;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BottomPanel.ColumnCount = 2;
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BottomPanel.Controls.Add(this.BottomPanelRight, 0, 0);
            this.BottomPanel.Controls.Add(this.BottomPanelLeft, 0, 0);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 426);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.RowCount = 1;
            this.BottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomPanel.Size = new System.Drawing.Size(984, 35);
            this.BottomPanel.TabIndex = 10;
            // 
            // BottomPanelRight
            // 
            this.BottomPanelRight.AutoSize = true;
            this.BottomPanelRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BottomPanelRight.BackColor = System.Drawing.SystemColors.Control;
            this.BottomPanelRight.Controls.Add(this.buttonD);
            this.BottomPanelRight.Controls.Add(this.buttonC);
            this.BottomPanelRight.Controls.Add(this.buttonB);
            this.BottomPanelRight.Controls.Add(this.buttonA);
            this.BottomPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BottomPanelRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.BottomPanelRight.Location = new System.Drawing.Point(695, 3);
            this.BottomPanelRight.Name = "BottomPanelRight";
            this.BottomPanelRight.Size = new System.Drawing.Size(286, 29);
            this.BottomPanelRight.TabIndex = 3;
            // 
            // buttonD
            // 
            this.buttonD.AutoSize = true;
            this.buttonD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonD.Location = new System.Drawing.Point(234, 3);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(49, 23);
            this.buttonD.TabIndex = 4;
            this.buttonD.Text = "Szukaj";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonD_Click);
            // 
            // buttonC
            // 
            this.buttonC.AutoSize = true;
            this.buttonC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonC.Location = new System.Drawing.Point(180, 3);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(48, 23);
            this.buttonC.TabIndex = 0;
            this.buttonC.Text = "Zapisz";
            this.buttonC.UseVisualStyleBackColor = true;
            // 
            // buttonB
            // 
            this.buttonB.AutoSize = true;
            this.buttonB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonB.Location = new System.Drawing.Point(94, 3);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(80, 23);
            this.buttonB.TabIndex = 1;
            this.buttonB.Text = "Cofnij i Wyjdź";
            this.buttonB.UseVisualStyleBackColor = true;
            // 
            // buttonA
            // 
            this.buttonA.AutoSize = true;
            this.buttonA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonA.Location = new System.Drawing.Point(3, 3);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(85, 23);
            this.buttonA.TabIndex = 2;
            this.buttonA.Text = "Zapisz i Wyjdź";
            this.buttonA.UseVisualStyleBackColor = true;
            // 
            // BottomPanelLeft
            // 
            this.BottomPanelLeft.AutoSize = true;
            this.BottomPanelLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BottomPanelLeft.BackColor = System.Drawing.SystemColors.Control;
            this.BottomPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.BottomPanelLeft.Name = "BottomPanelLeft";
            this.BottomPanelLeft.Size = new System.Drawing.Size(1, 29);
            this.BottomPanelLeft.TabIndex = 1;
            // 
            // FormFirms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BottomPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FormFirms";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommunitySystem-Firmy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.BottomPanelRight.ResumeLayout(false);
            this.BottomPanelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel BottomPanel;
        private System.Windows.Forms.FlowLayoutPanel BottomPanelLeft;
        private System.Windows.Forms.FlowLayoutPanel BottomPanelRight;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonD;
    }
}

