namespace CurrencySaver
{
    partial class Window
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
            this._inputField = new System.Windows.Forms.Label();
            this._outputField = new System.Windows.Forms.Label();
            this._input = new System.Windows.Forms.TextBox();
            this._output = new System.Windows.Forms.TextBox();
            this._averageTime = new System.Windows.Forms.Label();
            this._averageTimeResult = new System.Windows.Forms.Label();
            this.runs = new System.Windows.Forms.ListBox();
            this._async = new System.Windows.Forms.RadioButton();
            this._sync = new System.Windows.Forms.RadioButton();
            this._go = new System.Windows.Forms.Button();
            this._runsField = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _inputField
            // 
            this._inputField.AutoSize = true;
            this._inputField.Location = new System.Drawing.Point(26, 35);
            this._inputField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._inputField.Name = "_inputField";
            this._inputField.Size = new System.Drawing.Size(49, 22);
            this._inputField.TabIndex = 0;
            this._inputField.Text = "input";
            this._inputField.Click += new System.EventHandler(this._currencyNamesUriLabel_Click);
            // 
            // _outputField
            // 
            this._outputField.AutoSize = true;
            this._outputField.Location = new System.Drawing.Point(26, 101);
            this._outputField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._outputField.Name = "_outputField";
            this._outputField.Size = new System.Drawing.Size(60, 22);
            this._outputField.TabIndex = 1;
            this._outputField.Text = "output";
            this._outputField.Click += new System.EventHandler(this._currencyInfoUriLabel_Click);
            // 
            // _input
            // 
            this._input.Location = new System.Drawing.Point(30, 63);
            this._input.Margin = new System.Windows.Forms.Padding(4);
            this._input.Name = "_input";
            this._input.Size = new System.Drawing.Size(244, 28);
            this._input.TabIndex = 2;
            // 
            // _output
            // 
            this._output.Location = new System.Drawing.Point(30, 127);
            this._output.Margin = new System.Windows.Forms.Padding(4);
            this._output.Name = "_output";
            this._output.Size = new System.Drawing.Size(244, 28);
            this._output.TabIndex = 3;
            // 
            // _averageTime
            // 
            this._averageTime.AutoSize = true;
            this._averageTime.Location = new System.Drawing.Point(26, 195);
            this._averageTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._averageTime.Name = "_averageTime";
            this._averageTime.Size = new System.Drawing.Size(118, 22);
            this._averageTime.TabIndex = 4;
            this._averageTime.Text = "average time:";
            // 
            // _averageTimeResult
            // 
            this._averageTimeResult.AutoSize = true;
            this._averageTimeResult.Location = new System.Drawing.Point(141, 195);
            this._averageTimeResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._averageTimeResult.Name = "_averageTimeResult";
            this._averageTimeResult.Size = new System.Drawing.Size(20, 22);
            this._averageTimeResult.TabIndex = 5;
            this._averageTimeResult.Text = "0";
            // 
            // runs
            // 
            this.runs.FormattingEnabled = true;
            this.runs.ItemHeight = 22;
            this.runs.Location = new System.Drawing.Point(313, 63);
            this.runs.Margin = new System.Windows.Forms.Padding(4);
            this.runs.Name = "runs";
            this.runs.Size = new System.Drawing.Size(336, 92);
            this.runs.TabIndex = 0;
            this.runs.SelectedIndexChanged += new System.EventHandler(this._updateTimesList_SelectedIndexChanged);
            // 
            // _async
            // 
            this._async.AutoSize = true;
            this._async.Location = new System.Drawing.Point(192, 163);
            this._async.Margin = new System.Windows.Forms.Padding(4);
            this._async.Name = "_async";
            this._async.Size = new System.Drawing.Size(82, 26);
            this._async.TabIndex = 7;
            this._async.TabStop = true;
            this._async.Text = "async";
            this._async.UseVisualStyleBackColor = true;
            this._async.CheckedChanged += new System.EventHandler(this._asyncUsingRadioButton_CheckedChanged);
            // 
            // _sync
            // 
            this._sync.AutoSize = true;
            this._sync.Location = new System.Drawing.Point(30, 163);
            this._sync.Margin = new System.Windows.Forms.Padding(4);
            this._sync.Name = "_sync";
            this._sync.Size = new System.Drawing.Size(72, 26);
            this._sync.TabIndex = 8;
            this._sync.TabStop = true;
            this._sync.Text = "sync";
            this._sync.UseVisualStyleBackColor = true;
            this._sync.CheckedChanged += new System.EventHandler(this._syncUsingRadioButton_CheckedChanged);
            // 
            // _go
            // 
            this._go.BackColor = System.Drawing.SystemColors.Control;
            this._go.Location = new System.Drawing.Point(530, 186);
            this._go.Margin = new System.Windows.Forms.Padding(4);
            this._go.Name = "_go";
            this._go.Size = new System.Drawing.Size(119, 31);
            this._go.TabIndex = 9;
            this._go.Text = "go";
            this._go.UseVisualStyleBackColor = false;
            this._go.Click += new System.EventHandler(this._saveCurrenciesButton_Click_1);
            // 
            // _runsField
            // 
            this._runsField.AutoSize = true;
            this._runsField.Location = new System.Drawing.Point(309, 35);
            this._runsField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._runsField.Name = "_runsField";
            this._runsField.Size = new System.Drawing.Size(45, 22);
            this._runsField.TabIndex = 10;
            this._runsField.Text = "runs";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 246);
            this.Controls.Add(this._runsField);
            this.Controls.Add(this.runs);
            this.Controls.Add(this._go);
            this.Controls.Add(this._sync);
            this.Controls.Add(this._async);
            this.Controls.Add(this._averageTimeResult);
            this.Controls.Add(this._averageTime);
            this.Controls.Add(this._output);
            this.Controls.Add(this._input);
            this.Controls.Add(this._outputField);
            this.Controls.Add(this._inputField);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Window";
            this.Text = "window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _inputField;
        private System.Windows.Forms.Label _outputField;
        private System.Windows.Forms.TextBox _input;
        private System.Windows.Forms.TextBox _output;
        private System.Windows.Forms.Label _averageTime;
        private System.Windows.Forms.Label _averageTimeResult;
        private System.Windows.Forms.RadioButton _async;
        private System.Windows.Forms.RadioButton _sync;
        private System.Windows.Forms.Button _go;
        private System.Windows.Forms.ListBox runs;
        private System.Windows.Forms.Label _runsField;
    }
}

