namespace SportsAgencyTycoonV2
{
    partial class PlayerSearchForm
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
            this.components = new System.ComponentModel.Container();
            this.cbSelectSport = new System.Windows.Forms.ComboBox();
            this.cbSelectArchetype = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSearching = new System.Windows.Forms.Label();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.btnStopSearch = new System.Windows.Forms.Button();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.searchProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioQuick = new System.Windows.Forms.RadioButton();
            this.radioIntense = new System.Windows.Forms.RadioButton();
            this.radioDiligent = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSelectSport
            // 
            this.cbSelectSport.FormattingEnabled = true;
            this.cbSelectSport.Location = new System.Drawing.Point(24, 23);
            this.cbSelectSport.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbSelectSport.Name = "cbSelectSport";
            this.cbSelectSport.Size = new System.Drawing.Size(238, 33);
            this.cbSelectSport.TabIndex = 0;
            this.cbSelectSport.Text = "Select Sport:";
            this.cbSelectSport.SelectedIndexChanged += new System.EventHandler(this.cbSelectSport_SelectedIndexChanged);
            // 
            // cbSelectArchetype
            // 
            this.cbSelectArchetype.FormattingEnabled = true;
            this.cbSelectArchetype.Location = new System.Drawing.Point(24, 77);
            this.cbSelectArchetype.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbSelectArchetype.Name = "cbSelectArchetype";
            this.cbSelectArchetype.Size = new System.Drawing.Size(238, 33);
            this.cbSelectArchetype.TabIndex = 1;
            this.cbSelectArchetype.Text = "Select Archetype:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(66, 129);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 44);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Start Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSearching
            // 
            this.lblSearching.AutoSize = true;
            this.lblSearching.Location = new System.Drawing.Point(525, 31);
            this.lblSearching.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearching.Name = "lblSearching";
            this.lblSearching.Size = new System.Drawing.Size(148, 25);
            this.lblSearching.TabIndex = 3;
            this.lblSearching.Text = "Searching: No";
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.AutoSize = true;
            this.lblSearchResults.Location = new System.Drawing.Point(525, 79);
            this.lblSearchResults.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(164, 25);
            this.lblSearchResults.TabIndex = 4;
            this.lblSearchResults.Text = "Search Results:";
            // 
            // btnStopSearch
            // 
            this.btnStopSearch.Location = new System.Drawing.Point(66, 185);
            this.btnStopSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnStopSearch.Name = "btnStopSearch";
            this.btnStopSearch.Size = new System.Drawing.Size(150, 44);
            this.btnStopSearch.TabIndex = 5;
            this.btnStopSearch.Text = "Stop Search";
            this.btnStopSearch.UseVisualStyleBackColor = true;
            this.btnStopSearch.Click += new System.EventHandler(this.btnStopSearch_Click);
            // 
            // searchTimer
            // 
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // searchProgressBar
            // 
            this.searchProgressBar.Location = new System.Drawing.Point(24, 265);
            this.searchProgressBar.Name = "searchProgressBar";
            this.searchProgressBar.Size = new System.Drawing.Size(238, 23);
            this.searchProgressBar.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDiligent);
            this.groupBox1.Controls.Add(this.radioIntense);
            this.groupBox1.Controls.Add(this.radioQuick);
            this.groupBox1.Location = new System.Drawing.Point(272, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 137);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Type";
            // 
            // radioQuick
            // 
            this.radioQuick.AutoSize = true;
            this.radioQuick.Location = new System.Drawing.Point(7, 31);
            this.radioQuick.Name = "radioQuick";
            this.radioQuick.Size = new System.Drawing.Size(98, 29);
            this.radioQuick.TabIndex = 0;
            this.radioQuick.TabStop = true;
            this.radioQuick.Text = "Quick";
            this.radioQuick.UseVisualStyleBackColor = true;
            // 
            // radioIntense
            // 
            this.radioIntense.AutoSize = true;
            this.radioIntense.Location = new System.Drawing.Point(7, 101);
            this.radioIntense.Name = "radioIntense";
            this.radioIntense.Size = new System.Drawing.Size(113, 29);
            this.radioIntense.TabIndex = 1;
            this.radioIntense.TabStop = true;
            this.radioIntense.Text = "Intense";
            this.radioIntense.UseVisualStyleBackColor = true;
            // 
            // radioDiligent
            // 
            this.radioDiligent.AutoSize = true;
            this.radioDiligent.Location = new System.Drawing.Point(7, 66);
            this.radioDiligent.Name = "radioDiligent";
            this.radioDiligent.Size = new System.Drawing.Size(115, 29);
            this.radioDiligent.TabIndex = 2;
            this.radioDiligent.TabStop = true;
            this.radioDiligent.Text = "Diligent";
            this.radioDiligent.UseVisualStyleBackColor = true;
            // 
            // PlayerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchProgressBar);
            this.Controls.Add(this.btnStopSearch);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.lblSearching);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbSelectArchetype);
            this.Controls.Add(this.cbSelectSport);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "PlayerSearchForm";
            this.Text = "PlayerSearchForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSelectSport;
        private System.Windows.Forms.ComboBox cbSelectArchetype;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearching;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button btnStopSearch;
        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.ProgressBar searchProgressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDiligent;
        private System.Windows.Forms.RadioButton radioIntense;
        private System.Windows.Forms.RadioButton radioQuick;
    }
}