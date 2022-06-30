namespace Modulo_Administracion
{
    partial class frmImportarExcelProveedor
    {
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtArchivoExcel = new System.Windows.Forms.TextBox();
            this.panelBody = new System.Windows.Forms.Panel();
            this.lblInfoBody = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvArticulosConCambios = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvArticulosSinCambios = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panelSeteoPMF = new System.Windows.Forms.Panel();
            this.btnEliminarFilas = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelarPMF = new System.Windows.Forms.Button();
            this.cbFamilia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvArticulosNuevos = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvDatosExcluidos = new System.Windows.Forms.DataGridView();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblB = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblTotalArticulosProcesados = new System.Windows.Forms.Label();
            this.lblTotalArticulosExcelProveedor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosConCambios)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosSinCambios)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panelSeteoPMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosNuevos)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosExcluidos)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelHeader.Controls.Add(this.btnExcel);
            this.panelHeader.Controls.Add(this.cbProveedor);
            this.panelHeader.Controls.Add(this.lblProveedor);
            this.panelHeader.Controls.Add(this.lblMarca);
            this.panelHeader.Controls.Add(this.btnBuscar);
            this.panelHeader.Controls.Add(this.txtArchivoExcel);
            this.panelHeader.Location = new System.Drawing.Point(16, 12);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(917, 118);
            this.panelHeader.TabIndex = 37;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcel.BackColor = System.Drawing.Color.Firebrick;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(591, 17);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(267, 38);
            this.btnExcel.TabIndex = 42;
            this.btnExcel.Text = "Abrir template excel para cargar datos";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cbProveedor
            // 
            this.cbProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(119, 25);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(405, 24);
            this.cbProveedor.TabIndex = 40;
            this.cbProveedor.SelectionChangeCommitted += new System.EventHandler(this.cbProveedor_SelectionChangeCommitted);
            // 
            // lblProveedor
            // 
            this.lblProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(10, 25);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(74, 17);
            this.lblProveedor.TabIndex = 41;
            this.lblProveedor.Text = "Proveedor";
            // 
            // lblMarca
            // 
            this.lblMarca.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(13, 80);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(55, 17);
            this.lblMarca.TabIndex = 39;
            this.lblMarca.Text = "Archivo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.Firebrick;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(826, 69);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 38);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtArchivoExcel
            // 
            this.txtArchivoExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtArchivoExcel.Location = new System.Drawing.Point(121, 77);
            this.txtArchivoExcel.Name = "txtArchivoExcel";
            this.txtArchivoExcel.ReadOnly = true;
            this.txtArchivoExcel.Size = new System.Drawing.Size(675, 22);
            this.txtArchivoExcel.TabIndex = 37;
            // 
            // panelBody
            // 
            this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBody.Controls.Add(this.lblInfoBody);
            this.panelBody.Controls.Add(this.tabControl1);
            this.panelBody.Location = new System.Drawing.Point(16, 136);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(917, 468);
            this.panelBody.TabIndex = 38;
            // 
            // lblInfoBody
            // 
            this.lblInfoBody.AutoSize = true;
            this.lblInfoBody.BackColor = System.Drawing.Color.White;
            this.lblInfoBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoBody.ForeColor = System.Drawing.Color.Red;
            this.lblInfoBody.Location = new System.Drawing.Point(13, 12);
            this.lblInfoBody.Name = "lblInfoBody";
            this.lblInfoBody.Size = new System.Drawing.Size(46, 17);
            this.lblInfoBody.TabIndex = 3;
            this.lblInfoBody.Text = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(13, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 410);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.dgvArticulosConCambios);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Artículos Con Cambios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvArticulosConCambios
            // 
            this.dgvArticulosConCambios.AllowUserToAddRows = false;
            this.dgvArticulosConCambios.AllowUserToDeleteRows = false;
            this.dgvArticulosConCambios.AllowUserToOrderColumns = true;
            this.dgvArticulosConCambios.AllowUserToResizeRows = false;
            this.dgvArticulosConCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulosConCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvArticulosConCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosConCambios.Location = new System.Drawing.Point(6, 6);
            this.dgvArticulosConCambios.Name = "dgvArticulosConCambios";
            this.dgvArticulosConCambios.RowHeadersWidth = 51;
            this.dgvArticulosConCambios.RowTemplate.Height = 24;
            this.dgvArticulosConCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosConCambios.Size = new System.Drawing.Size(873, 261);
            this.dgvArticulosConCambios.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvArticulosSinCambios);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(885, 381);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Artículos Sin Cambios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvArticulosSinCambios
            // 
            this.dgvArticulosSinCambios.AllowUserToAddRows = false;
            this.dgvArticulosSinCambios.AllowUserToDeleteRows = false;
            this.dgvArticulosSinCambios.AllowUserToOrderColumns = true;
            this.dgvArticulosSinCambios.AllowUserToResizeRows = false;
            this.dgvArticulosSinCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulosSinCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvArticulosSinCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosSinCambios.Location = new System.Drawing.Point(6, 4);
            this.dgvArticulosSinCambios.Name = "dgvArticulosSinCambios";
            this.dgvArticulosSinCambios.ReadOnly = true;
            this.dgvArticulosSinCambios.RowHeadersWidth = 51;
            this.dgvArticulosSinCambios.RowTemplate.Height = 24;
            this.dgvArticulosSinCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosSinCambios.Size = new System.Drawing.Size(873, 372);
            this.dgvArticulosSinCambios.TabIndex = 18;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelSeteoPMF);
            this.tabPage3.Controls.Add(this.dgvArticulosNuevos);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(885, 381);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Artículos Nuevos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panelSeteoPMF
            // 
            this.panelSeteoPMF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeteoPMF.Controls.Add(this.btnEliminarFilas);
            this.panelSeteoPMF.Controls.Add(this.label4);
            this.panelSeteoPMF.Controls.Add(this.btnAplicar);
            this.panelSeteoPMF.Controls.Add(this.btnCancelarPMF);
            this.panelSeteoPMF.Controls.Add(this.cbFamilia);
            this.panelSeteoPMF.Controls.Add(this.label1);
            this.panelSeteoPMF.Controls.Add(this.cbMarca);
            this.panelSeteoPMF.Controls.Add(this.label3);
            this.panelSeteoPMF.Location = new System.Drawing.Point(6, 174);
            this.panelSeteoPMF.Name = "panelSeteoPMF";
            this.panelSeteoPMF.Size = new System.Drawing.Size(873, 225);
            this.panelSeteoPMF.TabIndex = 44;
            // 
            // btnEliminarFilas
            // 
            this.btnEliminarFilas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminarFilas.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarFilas.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFilas.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFilas.Location = new System.Drawing.Point(568, 153);
            this.btnEliminarFilas.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarFilas.Name = "btnEliminarFilas";
            this.btnEliminarFilas.Size = new System.Drawing.Size(138, 42);
            this.btnEliminarFilas.TabIndex = 52;
            this.btnEliminarFilas.Text = "Eliminar Fila/s";
            this.btnEliminarFilas.UseVisualStyleBackColor = false;
            this.btnEliminarFilas.Click += new System.EventHandler(this.btnEliminarFilas_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(622, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "Selecciona filas para asignarle proveedor - marca - familia ,  luego presionar ap" +
    "licar";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAplicar.BackColor = System.Drawing.Color.Firebrick;
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(568, 51);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(138, 42);
            this.btnAplicar.TabIndex = 50;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelarPMF
            // 
            this.btnCancelarPMF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelarPMF.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarPMF.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPMF.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPMF.Location = new System.Drawing.Point(568, 103);
            this.btnCancelarPMF.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarPMF.Name = "btnCancelarPMF";
            this.btnCancelarPMF.Size = new System.Drawing.Size(138, 42);
            this.btnCancelarPMF.TabIndex = 49;
            this.btnCancelarPMF.Text = "Cancelar";
            this.btnCancelarPMF.UseVisualStyleBackColor = false;
            this.btnCancelarPMF.Click += new System.EventHandler(this.btnCancelarPMF_Click);
            // 
            // cbFamilia
            // 
            this.cbFamilia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(135, 91);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(405, 24);
            this.cbFamilia.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Familia";
            // 
            // cbMarca
            // 
            this.cbMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(135, 61);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(405, 24);
            this.cbMarca.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "Marca";
            // 
            // dgvArticulosNuevos
            // 
            this.dgvArticulosNuevos.AllowUserToAddRows = false;
            this.dgvArticulosNuevos.AllowUserToDeleteRows = false;
            this.dgvArticulosNuevos.AllowUserToOrderColumns = true;
            this.dgvArticulosNuevos.AllowUserToResizeRows = false;
            this.dgvArticulosNuevos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulosNuevos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvArticulosNuevos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosNuevos.Location = new System.Drawing.Point(6, 6);
            this.dgvArticulosNuevos.Name = "dgvArticulosNuevos";
            this.dgvArticulosNuevos.ReadOnly = true;
            this.dgvArticulosNuevos.RowHeadersWidth = 51;
            this.dgvArticulosNuevos.RowTemplate.Height = 24;
            this.dgvArticulosNuevos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulosNuevos.Size = new System.Drawing.Size(873, 162);
            this.dgvArticulosNuevos.TabIndex = 18;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvDatosExcluidos);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(885, 381);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Datos Excluidos";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvDatosExcluidos
            // 
            this.dgvDatosExcluidos.AllowUserToAddRows = false;
            this.dgvDatosExcluidos.AllowUserToDeleteRows = false;
            this.dgvDatosExcluidos.AllowUserToOrderColumns = true;
            this.dgvDatosExcluidos.AllowUserToResizeRows = false;
            this.dgvDatosExcluidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatosExcluidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDatosExcluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosExcluidos.Location = new System.Drawing.Point(6, 6);
            this.dgvDatosExcluidos.Name = "dgvDatosExcluidos";
            this.dgvDatosExcluidos.ReadOnly = true;
            this.dgvDatosExcluidos.RowHeadersWidth = 51;
            this.dgvDatosExcluidos.RowTemplate.Height = 24;
            this.dgvDatosExcluidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosExcluidos.Size = new System.Drawing.Size(873, 478);
            this.dgvDatosExcluidos.TabIndex = 18;
            // 
            // panelFooter
            // 
            this.panelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFooter.Controls.Add(this.btnImportar);
            this.panelFooter.Controls.Add(this.btnSalir);
            this.panelFooter.Controls.Add(this.btnCancelarSeleccion);
            this.panelFooter.Location = new System.Drawing.Point(16, 708);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(917, 66);
            this.panelFooter.TabIndex = 39;
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImportar.BackColor = System.Drawing.Color.Firebrick;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Location = new System.Drawing.Point(570, 14);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(107, 42);
            this.btnImportar.TabIndex = 33;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(799, 15);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 42);
            this.btnSalir.TabIndex = 32;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelarSeleccion
            // 
            this.btnCancelarSeleccion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelarSeleccion.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarSeleccion.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarSeleccion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarSeleccion.Location = new System.Drawing.Point(685, 15);
            this.btnCancelarSeleccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarSeleccion.Name = "btnCancelarSeleccion";
            this.btnCancelarSeleccion.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarSeleccion.TabIndex = 31;
            this.btnCancelarSeleccion.Text = "Cancelar";
            this.btnCancelarSeleccion.UseVisualStyleBackColor = false;
            this.btnCancelarSeleccion.Click += new System.EventHandler(this.btnCancelarSeleccion_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblB);
            this.panel1.Controls.Add(this.lblA);
            this.panel1.Controls.Add(this.lblTotalArticulosProcesados);
            this.panel1.Controls.Add(this.lblTotalArticulosExcelProveedor);
            this.panel1.Location = new System.Drawing.Point(16, 610);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 92);
            this.panel1.TabIndex = 40;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(234, 51);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(16, 17);
            this.lblB.TabIndex = 4;
            this.lblB.Text = "0";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(267, 21);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(16, 17);
            this.lblA.TabIndex = 3;
            this.lblA.Text = "0";
            // 
            // lblTotalArticulosProcesados
            // 
            this.lblTotalArticulosProcesados.AutoSize = true;
            this.lblTotalArticulosProcesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArticulosProcesados.Location = new System.Drawing.Point(20, 51);
            this.lblTotalArticulosProcesados.Name = "lblTotalArticulosProcesados";
            this.lblTotalArticulosProcesados.Size = new System.Drawing.Size(208, 17);
            this.lblTotalArticulosProcesados.TabIndex = 2;
            this.lblTotalArticulosProcesados.Text = "Total Articulos Procesados:";
            // 
            // lblTotalArticulosExcelProveedor
            // 
            this.lblTotalArticulosExcelProveedor.AutoSize = true;
            this.lblTotalArticulosExcelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArticulosExcelProveedor.Location = new System.Drawing.Point(20, 21);
            this.lblTotalArticulosExcelProveedor.Name = "lblTotalArticulosExcelProveedor";
            this.lblTotalArticulosExcelProveedor.Size = new System.Drawing.Size(241, 17);
            this.lblTotalArticulosExcelProveedor.TabIndex = 0;
            this.lblTotalArticulosExcelProveedor.Text = "Total Articulos Excel Proveedor:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 102);
            this.panel2.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(13, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 42);
            this.button1.TabIndex = 52;
            this.button1.Text = "Eliminar Fila/s";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnEliminarFilas_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Seleccione filas para excluirlas de la importación";
            // 
            // frmImportarExcelProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 795);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportarExcelProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Excel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportarExcel_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosConCambios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosSinCambios)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panelSeteoPMF.ResumeLayout(false);
            this.panelSeteoPMF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosNuevos)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosExcluidos)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvArticulosConCambios;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panelSeteoPMF;
        private System.Windows.Forms.Button btnEliminarFilas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelarPMF;
        private System.Windows.Forms.ComboBox cbFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvArticulosNuevos;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvDatosExcluidos;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtArchivoExcel;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.Label lblInfoBody;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvArticulosSinCambios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblTotalArticulosProcesados;
        private System.Windows.Forms.Label lblTotalArticulosExcelProveedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}