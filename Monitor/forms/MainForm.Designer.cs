namespace Monitor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.StockTab = new System.Windows.Forms.TabPage();
            this.MainStockDetail_gb = new System.Windows.Forms.GroupBox();
            this.MainStockDetailLogo_pb = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MainStockDetail_historicalData_dg = new System.Windows.Forms.DataGridView();
            this.MainStockDetail_type_lb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MainStockDetail_ticker_lb = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MainStockDetail_name_lb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MainStockTab_StockList_listbox = new System.Windows.Forms.ListBox();
            this.OportunityTab = new System.Windows.Forms.TabPage();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.HistoricalDataAutoUpdate_check = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.HistoricalDataResolutions_lb = new System.Windows.Forms.TreeView();
            this.label17 = new System.Windows.Forms.Label();
            this.HDPassword_mtb = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.HDUser_tb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.HDDefaultProvider_cb = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.RTDToggleStream_bt = new System.Windows.Forms.Button();
            this.RTDAutoStart_check = new System.Windows.Forms.CheckBox();
            this.RTDPassword_mtb = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RTDUser_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RTDDefaultProvider_cb = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.StrategyTab = new System.Windows.Forms.TabPage();
            this.MainStartegyCheckList_treeView = new System.Windows.Forms.TreeView();
            this.StrategyDetails_gb = new System.Windows.Forms.GroupBox();
            this.StrategyDetail_active_check = new System.Windows.Forms.CheckBox();
            this.StrategyDetail_identifier_lb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StrategyDetail_name_lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StrategyReload_bt = new System.Windows.Forms.Button();
            this.BrokerTab = new System.Windows.Forms.TabPage();
            this.FixedTaxTab = new System.Windows.Forms.TabPage();
            this.ConfigTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.MainConfig_RTDDefaultUser_label = new System.Windows.Forms.Label();
            this.MainConfig_RTDDefaultUser_text = new System.Windows.Forms.TextBox();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStreamButtom = new System.Windows.Forms.ToolStripSplitButton();
            this.ativarInicioAutomáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StreamStatus_lb = new System.Windows.Forms.ToolStripStatusLabel();
            this.StrategyStatus_lb = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.ativarInícioAutomáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarEstratégiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.StockTab.SuspendLayout();
            this.MainStockDetail_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainStockDetailLogo_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainStockDetail_historicalData_dg)).BeginInit();
            this.DataTab.SuspendLayout();
            this.StrategyTab.SuspendLayout();
            this.StrategyDetails_gb.SuspendLayout();
            this.ConfigTab.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.StockTab);
            this.tabControl1.Controls.Add(this.OportunityTab);
            this.tabControl1.Controls.Add(this.DataTab);
            this.tabControl1.Controls.Add(this.StrategyTab);
            this.tabControl1.Controls.Add(this.BrokerTab);
            this.tabControl1.Controls.Add(this.FixedTaxTab);
            this.tabControl1.Controls.Add(this.ConfigTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 492);
            this.tabControl1.TabIndex = 1;
            // 
            // StockTab
            // 
            this.StockTab.Controls.Add(this.MainStockDetail_gb);
            this.StockTab.Controls.Add(this.MainStockTab_StockList_listbox);
            this.StockTab.Location = new System.Drawing.Point(4, 22);
            this.StockTab.Name = "StockTab";
            this.StockTab.Size = new System.Drawing.Size(801, 466);
            this.StockTab.TabIndex = 2;
            this.StockTab.Text = "Ações";
            this.StockTab.UseVisualStyleBackColor = true;
            // 
            // MainStockDetail_gb
            // 
            this.MainStockDetail_gb.Controls.Add(this.button2);
            this.MainStockDetail_gb.Controls.Add(this.MainStockDetailLogo_pb);
            this.MainStockDetail_gb.Controls.Add(this.label2);
            this.MainStockDetail_gb.Controls.Add(this.MainStockDetail_historicalData_dg);
            this.MainStockDetail_gb.Controls.Add(this.MainStockDetail_type_lb);
            this.MainStockDetail_gb.Controls.Add(this.label6);
            this.MainStockDetail_gb.Controls.Add(this.MainStockDetail_ticker_lb);
            this.MainStockDetail_gb.Controls.Add(this.label5);
            this.MainStockDetail_gb.Controls.Add(this.MainStockDetail_name_lb);
            this.MainStockDetail_gb.Controls.Add(this.label4);
            this.MainStockDetail_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.MainStockDetail_gb.Location = new System.Drawing.Point(81, 3);
            this.MainStockDetail_gb.Name = "MainStockDetail_gb";
            this.MainStockDetail_gb.Size = new System.Drawing.Size(720, 434);
            this.MainStockDetail_gb.TabIndex = 1;
            this.MainStockDetail_gb.TabStop = false;
            this.MainStockDetail_gb.Text = "Detalhes de Ação";
            // 
            // MainStockDetailLogo_pb
            // 
            this.MainStockDetailLogo_pb.Location = new System.Drawing.Point(14, 19);
            this.MainStockDetailLogo_pb.Name = "MainStockDetailLogo_pb";
            this.MainStockDetailLogo_pb.Size = new System.Drawing.Size(73, 64);
            this.MainStockDetailLogo_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainStockDetailLogo_pb.TabIndex = 10;
            this.MainStockDetailLogo_pb.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dados Históricos:";
            // 
            // MainStockDetail_historicalData_dg
            // 
            this.MainStockDetail_historicalData_dg.AllowUserToAddRows = false;
            this.MainStockDetail_historicalData_dg.AllowUserToDeleteRows = false;
            this.MainStockDetail_historicalData_dg.AllowUserToOrderColumns = true;
            this.MainStockDetail_historicalData_dg.AllowUserToResizeRows = false;
            this.MainStockDetail_historicalData_dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainStockDetail_historicalData_dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainStockDetail_historicalData_dg.Location = new System.Drawing.Point(14, 89);
            this.MainStockDetail_historicalData_dg.Name = "MainStockDetail_historicalData_dg";
            this.MainStockDetail_historicalData_dg.ReadOnly = true;
            this.MainStockDetail_historicalData_dg.Size = new System.Drawing.Size(703, 115);
            this.MainStockDetail_historicalData_dg.TabIndex = 8;
            // 
            // MainStockDetail_type_lb
            // 
            this.MainStockDetail_type_lb.AutoSize = true;
            this.MainStockDetail_type_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainStockDetail_type_lb.Location = new System.Drawing.Point(133, 53);
            this.MainStockDetail_type_lb.Name = "MainStockDetail_type_lb";
            this.MainStockDetail_type_lb.Size = new System.Drawing.Size(34, 16);
            this.MainStockDetail_type_lb.TabIndex = 7;
            this.MainStockDetail_type_lb.Text = "tipo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(93, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tipo:";
            // 
            // MainStockDetail_ticker_lb
            // 
            this.MainStockDetail_ticker_lb.AutoSize = true;
            this.MainStockDetail_ticker_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainStockDetail_ticker_lb.Location = new System.Drawing.Point(195, 37);
            this.MainStockDetail_ticker_lb.Name = "MainStockDetail_ticker_lb";
            this.MainStockDetail_ticker_lb.Size = new System.Drawing.Size(46, 16);
            this.MainStockDetail_ticker_lb.TabIndex = 5;
            this.MainStockDetail_ticker_lb.Text = "ticker";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Código Bovespa:";
            // 
            // MainStockDetail_name_lb
            // 
            this.MainStockDetail_name_lb.AutoSize = true;
            this.MainStockDetail_name_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainStockDetail_name_lb.Location = new System.Drawing.Point(143, 23);
            this.MainStockDetail_name_lb.Name = "MainStockDetail_name_lb";
            this.MainStockDetail_name_lb.Size = new System.Drawing.Size(46, 16);
            this.MainStockDetail_name_lb.TabIndex = 3;
            this.MainStockDetail_name_lb.Text = "nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nome:";
            // 
            // MainStockTab_StockList_listbox
            // 
            this.MainStockTab_StockList_listbox.FormattingEnabled = true;
            this.MainStockTab_StockList_listbox.Location = new System.Drawing.Point(3, 1);
            this.MainStockTab_StockList_listbox.Name = "MainStockTab_StockList_listbox";
            this.MainStockTab_StockList_listbox.Size = new System.Drawing.Size(72, 433);
            this.MainStockTab_StockList_listbox.TabIndex = 0;
            this.MainStockTab_StockList_listbox.SelectedIndexChanged += new System.EventHandler(this.MainStockTab_StockList_listbox_SelectedIndexChanged);
            // 
            // OportunityTab
            // 
            this.OportunityTab.Location = new System.Drawing.Point(4, 22);
            this.OportunityTab.Name = "OportunityTab";
            this.OportunityTab.Size = new System.Drawing.Size(801, 466);
            this.OportunityTab.TabIndex = 6;
            this.OportunityTab.Text = "Oportunidades";
            this.OportunityTab.UseVisualStyleBackColor = true;
            // 
            // DataTab
            // 
            this.DataTab.Controls.Add(this.HistoricalDataAutoUpdate_check);
            this.DataTab.Controls.Add(this.button1);
            this.DataTab.Controls.Add(this.textBox1);
            this.DataTab.Controls.Add(this.HistoricalDataResolutions_lb);
            this.DataTab.Controls.Add(this.label17);
            this.DataTab.Controls.Add(this.HDPassword_mtb);
            this.DataTab.Controls.Add(this.label14);
            this.DataTab.Controls.Add(this.HDUser_tb);
            this.DataTab.Controls.Add(this.label15);
            this.DataTab.Controls.Add(this.HDDefaultProvider_cb);
            this.DataTab.Controls.Add(this.label16);
            this.DataTab.Controls.Add(this.RTDToggleStream_bt);
            this.DataTab.Controls.Add(this.RTDAutoStart_check);
            this.DataTab.Controls.Add(this.RTDPassword_mtb);
            this.DataTab.Controls.Add(this.label13);
            this.DataTab.Controls.Add(this.RTDUser_tb);
            this.DataTab.Controls.Add(this.label12);
            this.DataTab.Controls.Add(this.RTDDefaultProvider_cb);
            this.DataTab.Controls.Add(this.label11);
            this.DataTab.Location = new System.Drawing.Point(4, 22);
            this.DataTab.Name = "DataTab";
            this.DataTab.Size = new System.Drawing.Size(801, 466);
            this.DataTab.TabIndex = 7;
            this.DataTab.Text = "Dados";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // HistoricalDataAutoUpdate_check
            // 
            this.HistoricalDataAutoUpdate_check.AutoSize = true;
            this.HistoricalDataAutoUpdate_check.Location = new System.Drawing.Point(562, 101);
            this.HistoricalDataAutoUpdate_check.Name = "HistoricalDataAutoUpdate_check";
            this.HistoricalDataAutoUpdate_check.Size = new System.Drawing.Size(151, 17);
            this.HistoricalDataAutoUpdate_check.TabIndex = 26;
            this.HistoricalDataAutoUpdate_check.Text = "Atualizar Automaticamente";
            this.HistoricalDataAutoUpdate_check.UseVisualStyleBackColor = true;
            this.HistoricalDataAutoUpdate_check.CheckedChanged += new System.EventHandler(this.HistoricalDataAutoUpdate_check_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Adicionar Resolução";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(631, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 24;
            // 
            // HistoricalDataResolutions_lb
            // 
            this.HistoricalDataResolutions_lb.CheckBoxes = true;
            this.HistoricalDataResolutions_lb.Location = new System.Drawing.Point(562, 146);
            this.HistoricalDataResolutions_lb.Name = "HistoricalDataResolutions_lb";
            this.HistoricalDataResolutions_lb.ShowLines = false;
            this.HistoricalDataResolutions_lb.ShowPlusMinus = false;
            this.HistoricalDataResolutions_lb.Size = new System.Drawing.Size(63, 133);
            this.HistoricalDataResolutions_lb.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(559, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Resoluções:";
            // 
            // HDPassword_mtb
            // 
            this.HDPassword_mtb.Location = new System.Drawing.Point(562, 75);
            this.HDPassword_mtb.Name = "HDPassword_mtb";
            this.HDPassword_mtb.PromptChar = '*';
            this.HDPassword_mtb.Size = new System.Drawing.Size(211, 20);
            this.HDPassword_mtb.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(510, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Senha:";
            // 
            // HDUser_tb
            // 
            this.HDUser_tb.Location = new System.Drawing.Point(562, 49);
            this.HDUser_tb.Name = "HDUser_tb";
            this.HDUser_tb.Size = new System.Drawing.Size(211, 20);
            this.HDUser_tb.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(510, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Usuário:";
            // 
            // HDDefaultProvider_cb
            // 
            this.HDDefaultProvider_cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.HDDefaultProvider_cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.HDDefaultProvider_cb.FormattingEnabled = true;
            this.HDDefaultProvider_cb.Location = new System.Drawing.Point(562, 22);
            this.HDDefaultProvider_cb.Name = "HDDefaultProvider_cb";
            this.HDDefaultProvider_cb.Size = new System.Drawing.Size(211, 21);
            this.HDDefaultProvider_cb.TabIndex = 17;
            this.HDDefaultProvider_cb.SelectedIndexChanged += new System.EventHandler(this.HDDefaultProvider_cb_SelectedIndexChanged_1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(368, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Provedor de Dados Históricos Padrão:";
            // 
            // RTDToggleStream_bt
            // 
            this.RTDToggleStream_bt.Location = new System.Drawing.Point(21, 101);
            this.RTDToggleStream_bt.Name = "RTDToggleStream_bt";
            this.RTDToggleStream_bt.Size = new System.Drawing.Size(113, 23);
            this.RTDToggleStream_bt.TabIndex = 15;
            this.RTDToggleStream_bt.Text = "Iniciar RTD";
            this.RTDToggleStream_bt.UseVisualStyleBackColor = true;
            // 
            // RTDAutoStart_check
            // 
            this.RTDAutoStart_check.AutoSize = true;
            this.RTDAutoStart_check.Location = new System.Drawing.Point(140, 105);
            this.RTDAutoStart_check.Name = "RTDAutoStart_check";
            this.RTDAutoStart_check.Size = new System.Drawing.Size(139, 17);
            this.RTDAutoStart_check.TabIndex = 14;
            this.RTDAutoStart_check.Text = "Iniciar Automaticamente";
            this.RTDAutoStart_check.UseVisualStyleBackColor = true;
            // 
            // RTDPassword_mtb
            // 
            this.RTDPassword_mtb.Location = new System.Drawing.Point(140, 75);
            this.RTDPassword_mtb.Name = "RTDPassword_mtb";
            this.RTDPassword_mtb.PromptChar = '*';
            this.RTDPassword_mtb.Size = new System.Drawing.Size(211, 20);
            this.RTDPassword_mtb.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(93, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Senha:";
            // 
            // RTDUser_tb
            // 
            this.RTDUser_tb.Location = new System.Drawing.Point(140, 49);
            this.RTDUser_tb.Name = "RTDUser_tb";
            this.RTDUser_tb.Size = new System.Drawing.Size(211, 20);
            this.RTDUser_tb.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(88, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Usuário:";
            // 
            // RTDDefaultProvider_cb
            // 
            this.RTDDefaultProvider_cb.FormattingEnabled = true;
            this.RTDDefaultProvider_cb.Location = new System.Drawing.Point(140, 22);
            this.RTDDefaultProvider_cb.Name = "RTDDefaultProvider_cb";
            this.RTDDefaultProvider_cb.Size = new System.Drawing.Size(211, 21);
            this.RTDDefaultProvider_cb.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Provedor RTD Padrão:";
            // 
            // StrategyTab
            // 
            this.StrategyTab.Controls.Add(this.MainStartegyCheckList_treeView);
            this.StrategyTab.Controls.Add(this.StrategyDetails_gb);
            this.StrategyTab.Controls.Add(this.StrategyReload_bt);
            this.StrategyTab.Location = new System.Drawing.Point(4, 22);
            this.StrategyTab.Name = "StrategyTab";
            this.StrategyTab.Size = new System.Drawing.Size(801, 466);
            this.StrategyTab.TabIndex = 3;
            this.StrategyTab.Text = "Estratégias";
            this.StrategyTab.UseVisualStyleBackColor = true;
            // 
            // MainStartegyCheckList_treeView
            // 
            this.MainStartegyCheckList_treeView.CheckBoxes = true;
            this.MainStartegyCheckList_treeView.Location = new System.Drawing.Point(3, 8);
            this.MainStartegyCheckList_treeView.Name = "MainStartegyCheckList_treeView";
            this.MainStartegyCheckList_treeView.ShowLines = false;
            this.MainStartegyCheckList_treeView.ShowPlusMinus = false;
            this.MainStartegyCheckList_treeView.Size = new System.Drawing.Size(136, 389);
            this.MainStartegyCheckList_treeView.TabIndex = 4;
            this.MainStartegyCheckList_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.MainStartegyCheckList_treeView_AfterCheck);
            this.MainStartegyCheckList_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainStartegyCheckList_treeView_AfterSelect);
            // 
            // StrategyDetails_gb
            // 
            this.StrategyDetails_gb.Controls.Add(this.StrategyDetail_active_check);
            this.StrategyDetails_gb.Controls.Add(this.StrategyDetail_identifier_lb);
            this.StrategyDetails_gb.Controls.Add(this.label3);
            this.StrategyDetails_gb.Controls.Add(this.StrategyDetail_name_lb);
            this.StrategyDetails_gb.Controls.Add(this.label1);
            this.StrategyDetails_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrategyDetails_gb.Location = new System.Drawing.Point(145, 3);
            this.StrategyDetails_gb.Name = "StrategyDetails_gb";
            this.StrategyDetails_gb.Size = new System.Drawing.Size(655, 433);
            this.StrategyDetails_gb.TabIndex = 3;
            this.StrategyDetails_gb.TabStop = false;
            this.StrategyDetails_gb.Text = "Detalhes de estratégia.";
            // 
            // StrategyDetail_active_check
            // 
            this.StrategyDetail_active_check.AutoSize = true;
            this.StrategyDetail_active_check.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrategyDetail_active_check.Location = new System.Drawing.Point(9, 77);
            this.StrategyDetail_active_check.Name = "StrategyDetail_active_check";
            this.StrategyDetail_active_check.Size = new System.Drawing.Size(51, 19);
            this.StrategyDetail_active_check.TabIndex = 4;
            this.StrategyDetail_active_check.Text = "Ativa";
            this.StrategyDetail_active_check.UseVisualStyleBackColor = true;
            this.StrategyDetail_active_check.Click += new System.EventHandler(this.StrategyDetail_active_check_Click);
            // 
            // StrategyDetail_identifier_lb
            // 
            this.StrategyDetail_identifier_lb.AutoSize = true;
            this.StrategyDetail_identifier_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrategyDetail_identifier_lb.Location = new System.Drawing.Point(89, 47);
            this.StrategyDetail_identifier_lb.Name = "StrategyDetail_identifier_lb";
            this.StrategyDetail_identifier_lb.Size = new System.Drawing.Size(94, 16);
            this.StrategyDetail_identifier_lb.TabIndex = 3;
            this.StrategyDetail_identifier_lb.Text = "identificador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Identificador:";
            // 
            // StrategyDetail_name_lb
            // 
            this.StrategyDetail_name_lb.AutoSize = true;
            this.StrategyDetail_name_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrategyDetail_name_lb.Location = new System.Drawing.Point(56, 31);
            this.StrategyDetail_name_lb.Name = "StrategyDetail_name_lb";
            this.StrategyDetail_name_lb.Size = new System.Drawing.Size(46, 16);
            this.StrategyDetail_name_lb.TabIndex = 1;
            this.StrategyDetail_name_lb.Text = "nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // StrategyReload_bt
            // 
            this.StrategyReload_bt.Location = new System.Drawing.Point(3, 403);
            this.StrategyReload_bt.Name = "StrategyReload_bt";
            this.StrategyReload_bt.Size = new System.Drawing.Size(136, 23);
            this.StrategyReload_bt.TabIndex = 2;
            this.StrategyReload_bt.Text = "Recarregar estratégias";
            this.StrategyReload_bt.UseVisualStyleBackColor = true;
            this.StrategyReload_bt.Click += new System.EventHandler(this.StrategyReload_bt_Click);
            // 
            // BrokerTab
            // 
            this.BrokerTab.Location = new System.Drawing.Point(4, 22);
            this.BrokerTab.Name = "BrokerTab";
            this.BrokerTab.Size = new System.Drawing.Size(801, 466);
            this.BrokerTab.TabIndex = 5;
            this.BrokerTab.Text = "Corretoras";
            this.BrokerTab.UseVisualStyleBackColor = true;
            // 
            // FixedTaxTab
            // 
            this.FixedTaxTab.Location = new System.Drawing.Point(4, 22);
            this.FixedTaxTab.Name = "FixedTaxTab";
            this.FixedTaxTab.Size = new System.Drawing.Size(801, 466);
            this.FixedTaxTab.TabIndex = 4;
            this.FixedTaxTab.Text = "Taxas Fixas";
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.label10);
            this.ConfigTab.Controls.Add(this.dateTimePicker4);
            this.ConfigTab.Controls.Add(this.label9);
            this.ConfigTab.Controls.Add(this.dateTimePicker3);
            this.ConfigTab.Controls.Add(this.label8);
            this.ConfigTab.Controls.Add(this.dateTimePicker2);
            this.ConfigTab.Controls.Add(this.label7);
            this.ConfigTab.Controls.Add(this.dateTimePicker1);
            this.ConfigTab.Controls.Add(this.MainConfig_RTDDefaultUser_label);
            this.ConfigTab.Controls.Add(this.MainConfig_RTDDefaultUser_text);
            this.ConfigTab.Location = new System.Drawing.Point(4, 22);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigTab.Size = new System.Drawing.Size(801, 466);
            this.ConfigTab.TabIndex = 1;
            this.ConfigTab.Text = "Configuração";
            this.ConfigTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Horário de fim do after market:";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker4.Location = new System.Drawing.Point(174, 112);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker4.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Horário de início do after market:";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker3.Location = new System.Drawing.Point(174, 86);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Horário de fim do pregão:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(174, 60);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Horário de início do pregão:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // MainConfig_RTDDefaultUser_label
            // 
            this.MainConfig_RTDDefaultUser_label.AutoSize = true;
            this.MainConfig_RTDDefaultUser_label.Location = new System.Drawing.Point(6, 12);
            this.MainConfig_RTDDefaultUser_label.Name = "MainConfig_RTDDefaultUser_label";
            this.MainConfig_RTDDefaultUser_label.Size = new System.Drawing.Size(108, 13);
            this.MainConfig_RTDDefaultUser_label.TabIndex = 1;
            this.MainConfig_RTDDefaultUser_label.Text = "Usuário RTD padrão:";
            // 
            // MainConfig_RTDDefaultUser_text
            // 
            this.MainConfig_RTDDefaultUser_text.Location = new System.Drawing.Point(117, 9);
            this.MainConfig_RTDDefaultUser_text.Name = "MainConfig_RTDDefaultUser_text";
            this.MainConfig_RTDDefaultUser_text.Size = new System.Drawing.Size(100, 20);
            this.MainConfig_RTDDefaultUser_text.TabIndex = 0;
            this.MainConfig_RTDDefaultUser_text.TextChanged += new System.EventHandler(this.MainConfig_RTDDefaultUser_text_TextChanged);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStreamButtom,
            this.StreamStatus_lb,
            this.StrategyStatus_lb,
            this.toolStripSplitButton2});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 506);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(833, 22);
            this.MainStatusStrip.TabIndex = 3;
            this.MainStatusStrip.Text = "MainStatusStrip";
            // 
            // StatusStreamButtom
            // 
            this.StatusStreamButtom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusStreamButtom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ativarInicioAutomáticoToolStripMenuItem,
            this.iniciarStreamToolStripMenuItem});
            this.StatusStreamButtom.Image = ((System.Drawing.Image)(resources.GetObject("StatusStreamButtom.Image")));
            this.StatusStreamButtom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StatusStreamButtom.Name = "StatusStreamButtom";
            this.StatusStreamButtom.Size = new System.Drawing.Size(32, 20);
            this.StatusStreamButtom.Text = "toolStripSplitButton1";
            // 
            // ativarInicioAutomáticoToolStripMenuItem
            // 
            this.ativarInicioAutomáticoToolStripMenuItem.Name = "ativarInicioAutomáticoToolStripMenuItem";
            this.ativarInicioAutomáticoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ativarInicioAutomáticoToolStripMenuItem.Text = "Ativar Inicio Automático";
            // 
            // iniciarStreamToolStripMenuItem
            // 
            this.iniciarStreamToolStripMenuItem.Name = "iniciarStreamToolStripMenuItem";
            this.iniciarStreamToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.iniciarStreamToolStripMenuItem.Text = "Iniciar Stream";
            // 
            // StreamStatus_lb
            // 
            this.StreamStatus_lb.Name = "StreamStatus_lb";
            this.StreamStatus_lb.Size = new System.Drawing.Size(377, 17);
            this.StreamStatus_lb.Spring = true;
            this.StreamStatus_lb.Text = "Stream desconectado.";
            this.StreamStatus_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StrategyStatus_lb
            // 
            this.StrategyStatus_lb.Name = "StrategyStatus_lb";
            this.StrategyStatus_lb.Size = new System.Drawing.Size(377, 17);
            this.StrategyStatus_lb.Spring = true;
            this.StrategyStatus_lb.Text = "Estatégias não iniciadas.";
            this.StrategyStatus_lb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ativarInícioAutomáticoToolStripMenuItem,
            this.iniciarEstratégiasToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            // 
            // ativarInícioAutomáticoToolStripMenuItem
            // 
            this.ativarInícioAutomáticoToolStripMenuItem.Name = "ativarInícioAutomáticoToolStripMenuItem";
            this.ativarInícioAutomáticoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ativarInícioAutomáticoToolStripMenuItem.Text = "Ativar Início Automático";
            // 
            // iniciarEstratégiasToolStripMenuItem
            // 
            this.iniciarEstratégiasToolStripMenuItem.Name = "iniciarEstratégiasToolStripMenuItem";
            this.iniciarEstratégiasToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.iniciarEstratégiasToolStripMenuItem.Text = "Iniciar Estratégias";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 528);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.StockTab.ResumeLayout(false);
            this.MainStockDetail_gb.ResumeLayout(false);
            this.MainStockDetail_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainStockDetailLogo_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainStockDetail_historicalData_dg)).EndInit();
            this.DataTab.ResumeLayout(false);
            this.DataTab.PerformLayout();
            this.StrategyTab.ResumeLayout(false);
            this.StrategyDetails_gb.ResumeLayout(false);
            this.StrategyDetails_gb.PerformLayout();
            this.ConfigTab.ResumeLayout(false);
            this.ConfigTab.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ConfigTab;
        private System.Windows.Forms.TabPage StockTab;
        private System.Windows.Forms.Label MainConfig_RTDDefaultUser_label;
        private System.Windows.Forms.TextBox MainConfig_RTDDefaultUser_text;
        private System.Windows.Forms.ListBox MainStockTab_StockList_listbox;
        private System.Windows.Forms.TabPage StrategyTab;
        private System.Windows.Forms.Button StrategyReload_bt;
        private System.Windows.Forms.GroupBox StrategyDetails_gb;
        private System.Windows.Forms.Label StrategyDetail_identifier_lb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StrategyDetail_name_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox StrategyDetail_active_check;
        private System.Windows.Forms.TreeView MainStartegyCheckList_treeView;
        private System.Windows.Forms.GroupBox MainStockDetail_gb;
        private System.Windows.Forms.Label MainStockDetail_type_lb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label MainStockDetail_ticker_lb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label MainStockDetail_name_lb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView MainStockDetail_historicalData_dg;
        private System.Windows.Forms.PictureBox MainStockDetailLogo_pb;
        private System.Windows.Forms.TabPage FixedTaxTab;
        private System.Windows.Forms.TabPage BrokerTab;
        private System.Windows.Forms.TabPage OportunityTab;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripSplitButton StatusStreamButtom;
        private System.Windows.Forms.ToolStripMenuItem ativarInicioAutomáticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StreamStatus_lb;
        private System.Windows.Forms.ToolStripStatusLabel StrategyStatus_lb;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem ativarInícioAutomáticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarEstratégiasToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage DataTab;
        private System.Windows.Forms.Button RTDToggleStream_bt;
        private System.Windows.Forms.CheckBox RTDAutoStart_check;
        private System.Windows.Forms.MaskedTextBox RTDPassword_mtb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox RTDUser_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox RTDDefaultProvider_cb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox HDPassword_mtb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox HDUser_tb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox HDDefaultProvider_cb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TreeView HistoricalDataResolutions_lb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox HistoricalDataAutoUpdate_check;
        private System.Windows.Forms.Button button2;
    }
}