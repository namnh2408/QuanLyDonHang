namespace QuanLyDonHang.View.FormControl
{
    partial class uc_PhieuThu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.epvKhachHang = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUsers = new System.Windows.Forms.Label();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVAT = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFinalMoney = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrePayment = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.grbTTCT = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.mskPhone = new System.Windows.Forms.MaskedTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cboGiaoHang = new System.Windows.Forms.ComboBox();
            this.cboThanhToan = new System.Windows.Forms.ComboBox();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrePayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.epvKhachHang)).BeginInit();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT)).BeginInit();
            this.grbTTCT.SuspendLayout();
            this.SuspendLayout();
            // 
            // epvKhachHang
            // 
            this.epvKhachHang.ContainerControl = this;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUsers.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.ForeColor = System.Drawing.Color.Red;
            this.lblUsers.Location = new System.Drawing.Point(691, 3);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(404, 42);
            this.lblUsers.TabIndex = 65;
            this.lblUsers.Text = "QUẢN LÝ PHIẾU THU";
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.dgvKhachHang);
            this.grbDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbDanhSach.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDanhSach.Location = new System.Drawing.Point(135, 397);
            this.grbDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbDanhSach.Size = new System.Drawing.Size(1615, 364);
            this.grbDanhSach.TabIndex = 69;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách";
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKhachHang.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CustomerID,
            this.Code,
            this.CustomerName,
            this.Phone,
            this.Address,
            this.OrderDate,
            this.TotalPrice,
            this.VAT,
            this.PrePayment,
            this.FinalMoney});
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.EnableHeadersVisualStyles = false;
            this.dgvKhachHang.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKhachHang.Location = new System.Drawing.Point(3, 30);
            this.dgvKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.Size = new System.Drawing.Size(1609, 332);
            this.dgvKhachHang.TabIndex = 0;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtVAT);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFinalMoney);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPrePayment);
            this.groupBox1.Controls.Add(this.txtTotalPrice);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(1256, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(494, 344);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng cộng";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(211, 113);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(249, 35);
            this.txtVAT.TabIndex = 79;
            this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(64, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 27);
            this.label7.TabIndex = 77;
            this.label7.Text = "Trả trước :";
            // 
            // txtFinalMoney
            // 
            this.txtFinalMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFinalMoney.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalMoney.ForeColor = System.Drawing.Color.Black;
            this.txtFinalMoney.Location = new System.Drawing.Point(211, 204);
            this.txtFinalMoney.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFinalMoney.Name = "txtFinalMoney";
            this.txtFinalMoney.Size = new System.Drawing.Size(249, 35);
            this.txtFinalMoney.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(55, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 27);
            this.label11.TabIndex = 51;
            this.label11.Text = "Thành tiền :";
            // 
            // txtPrePayment
            // 
            this.txtPrePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrePayment.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrePayment.ForeColor = System.Drawing.Color.Black;
            this.txtPrePayment.Location = new System.Drawing.Point(211, 159);
            this.txtPrePayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrePayment.Name = "txtPrePayment";
            this.txtPrePayment.Size = new System.Drawing.Size(249, 35);
            this.txtPrePayment.TabIndex = 52;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPrice.Location = new System.Drawing.Point(211, 65);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(249, 35);
            this.txtTotalPrice.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(113, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 27);
            this.label13.TabIndex = 48;
            this.label13.Text = "VAT :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(53, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 27);
            this.label14.TabIndex = 48;
            this.label14.Text = "Tổng cộng :";
            // 
            // grbTTCT
            // 
            this.grbTTCT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grbTTCT.Controls.Add(this.btnXemChiTiet);
            this.grbTTCT.Controls.Add(this.btnSearch);
            this.grbTTCT.Controls.Add(this.btnXoa);
            this.grbTTCT.Controls.Add(this.btnLuu);
            this.grbTTCT.Controls.Add(this.btnHuy);
            this.grbTTCT.Controls.Add(this.btnSua);
            this.grbTTCT.Controls.Add(this.btnThem);
            this.grbTTCT.Controls.Add(this.dtpNgay);
            this.grbTTCT.Controls.Add(this.mskPhone);
            this.grbTTCT.Controls.Add(this.lblPhone);
            this.grbTTCT.Controls.Add(this.cboGiaoHang);
            this.grbTTCT.Controls.Add(this.cboThanhToan);
            this.grbTTCT.Controls.Add(this.cboKhachHang);
            this.grbTTCT.Controls.Add(this.txtGhiChu);
            this.grbTTCT.Controls.Add(this.txtAddress);
            this.grbTTCT.Controls.Add(this.label5);
            this.grbTTCT.Controls.Add(this.label6);
            this.grbTTCT.Controls.Add(this.label4);
            this.grbTTCT.Controls.Add(this.label1);
            this.grbTTCT.Controls.Add(this.label3);
            this.grbTTCT.Controls.Add(this.txtOrderCode);
            this.grbTTCT.Controls.Add(this.label2);
            this.grbTTCT.Controls.Add(this.lblHoTen);
            this.grbTTCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbTTCT.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTTCT.ForeColor = System.Drawing.Color.Black;
            this.grbTTCT.Location = new System.Drawing.Point(135, 48);
            this.grbTTCT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbTTCT.Name = "grbTTCT";
            this.grbTTCT.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbTTCT.Size = new System.Drawing.Size(1115, 344);
            this.grbTTCT.TabIndex = 71;
            this.grbTTCT.TabStop = false;
            this.grbTTCT.Text = "Thông tin chi tiết";
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(7, 302);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(231, 38);
            this.btnSearch.TabIndex = 81;
            this.btnSearch.Text = "&Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Location = new System.Drawing.Point(484, 258);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(111, 38);
            this.btnXoa.TabIndex = 82;
            this.btnXoa.Text = "&Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSize = true;
            this.btnLuu.Location = new System.Drawing.Point(365, 258);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(111, 38);
            this.btnLuu.TabIndex = 83;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.AutoSize = true;
            this.btnHuy.Location = new System.Drawing.Point(245, 258);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(111, 38);
            this.btnHuy.TabIndex = 84;
            this.btnHuy.Text = "&Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.Location = new System.Drawing.Point(127, 258);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(111, 38);
            this.btnSua.TabIndex = 85;
            this.btnSua.Text = "&Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(7, 258);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(111, 38);
            this.btnThem.TabIndex = 86;
            this.btnThem.Text = "&Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgay.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(818, 135);
            this.dtpNgay.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(261, 34);
            this.dtpNgay.TabIndex = 80;
            // 
            // mskPhone
            // 
            this.mskPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskPhone.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskPhone.ForeColor = System.Drawing.Color.Black;
            this.mskPhone.Location = new System.Drawing.Point(201, 134);
            this.mskPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskPhone.Mask = "9999 000 000";
            this.mskPhone.Name = "mskPhone";
            this.mskPhone.Size = new System.Drawing.Size(181, 35);
            this.mskPhone.TabIndex = 78;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(45, 139);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(149, 27);
            this.lblPhone.TabIndex = 77;
            this.lblPhone.Text = "Số điện thoại :";
            // 
            // cboGiaoHang
            // 
            this.cboGiaoHang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGiaoHang.FormattingEnabled = true;
            this.cboGiaoHang.Location = new System.Drawing.Point(818, 88);
            this.cboGiaoHang.Name = "cboGiaoHang";
            this.cboGiaoHang.Size = new System.Drawing.Size(261, 35);
            this.cboGiaoHang.TabIndex = 76;
            // 
            // cboThanhToan
            // 
            this.cboThanhToan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThanhToan.FormattingEnabled = true;
            this.cboThanhToan.Location = new System.Drawing.Point(818, 37);
            this.cboThanhToan.Name = "cboThanhToan";
            this.cboThanhToan.Size = new System.Drawing.Size(261, 35);
            this.cboThanhToan.TabIndex = 76;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(201, 86);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(249, 35);
            this.cboKhachHang.TabIndex = 76;
            this.cboKhachHang.TextChanged += new System.EventHandler(this.cboKhachHang_TextChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.Location = new System.Drawing.Point(818, 179);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(261, 99);
            this.txtGhiChu.TabIndex = 52;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(201, 179);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(326, 35);
            this.txtAddress.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(605, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 27);
            this.label5.TabIndex = 48;
            this.label5.Text = "Thời gian giao hàng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(719, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 27);
            this.label6.TabIndex = 51;
            this.label6.Text = "Ghi chú :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(690, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 27);
            this.label4.TabIndex = 48;
            this.label4.Text = "Giao hàng :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(102, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 51;
            this.label1.Text = "Địa chỉ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(584, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 27);
            this.label3.TabIndex = 48;
            this.label3.Text = "Hình thức thanh toán :";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderCode.ForeColor = System.Drawing.Color.Black;
            this.txtOrderCode.Location = new System.Drawing.Point(201, 40);
            this.txtOrderCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.Size = new System.Drawing.Size(249, 35);
            this.txtOrderCode.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(56, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 27);
            this.label2.TabIndex = 48;
            this.label2.Text = "Khách hàng :";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.ForeColor = System.Drawing.Color.Black;
            this.lblHoTen.Location = new System.Drawing.Point(43, 45);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(151, 27);
            this.lblHoTen.TabIndex = 48;
            this.lblHoTen.Text = "Mã đơn hàng :";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.AutoSize = true;
            this.btnXemChiTiet.Enabled = false;
            this.btnXemChiTiet.Location = new System.Drawing.Point(245, 301);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(231, 38);
            this.btnXemChiTiet.TabIndex = 81;
            this.btnXemChiTiet.Text = "&Xem Chi Tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 150F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 3;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "ID Khách hàng";
            this.CustomerID.MinimumWidth = 6;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "OrderCode";
            this.Code.FillWeight = 0.7953361F;
            this.Code.HeaderText = "Mã đơn hàng";
            this.Code.MinimumWidth = 6;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.FillWeight = 0.7953361F;
            this.CustomerName.HeaderText = "Tên khách hàng";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.FillWeight = 0.7953361F;
            this.Phone.HeaderText = "Số điện thoại";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.FillWeight = 0.7953361F;
            this.Address.HeaderText = "Địa chỉ";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.FillWeight = 0.7953361F;
            this.OrderDate.HeaderText = "Ngày giao hàng";
            this.OrderDate.MinimumWidth = 6;
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalPrice.DataPropertyName = "TotalMoney";
            this.TotalPrice.FillWeight = 0.6734536F;
            this.TotalPrice.HeaderText = "Tổng tiền";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // VAT
            // 
            this.VAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VAT.DataPropertyName = "VAT";
            this.VAT.FillWeight = 0.6020935F;
            this.VAT.HeaderText = "VAT";
            this.VAT.MinimumWidth = 3;
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            // 
            // PrePayment
            // 
            this.PrePayment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PrePayment.DataPropertyName = "PrePayment";
            this.PrePayment.FillWeight = 0.5750793F;
            this.PrePayment.HeaderText = "Trả trước";
            this.PrePayment.MinimumWidth = 3;
            this.PrePayment.Name = "PrePayment";
            this.PrePayment.ReadOnly = true;
            // 
            // FinalMoney
            // 
            this.FinalMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FinalMoney.DataPropertyName = "FinalMoney";
            this.FinalMoney.FillWeight = 0.8992758F;
            this.FinalMoney.HeaderText = "Thành Tiền";
            this.FinalMoney.MinimumWidth = 3;
            this.FinalMoney.Name = "FinalMoney";
            this.FinalMoney.ReadOnly = true;
            // 
            // uc_PhieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbTTCT);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.grbDanhSach);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "uc_PhieuThu";
            this.Size = new System.Drawing.Size(1881, 832);
            this.Load += new System.EventHandler(this.uc_PhieuThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epvKhachHang)).EndInit();
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT)).EndInit();
            this.grbTTCT.ResumeLayout(false);
            this.grbTTCT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epvKhachHang;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFinalMoney;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrePayment;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grbTTCT;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.MaskedTextBox mskPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.ComboBox cboGiaoHang;
        private System.Windows.Forms.ComboBox cboThanhToan;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.NumericUpDown txtVAT;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrePayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalMoney;
    }
}
