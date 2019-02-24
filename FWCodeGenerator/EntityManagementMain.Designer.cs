namespace Framework.FWCodeGenerator
{
    partial class EntityManagementMain
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
            this.CheckoutAndGenerateButton = new System.Windows.Forms.Button();
            this.EntityList = new System.Windows.Forms.TextBox();
            this.IncludeInProjectButton = new System.Windows.Forms.Button();
            this.OpenSPButton = new System.Windows.Forms.Button();
            this.OpenServiceButton = new System.Windows.Forms.Button();
            this.OpenIServiceButton = new System.Windows.Forms.Button();
            this.OpenJSButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckoutAndGenerateButton
            // 
            this.CheckoutAndGenerateButton.Location = new System.Drawing.Point(765, 378);
            this.CheckoutAndGenerateButton.Name = "CheckoutAndGenerateButton";
            this.CheckoutAndGenerateButton.Size = new System.Drawing.Size(248, 42);
            this.CheckoutAndGenerateButton.TabIndex = 0;
            this.CheckoutAndGenerateButton.Text = "TFS Check out and Generate";
            this.CheckoutAndGenerateButton.UseVisualStyleBackColor = true;
            this.CheckoutAndGenerateButton.Click += new System.EventHandler(this.CheckoutAndGenerateButton_Click);
            // 
            // EntityList
            // 
            this.EntityList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EntityList.Location = new System.Drawing.Point(13, 80);
            this.EntityList.Multiline = true;
            this.EntityList.Name = "EntityList";
            this.EntityList.Size = new System.Drawing.Size(1000, 292);
            this.EntityList.TabIndex = 1;
            // 
            // IncludeInProjectButton
            // 
            this.IncludeInProjectButton.Location = new System.Drawing.Point(511, 378);
            this.IncludeInProjectButton.Name = "IncludeInProjectButton";
            this.IncludeInProjectButton.Size = new System.Drawing.Size(248, 42);
            this.IncludeInProjectButton.TabIndex = 2;
            this.IncludeInProjectButton.Text = "Include In Projects";
            this.IncludeInProjectButton.UseVisualStyleBackColor = true;
            this.IncludeInProjectButton.Click += new System.EventHandler(this.IncludeInProjectButton_Click);
            // 
            // OpenSPButton
            // 
            this.OpenSPButton.Location = new System.Drawing.Point(90, 12);
            this.OpenSPButton.Name = "OpenSPButton";
            this.OpenSPButton.Size = new System.Drawing.Size(107, 51);
            this.OpenSPButton.TabIndex = 3;
            this.OpenSPButton.Text = "SP";
            this.OpenSPButton.UseVisualStyleBackColor = true;
            this.OpenSPButton.Click += new System.EventHandler(this.OpenEntityFileButton_Click);
            // 
            // OpenServiceButton
            // 
            this.OpenServiceButton.Location = new System.Drawing.Point(203, 12);
            this.OpenServiceButton.Name = "OpenServiceButton";
            this.OpenServiceButton.Size = new System.Drawing.Size(107, 51);
            this.OpenServiceButton.TabIndex = 4;
            this.OpenServiceButton.Text = "Service";
            this.OpenServiceButton.UseVisualStyleBackColor = true;
            this.OpenServiceButton.Click += new System.EventHandler(this.OpenEntityFileButton_Click);
            // 
            // OpenIServiceButton
            // 
            this.OpenIServiceButton.Location = new System.Drawing.Point(316, 12);
            this.OpenIServiceButton.Name = "OpenIServiceButton";
            this.OpenIServiceButton.Size = new System.Drawing.Size(107, 51);
            this.OpenIServiceButton.TabIndex = 5;
            this.OpenIServiceButton.Text = "IService";
            this.OpenIServiceButton.UseVisualStyleBackColor = true;
            this.OpenIServiceButton.Click += new System.EventHandler(this.OpenEntityFileButton_Click);
            // 
            // OpenJSButton
            // 
            this.OpenJSButton.Location = new System.Drawing.Point(429, 12);
            this.OpenJSButton.Name = "OpenJSButton";
            this.OpenJSButton.Size = new System.Drawing.Size(119, 51);
            this.OpenJSButton.TabIndex = 6;
            this.OpenJSButton.Text = "JS";
            this.OpenJSButton.UseVisualStyleBackColor = true;
            this.OpenJSButton.Click += new System.EventHandler(this.OpenEntityFileButton_Click);
            // 
            // EntityManagementMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 432);
            this.Controls.Add(this.OpenJSButton);
            this.Controls.Add(this.OpenIServiceButton);
            this.Controls.Add(this.OpenServiceButton);
            this.Controls.Add(this.OpenSPButton);
            this.Controls.Add(this.IncludeInProjectButton);
            this.Controls.Add(this.EntityList);
            this.Controls.Add(this.CheckoutAndGenerateButton);
            this.Name = "EntityManagementMain";
            this.Text = "EntityManagementMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckoutAndGenerateButton;
        private System.Windows.Forms.TextBox EntityList;
        private System.Windows.Forms.Button IncludeInProjectButton;
        private System.Windows.Forms.Button OpenSPButton;
        private System.Windows.Forms.Button OpenServiceButton;
        private System.Windows.Forms.Button OpenIServiceButton;
        private System.Windows.Forms.Button OpenJSButton;
    }
}