﻿namespace _2048WindowsFormsApp
{
    partial class ResultsTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsTableForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаРезультатовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезапускToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsGridView = new System.Windows.Forms.DataGridView();
            this.renewResultsButton = new System.Windows.Forms.Button();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winOrLoseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(316, 24);
            this.menuStrip2.TabIndex = 8;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.таблицаРезультатовToolStripMenuItem,
            this.перезапускToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.играToolStripMenuItem.Text = "Игра";
            this.играToolStripMenuItem.Click += new System.EventHandler(this.играToolStripMenuItem_Click);
            // 
            // таблицаРезультатовToolStripMenuItem
            // 
            this.таблицаРезультатовToolStripMenuItem.Name = "таблицаРезультатовToolStripMenuItem";
            this.таблицаРезультатовToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.таблицаРезультатовToolStripMenuItem.Text = "Таблица результатов";
            // 
            // перезапускToolStripMenuItem
            // 
            this.перезапускToolStripMenuItem.Name = "перезапускToolStripMenuItem";
            this.перезапускToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.перезапускToolStripMenuItem.Text = "Перезапуск";
            this.перезапускToolStripMenuItem.Click += new System.EventHandler(this.перезапускToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правилаИгрыToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // правилаИгрыToolStripMenuItem
            // 
            this.правилаИгрыToolStripMenuItem.Name = "правилаИгрыToolStripMenuItem";
            this.правилаИгрыToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.правилаИгрыToolStripMenuItem.Text = "Правила игры";
            this.правилаИгрыToolStripMenuItem.Click += new System.EventHandler(this.правилаИгрыToolStripMenuItem_Click);
            // 
            // resultsGridView
            // 
            this.resultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.resultColumn,
            this.mapSizeColumn,
            this.winOrLoseColumn});
            this.resultsGridView.Location = new System.Drawing.Point(12, 52);
            this.resultsGridView.Name = "resultsGridView";
            this.resultsGridView.Size = new System.Drawing.Size(292, 331);
            this.resultsGridView.TabIndex = 9;
            // 
            // renewResultsButton
            // 
            this.renewResultsButton.Location = new System.Drawing.Point(228, 23);
            this.renewResultsButton.Name = "renewResultsButton";
            this.renewResultsButton.Size = new System.Drawing.Size(75, 23);
            this.renewResultsButton.TabIndex = 10;
            this.renewResultsButton.Text = "Обновить";
            this.renewResultsButton.UseVisualStyleBackColor = true;
            this.renewResultsButton.Click += new System.EventHandler(this.renewResultsButton_Click);
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.Width = 54;
            // 
            // resultColumn
            // 
            this.resultColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.resultColumn.HeaderText = "Карта";
            this.resultColumn.Name = "resultColumn";
            this.resultColumn.Width = 57;
            // 
            // mapSizeColumn
            // 
            this.mapSizeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.mapSizeColumn.HeaderText = "Очки";
            this.mapSizeColumn.Name = "mapSizeColumn";
            this.mapSizeColumn.Width = 57;
            // 
            // winOrLoseColumn
            // 
            this.winOrLoseColumn.HeaderText = "Результат";
            this.winOrLoseColumn.Name = "winOrLoseColumn";
            this.winOrLoseColumn.Width = 80;
            // 
            // ResultsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(316, 395);
            this.Controls.Add(this.renewResultsButton);
            this.Controls.Add(this.resultsGridView);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultsTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаРезультатовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перезапускToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаИгрыToolStripMenuItem;
        private System.Windows.Forms.DataGridView resultsGridView;
        private System.Windows.Forms.Button renewResultsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapSizeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winOrLoseColumn;
    }
}