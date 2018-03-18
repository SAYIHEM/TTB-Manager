namespace TTB_Manager.Forms {
    partial class Statistics {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.groupboxTime = new System.Windows.Forms.GroupBox();
            this.radBtnCustom = new System.Windows.Forms.RadioButton();
            this.radBtnWeek = new System.Windows.Forms.RadioButton();
            this.radBtnMonth = new System.Windows.Forms.RadioButton();
            this.checkListBox_Filter = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupboxTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisY.LabelStyle.Format = "{#} €";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(-1, 136);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Einnahmen";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Legend = "Legend1";
            series2.Name = "Schichten";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(688, 314);
            this.chart.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(17, 71);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(98, 20);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.Value = new System.DateTime(2017, 2, 24, 0, 0, 0, 0);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(130, 71);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(92, 20);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // groupboxTime
            // 
            this.groupboxTime.Controls.Add(this.radBtnCustom);
            this.groupboxTime.Controls.Add(this.radBtnWeek);
            this.groupboxTime.Controls.Add(this.radBtnMonth);
            this.groupboxTime.Controls.Add(this.dtpStartDate);
            this.groupboxTime.Controls.Add(this.dtpEndDate);
            this.groupboxTime.Location = new System.Drawing.Point(12, 12);
            this.groupboxTime.Name = "groupboxTime";
            this.groupboxTime.Size = new System.Drawing.Size(342, 108);
            this.groupboxTime.TabIndex = 3;
            this.groupboxTime.TabStop = false;
            this.groupboxTime.Text = "Zeitraum";
            // 
            // radBtnCustom
            // 
            this.radBtnCustom.AutoSize = true;
            this.radBtnCustom.Location = new System.Drawing.Point(232, 31);
            this.radBtnCustom.Name = "radBtnCustom";
            this.radBtnCustom.Size = new System.Drawing.Size(105, 17);
            this.radBtnCustom.TabIndex = 5;
            this.radBtnCustom.TabStop = true;
            this.radBtnCustom.Text = "Eigener Zeitraum";
            this.radBtnCustom.UseVisualStyleBackColor = true;
            this.radBtnCustom.CheckedChanged += new System.EventHandler(this.radBtnCustom_CheckedChanged);
            // 
            // radBtnWeek
            // 
            this.radBtnWeek.AutoSize = true;
            this.radBtnWeek.Location = new System.Drawing.Point(121, 31);
            this.radBtnWeek.Name = "radBtnWeek";
            this.radBtnWeek.Size = new System.Drawing.Size(92, 17);
            this.radBtnWeek.TabIndex = 4;
            this.radBtnWeek.TabStop = true;
            this.radBtnWeek.Text = "Letzte Woche";
            this.radBtnWeek.UseVisualStyleBackColor = true;
            this.radBtnWeek.CheckedChanged += new System.EventHandler(this.radBtnWeek_CheckedChanged);
            // 
            // radBtnMonth
            // 
            this.radBtnMonth.AutoSize = true;
            this.radBtnMonth.Location = new System.Drawing.Point(17, 31);
            this.radBtnMonth.Name = "radBtnMonth";
            this.radBtnMonth.Size = new System.Drawing.Size(90, 17);
            this.radBtnMonth.TabIndex = 3;
            this.radBtnMonth.TabStop = true;
            this.radBtnMonth.Text = "Letzter Monat";
            this.radBtnMonth.UseVisualStyleBackColor = true;
            this.radBtnMonth.CheckedChanged += new System.EventHandler(this.radBtnMonth_CheckedChanged);
            // 
            // checkListBox_Filter
            // 
            this.checkListBox_Filter.FormattingEnabled = true;
            this.checkListBox_Filter.Items.AddRange(new object[] {
            "Einnahmen",
            "Schichten"});
            this.checkListBox_Filter.Location = new System.Drawing.Point(355, 20);
            this.checkListBox_Filter.Name = "checkListBox_Filter";
            this.checkListBox_Filter.Size = new System.Drawing.Size(313, 94);
            this.checkListBox_Filter.TabIndex = 4;
            this.checkListBox_Filter.SelectedIndexChanged += new System.EventHandler(this.checkListBox_Filter_SelectedIndexChanged);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 452);
            this.Controls.Add(this.checkListBox_Filter);
            this.Controls.Add(this.groupboxTime);
            this.Controls.Add(this.chart);
            this.Name = "Statistics";
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupboxTime.ResumeLayout(false);
            this.groupboxTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.GroupBox groupboxTime;
        private System.Windows.Forms.RadioButton radBtnCustom;
        private System.Windows.Forms.RadioButton radBtnWeek;
        private System.Windows.Forms.RadioButton radBtnMonth;
        private System.Windows.Forms.CheckedListBox checkListBox_Filter;
    }
}