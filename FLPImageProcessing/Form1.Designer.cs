namespace FLPImageProcessing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectImage = new Button();
            btnProcessImage = new Button();
            pictureBoxEdges = new PictureBox();
            pictureBoxQuantized = new PictureBox();
            progressBar = new ProgressBar();
            lblOriginalImage = new Label();
            lblProcessedImage = new Label();
            btnChange = new Button();
            lblLoading = new Label();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEdges).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuantized).BeginInit();
            SuspendLayout();
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(12, 433);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(97, 23);
            btnSelectImage.TabIndex = 0;
            btnSelectImage.Text = "Enviar";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // btnProcessImage
            // 
            btnProcessImage.Enabled = false;
            btnProcessImage.Location = new Point(474, 433);
            btnProcessImage.Name = "btnProcessImage";
            btnProcessImage.Size = new Size(97, 23);
            btnProcessImage.TabIndex = 1;
            btnProcessImage.Text = "Processar";
            btnProcessImage.UseVisualStyleBackColor = true;
            btnProcessImage.Click += btnProcessImage_Click;
            // 
            // pictureBoxEdges
            // 
            pictureBoxEdges.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEdges.Location = new Point(12, 27);
            pictureBoxEdges.Name = "pictureBoxEdges";
            pictureBoxEdges.Size = new Size(400, 400);
            pictureBoxEdges.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxEdges.TabIndex = 2;
            pictureBoxEdges.TabStop = false;
            pictureBoxEdges.Click += pictureBoxEdges_Click;
            // 
            // pictureBoxQuantized
            // 
            pictureBoxQuantized.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxQuantized.Location = new Point(474, 27);
            pictureBoxQuantized.Name = "pictureBoxQuantized";
            pictureBoxQuantized.Size = new Size(400, 400);
            pictureBoxQuantized.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxQuantized.TabIndex = 3;
            pictureBoxQuantized.TabStop = false;
            pictureBoxQuantized.Click += pictureBoxQuantized_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 506);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(862, 23);
            progressBar.TabIndex = 4;
            progressBar.Visible = false;
            // 
            // lblOriginalImage
            // 
            lblOriginalImage.AutoSize = true;
            lblOriginalImage.Location = new Point(125, 9);
            lblOriginalImage.Name = "lblOriginalImage";
            lblOriginalImage.Size = new Size(96, 15);
            lblOriginalImage.TabIndex = 5;
            lblOriginalImage.Text = "Imagem Original";
            // 
            // lblProcessedImage
            // 
            lblProcessedImage.AutoSize = true;
            lblProcessedImage.Location = new Point(643, 9);
            lblProcessedImage.Name = "lblProcessedImage";
            lblProcessedImage.Size = new Size(113, 15);
            lblProcessedImage.TabIndex = 6;
            lblProcessedImage.Text = "Imagem Processada";
            // 
            // btnChange
            // 
            btnChange.Enabled = false;
            btnChange.Location = new Point(748, 433);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(126, 23);
            btnChange.TabIndex = 7;
            btnChange.Text = "Exibir Preto e Branco";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Location = new Point(399, 488);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(83, 15);
            lblLoading.TabIndex = 8;
            lblLoading.Text = "Processando...";
            lblLoading.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(315, 433);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(97, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(886, 552);
            Controls.Add(btnCancel);
            Controls.Add(lblLoading);
            Controls.Add(btnChange);
            Controls.Add(lblProcessedImage);
            Controls.Add(lblOriginalImage);
            Controls.Add(progressBar);
            Controls.Add(pictureBoxQuantized);
            Controls.Add(pictureBoxEdges);
            Controls.Add(btnProcessImage);
            Controls.Add(btnSelectImage);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Processar Imagem";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxEdges).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuantized).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectImage;
        private Button btnProcessImage;
        private PictureBox pictureBoxEdges;
        private PictureBox pictureBoxQuantized;
        private ProgressBar progressBar;
        private Label lblOriginalImage;
        private Label lblProcessedImage;
        private Button btnChange;
        private Label lblLoading;
        private Button btnCancel;
    }
}
