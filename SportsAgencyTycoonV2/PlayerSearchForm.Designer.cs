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
            this.SuspendLayout();
            // 
            // cbSelectSport
            // 
            this.cbSelectSport.FormattingEnabled = true;
            this.cbSelectSport.Location = new System.Drawing.Point(12, 12);
            this.cbSelectSport.Name = "cbSelectSport";
            this.cbSelectSport.Size = new System.Drawing.Size(121, 21);
            this.cbSelectSport.TabIndex = 0;
            this.cbSelectSport.Text = "Select Sport:";
            this.cbSelectSport.SelectedIndexChanged += new System.EventHandler(this.cbSelectSport_SelectedIndexChanged);
            // 
            // cbSelectArchetype
            // 
            this.cbSelectArchetype.FormattingEnabled = true;
            this.cbSelectArchetype.Location = new System.Drawing.Point(12, 40);
            this.cbSelectArchetype.Name = "cbSelectArchetype";
            this.cbSelectArchetype.Size = new System.Drawing.Size(121, 21);
            this.cbSelectArchetype.TabIndex = 1;
            this.cbSelectArchetype.Text = "Select Archetype:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(33, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Start Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSearching
            // 
            this.lblSearching.AutoSize = true;
            this.lblSearching.Location = new System.Drawing.Point(155, 15);
            this.lblSearching.Name = "lblSearching";
            this.lblSearching.Size = new System.Drawing.Size(75, 13);
            this.lblSearching.TabIndex = 3;
            this.lblSearching.Text = "Searching: No";
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.AutoSize = true;
            this.lblSearchResults.Location = new System.Drawing.Point(155, 40);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(82, 13);
            this.lblSearchResults.TabIndex = 4;
            this.lblSearchResults.Text = "Search Results:";
            // 
            // btnStopSearch
            // 
            this.btnStopSearch.Location = new System.Drawing.Point(33, 96);
            this.btnStopSearch.Name = "btnStopSearch";
            this.btnStopSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStopSearch.TabIndex = 5;
            this.btnStopSearch.Text = "Stop Search";
            this.btnStopSearch.UseVisualStyleBackColor = true;
            this.btnStopSearch.Click += new System.EventHandler(this.btnStopSearch_Click);
            // 
            // searchTimer
            // 
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // PlayerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStopSearch);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.lblSearching);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbSelectArchetype);
            this.Controls.Add(this.cbSelectSport);
            this.Name = "PlayerSearchForm";
            this.Text = "PlayerSearchForm";
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
    }
}