namespace Lab_24_Shovkoplias
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Кнопки керування
        private System.Windows.Forms.Button btnStartRedoc;
        private System.Windows.Forms.Button btnStopRedoc;
        private System.Windows.Forms.Button btnStartMdc2;
        private System.Windows.Forms.Button btnStopMdc2;
        private System.Windows.Forms.Button btnStartPkzip;
        private System.Windows.Forms.Button btnStopPkzip;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnStopAll;

        // Поля вивода логов для алгоритмів
        private System.Windows.Forms.TextBox textBoxRedoc;
        private System.Windows.Forms.TextBox textBoxMdc2;
        private System.Windows.Forms.TextBox textBoxPkzip;

        /// <summary>
        /// Освобождает все используемые ресурсы
        /// </summary>
        /// <param name="disposing">true, если управляемый ресурс должен быть удален; иначе false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически сгенерированный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartRedoc = new System.Windows.Forms.Button();
            this.btnStopRedoc = new System.Windows.Forms.Button();
            this.btnStartMdc2 = new System.Windows.Forms.Button();
            this.btnStopMdc2 = new System.Windows.Forms.Button();
            this.btnStartPkzip = new System.Windows.Forms.Button();
            this.btnStopPkzip = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.textBoxRedoc = new System.Windows.Forms.TextBox();
            this.textBoxMdc2 = new System.Windows.Forms.TextBox();
            this.textBoxPkzip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartRedoc
            // 
            this.btnStartRedoc.Location = new System.Drawing.Point(20, 270);
            this.btnStartRedoc.Name = "btnStartRedoc";
            this.btnStartRedoc.Size = new System.Drawing.Size(100, 30);
            this.btnStartRedoc.TabIndex = 0;
            this.btnStartRedoc.Text = "Start REDOC";
            this.btnStartRedoc.UseVisualStyleBackColor = true;
            // 
            // btnStopRedoc
            // 
            this.btnStopRedoc.ForeColor = System.Drawing.Color.Red;
            this.btnStopRedoc.Location = new System.Drawing.Point(20, 310);
            this.btnStopRedoc.Name = "btnStopRedoc";
            this.btnStopRedoc.Size = new System.Drawing.Size(100, 30);
            this.btnStopRedoc.TabIndex = 1;
            this.btnStopRedoc.Text = "Stop REDOC";
            this.btnStopRedoc.UseVisualStyleBackColor = true;
            // 
            // btnStartMdc2
            // 
            this.btnStartMdc2.Location = new System.Drawing.Point(160, 270);
            this.btnStartMdc2.Name = "btnStartMdc2";
            this.btnStartMdc2.Size = new System.Drawing.Size(100, 30);
            this.btnStartMdc2.TabIndex = 2;
            this.btnStartMdc2.Text = "Start MDC-2";
            this.btnStartMdc2.UseVisualStyleBackColor = true;
            // 
            // btnStopMdc2
            // 
            this.btnStopMdc2.ForeColor = System.Drawing.Color.Red;
            this.btnStopMdc2.Location = new System.Drawing.Point(160, 310);
            this.btnStopMdc2.Name = "btnStopMdc2";
            this.btnStopMdc2.Size = new System.Drawing.Size(100, 30);
            this.btnStopMdc2.TabIndex = 3;
            this.btnStopMdc2.Text = "Stop MDC-2";
            this.btnStopMdc2.UseVisualStyleBackColor = true;
            // 
            // btnStartPkzip
            // 
            this.btnStartPkzip.Location = new System.Drawing.Point(300, 270);
            this.btnStartPkzip.Name = "btnStartPkzip";
            this.btnStartPkzip.Size = new System.Drawing.Size(100, 30);
            this.btnStartPkzip.TabIndex = 4;
            this.btnStartPkzip.Text = "Start PKZIP";
            this.btnStartPkzip.UseVisualStyleBackColor = true;
            // 
            // btnStopPkzip
            // 
            this.btnStopPkzip.ForeColor = System.Drawing.Color.Red;
            this.btnStopPkzip.Location = new System.Drawing.Point(300, 310);
            this.btnStopPkzip.Name = "btnStopPkzip";
            this.btnStopPkzip.Size = new System.Drawing.Size(100, 30);
            this.btnStopPkzip.TabIndex = 5;
            this.btnStopPkzip.Text = "Stop PKZIP";
            this.btnStopPkzip.UseVisualStyleBackColor = true;
            // 
            // btnStartAll
            // 
            this.btnStartAll.Location = new System.Drawing.Point(420, 270);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(100, 30);
            this.btnStartAll.TabIndex = 6;
            this.btnStartAll.Text = "Start All";
            this.btnStartAll.UseVisualStyleBackColor = true;
            // 
            // btnStopAll
            // 
            this.btnStopAll.ForeColor = System.Drawing.Color.Red;
            this.btnStopAll.Location = new System.Drawing.Point(420, 310);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(100, 30);
            this.btnStopAll.TabIndex = 7;
            this.btnStopAll.Text = "Stop All";
            this.btnStopAll.UseVisualStyleBackColor = true;
            // 
            // textBoxRedoc
            // 
            this.textBoxRedoc.Location = new System.Drawing.Point(20, 20);
            this.textBoxRedoc.Multiline = true;
            this.textBoxRedoc.Name = "textBoxRedoc";
            this.textBoxRedoc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRedoc.Size = new System.Drawing.Size(200, 230);
            this.textBoxRedoc.TabIndex = 8;
            // 
            // textBoxMdc2
            // 
            this.textBoxMdc2.Location = new System.Drawing.Point(240, 20);
            this.textBoxMdc2.Multiline = true;
            this.textBoxMdc2.Name = "textBoxMdc2";
            this.textBoxMdc2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMdc2.Size = new System.Drawing.Size(200, 230);
            this.textBoxMdc2.TabIndex = 9;
            // 
            // textBoxPkzip
            // 
            this.textBoxPkzip.Location = new System.Drawing.Point(460, 20);
            this.textBoxPkzip.Multiline = true;
            this.textBoxPkzip.Name = "textBoxPkzip";
            this.textBoxPkzip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPkzip.Size = new System.Drawing.Size(200, 230);
            this.textBoxPkzip.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 360);
            this.Controls.Add(this.textBoxPkzip);
            this.Controls.Add(this.textBoxMdc2);
            this.Controls.Add(this.textBoxRedoc);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnStartAll);
            this.Controls.Add(this.btnStopPkzip);
            this.Controls.Add(this.btnStartPkzip);
            this.Controls.Add(this.btnStopMdc2);
            this.Controls.Add(this.btnStartMdc2);
            this.Controls.Add(this.btnStopRedoc);
            this.Controls.Add(this.btnStartRedoc);
            this.Name = "Form1";
            this.Text = "Encryption Algorithms";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}