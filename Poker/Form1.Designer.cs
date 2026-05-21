namespace Poker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblDeckRemain = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.grpBoard = new System.Windows.Forms.GroupBox();
            this.tblBoard = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCell0 = new System.Windows.Forms.Panel();
            this.lblCell0 = new System.Windows.Forms.Label();
            this.picCell0 = new System.Windows.Forms.PictureBox();
            this.pnlCell1 = new System.Windows.Forms.Panel();
            this.lblCell1 = new System.Windows.Forms.Label();
            this.picCell1 = new System.Windows.Forms.PictureBox();
            this.pnlCell2 = new System.Windows.Forms.Panel();
            this.lblCell2 = new System.Windows.Forms.Label();
            this.picCell2 = new System.Windows.Forms.PictureBox();
            this.pnlCell3 = new System.Windows.Forms.Panel();
            this.lblCell3 = new System.Windows.Forms.Label();
            this.picCell3 = new System.Windows.Forms.PictureBox();
            this.pnlCell4 = new System.Windows.Forms.Panel();
            this.lblCell4 = new System.Windows.Forms.Label();
            this.picCell4 = new System.Windows.Forms.PictureBox();
            this.pnlCell5 = new System.Windows.Forms.Panel();
            this.lblCell5 = new System.Windows.Forms.Label();
            this.picCell5 = new System.Windows.Forms.PictureBox();
            this.pnlCell6 = new System.Windows.Forms.Panel();
            this.lblCell6 = new System.Windows.Forms.Label();
            this.picCell6 = new System.Windows.Forms.PictureBox();
            this.pnlCell7 = new System.Windows.Forms.Panel();
            this.lblCell7 = new System.Windows.Forms.Label();
            this.picCell7 = new System.Windows.Forms.PictureBox();
            this.pnlCell8 = new System.Windows.Forms.Panel();
            this.lblCell8 = new System.Windows.Forms.Label();
            this.picCell8 = new System.Windows.Forms.PictureBox();
            this.grpDeck = new System.Windows.Forms.GroupBox();
            this.lblDeckCount = new System.Windows.Forms.Label();
            this.lblDeckTitle = new System.Windows.Forms.Label();
            this.picDeck = new System.Windows.Forms.PictureBox();
            this.grpPlayerHand = new System.Windows.Forms.GroupBox();
            this.lblPlayerHandInfo = new System.Windows.Forms.Label();
            this.flpPlayerHand = new System.Windows.Forms.FlowLayoutPanel();
            this.picPlayer0 = new System.Windows.Forms.PictureBox();
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.picPlayer2 = new System.Windows.Forms.PictureBox();
            this.grpAIHand = new System.Windows.Forms.GroupBox();
            this.lblAIHandInfo = new System.Windows.Forms.Label();
            this.flpAIHand = new System.Windows.Forms.FlowLayoutPanel();
            this.picAI0 = new System.Windows.Forms.PictureBox();
            this.picAI1 = new System.Windows.Forms.PictureBox();
            this.picAI2 = new System.Windows.Forms.PictureBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnDrawCard = new System.Windows.Forms.Button();
            this.grpStatus.SuspendLayout();
            this.grpBoard.SuspendLayout();
            this.tblBoard.SuspendLayout();
            this.pnlCell0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell0)).BeginInit();
            this.pnlCell1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell1)).BeginInit();
            this.pnlCell2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell2)).BeginInit();
            this.pnlCell3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell3)).BeginInit();
            this.pnlCell4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell4)).BeginInit();
            this.pnlCell5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell5)).BeginInit();
            this.pnlCell6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell6)).BeginInit();
            this.pnlCell7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell7)).BeginInit();
            this.pnlCell8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCell8)).BeginInit();
            this.grpDeck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDeck)).BeginInit();
            this.grpPlayerHand.SuspendLayout();
            this.flpPlayerHand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).BeginInit();
            this.grpAIHand.SuspendLayout();
            this.flpAIHand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAI0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAI2)).BeginInit();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblMessage);
            this.grpStatus.Controls.Add(this.lblDeckRemain);
            this.grpStatus.Controls.Add(this.lblTurn);
            this.grpStatus.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpStatus.Location = new System.Drawing.Point(12, 12);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(936, 64);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "狀態";
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Location = new System.Drawing.Point(320, 26);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(600, 28);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeckRemain
            // 
            this.lblDeckRemain.AutoSize = true;
            this.lblDeckRemain.Location = new System.Drawing.Point(150, 30);
            this.lblDeckRemain.Name = "lblDeckRemain";
            this.lblDeckRemain.Size = new System.Drawing.Size(132, 28);
            this.lblDeckRemain.TabIndex = 1;
            this.lblDeckRemain.Text = "牌庫：11 張";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Location = new System.Drawing.Point(16, 30);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(122, 28);
            this.lblTurn.TabIndex = 0;
            this.lblTurn.Text = "回合：玩家";
            // 
            // grpBoard
            // 
            this.grpBoard.Controls.Add(this.tblBoard);
            this.grpBoard.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpBoard.Location = new System.Drawing.Point(12, 82);
            this.grpBoard.Name = "grpBoard";
            this.grpBoard.Size = new System.Drawing.Size(420, 420);
            this.grpBoard.TabIndex = 1;
            this.grpBoard.TabStop = false;
            this.grpBoard.Text = "棋盤 (3×3)";
            // 
            // tblBoard
            // 
            this.tblBoard.ColumnCount = 3;
            this.tblBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblBoard.Controls.Add(this.pnlCell0, 0, 0);
            this.tblBoard.Controls.Add(this.pnlCell1, 1, 0);
            this.tblBoard.Controls.Add(this.pnlCell2, 2, 0);
            this.tblBoard.Controls.Add(this.pnlCell3, 0, 1);
            this.tblBoard.Controls.Add(this.pnlCell4, 1, 1);
            this.tblBoard.Controls.Add(this.pnlCell5, 2, 1);
            this.tblBoard.Controls.Add(this.pnlCell6, 0, 2);
            this.tblBoard.Controls.Add(this.pnlCell7, 1, 2);
            this.tblBoard.Controls.Add(this.pnlCell8, 2, 2);
            this.tblBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBoard.Location = new System.Drawing.Point(3, 33);
            this.tblBoard.Name = "tblBoard";
            this.tblBoard.RowCount = 3;
            this.tblBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblBoard.Size = new System.Drawing.Size(414, 384);
            this.tblBoard.TabIndex = 0;
            // 
            // pnlCell0
            // 
            this.pnlCell0.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell0.Controls.Add(this.lblCell0);
            this.pnlCell0.Controls.Add(this.picCell0);
            this.pnlCell0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell0.Location = new System.Drawing.Point(3, 3);
            this.pnlCell0.Name = "pnlCell0";
            this.pnlCell0.Size = new System.Drawing.Size(131, 121);
            this.pnlCell0.TabIndex = 0;
            // 
            // lblCell0
            // 
            this.lblCell0.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell0.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell0.Location = new System.Drawing.Point(0, 93);
            this.lblCell0.Name = "lblCell0";
            this.lblCell0.Size = new System.Drawing.Size(129, 26);
            this.lblCell0.TabIndex = 1;
            this.lblCell0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell0
            // 
            this.picCell0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell0.Image = global::Poker.Properties.Resources.back;
            this.picCell0.Location = new System.Drawing.Point(0, 0);
            this.picCell0.Name = "picCell0";
            this.picCell0.Size = new System.Drawing.Size(129, 119);
            this.picCell0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell0.TabIndex = 0;
            this.picCell0.TabStop = false;
            // 
            // pnlCell1
            // 
            this.pnlCell1.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell1.Controls.Add(this.lblCell1);
            this.pnlCell1.Controls.Add(this.picCell1);
            this.pnlCell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell1.Location = new System.Drawing.Point(140, 3);
            this.pnlCell1.Name = "pnlCell1";
            this.pnlCell1.Size = new System.Drawing.Size(132, 121);
            this.pnlCell1.TabIndex = 1;
            // 
            // lblCell1
            // 
            this.lblCell1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell1.Location = new System.Drawing.Point(0, 93);
            this.lblCell1.Name = "lblCell1";
            this.lblCell1.Size = new System.Drawing.Size(130, 26);
            this.lblCell1.TabIndex = 1;
            this.lblCell1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell1
            // 
            this.picCell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell1.Image = global::Poker.Properties.Resources.back;
            this.picCell1.Location = new System.Drawing.Point(0, 0);
            this.picCell1.Name = "picCell1";
            this.picCell1.Size = new System.Drawing.Size(130, 119);
            this.picCell1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell1.TabIndex = 0;
            this.picCell1.TabStop = false;
            // 
            // pnlCell2
            // 
            this.pnlCell2.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell2.Controls.Add(this.lblCell2);
            this.pnlCell2.Controls.Add(this.picCell2);
            this.pnlCell2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell2.Location = new System.Drawing.Point(278, 3);
            this.pnlCell2.Name = "pnlCell2";
            this.pnlCell2.Size = new System.Drawing.Size(133, 121);
            this.pnlCell2.TabIndex = 2;
            // 
            // lblCell2
            // 
            this.lblCell2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell2.Location = new System.Drawing.Point(0, 93);
            this.lblCell2.Name = "lblCell2";
            this.lblCell2.Size = new System.Drawing.Size(131, 26);
            this.lblCell2.TabIndex = 1;
            this.lblCell2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell2
            // 
            this.picCell2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell2.Image = global::Poker.Properties.Resources.back;
            this.picCell2.Location = new System.Drawing.Point(0, 0);
            this.picCell2.Name = "picCell2";
            this.picCell2.Size = new System.Drawing.Size(131, 119);
            this.picCell2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell2.TabIndex = 0;
            this.picCell2.TabStop = false;
            // 
            // pnlCell3
            // 
            this.pnlCell3.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell3.Controls.Add(this.lblCell3);
            this.pnlCell3.Controls.Add(this.picCell3);
            this.pnlCell3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell3.Location = new System.Drawing.Point(3, 130);
            this.pnlCell3.Name = "pnlCell3";
            this.pnlCell3.Size = new System.Drawing.Size(131, 122);
            this.pnlCell3.TabIndex = 3;
            // 
            // lblCell3
            // 
            this.lblCell3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell3.Location = new System.Drawing.Point(0, 94);
            this.lblCell3.Name = "lblCell3";
            this.lblCell3.Size = new System.Drawing.Size(129, 26);
            this.lblCell3.TabIndex = 1;
            this.lblCell3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell3
            // 
            this.picCell3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell3.Image = global::Poker.Properties.Resources.back;
            this.picCell3.Location = new System.Drawing.Point(0, 0);
            this.picCell3.Name = "picCell3";
            this.picCell3.Size = new System.Drawing.Size(129, 120);
            this.picCell3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell3.TabIndex = 0;
            this.picCell3.TabStop = false;
            // 
            // pnlCell4
            // 
            this.pnlCell4.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell4.Controls.Add(this.lblCell4);
            this.pnlCell4.Controls.Add(this.picCell4);
            this.pnlCell4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell4.Location = new System.Drawing.Point(140, 130);
            this.pnlCell4.Name = "pnlCell4";
            this.pnlCell4.Size = new System.Drawing.Size(132, 122);
            this.pnlCell4.TabIndex = 4;
            // 
            // lblCell4
            // 
            this.lblCell4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell4.Location = new System.Drawing.Point(0, 94);
            this.lblCell4.Name = "lblCell4";
            this.lblCell4.Size = new System.Drawing.Size(130, 26);
            this.lblCell4.TabIndex = 1;
            this.lblCell4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell4
            // 
            this.picCell4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell4.Image = global::Poker.Properties.Resources.back;
            this.picCell4.Location = new System.Drawing.Point(0, 0);
            this.picCell4.Name = "picCell4";
            this.picCell4.Size = new System.Drawing.Size(130, 120);
            this.picCell4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell4.TabIndex = 0;
            this.picCell4.TabStop = false;
            // 
            // pnlCell5
            // 
            this.pnlCell5.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell5.Controls.Add(this.lblCell5);
            this.pnlCell5.Controls.Add(this.picCell5);
            this.pnlCell5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell5.Location = new System.Drawing.Point(278, 130);
            this.pnlCell5.Name = "pnlCell5";
            this.pnlCell5.Size = new System.Drawing.Size(133, 122);
            this.pnlCell5.TabIndex = 5;
            // 
            // lblCell5
            // 
            this.lblCell5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell5.Location = new System.Drawing.Point(0, 94);
            this.lblCell5.Name = "lblCell5";
            this.lblCell5.Size = new System.Drawing.Size(131, 26);
            this.lblCell5.TabIndex = 1;
            this.lblCell5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell5
            // 
            this.picCell5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell5.Image = global::Poker.Properties.Resources.back;
            this.picCell5.Location = new System.Drawing.Point(0, 0);
            this.picCell5.Name = "picCell5";
            this.picCell5.Size = new System.Drawing.Size(131, 120);
            this.picCell5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell5.TabIndex = 0;
            this.picCell5.TabStop = false;
            // 
            // pnlCell6
            // 
            this.pnlCell6.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell6.Controls.Add(this.lblCell6);
            this.pnlCell6.Controls.Add(this.picCell6);
            this.pnlCell6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell6.Location = new System.Drawing.Point(3, 258);
            this.pnlCell6.Name = "pnlCell6";
            this.pnlCell6.Size = new System.Drawing.Size(131, 123);
            this.pnlCell6.TabIndex = 6;
            // 
            // lblCell6
            // 
            this.lblCell6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell6.Location = new System.Drawing.Point(0, 95);
            this.lblCell6.Name = "lblCell6";
            this.lblCell6.Size = new System.Drawing.Size(129, 26);
            this.lblCell6.TabIndex = 1;
            this.lblCell6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell6
            // 
            this.picCell6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell6.Image = global::Poker.Properties.Resources.back;
            this.picCell6.Location = new System.Drawing.Point(0, 0);
            this.picCell6.Name = "picCell6";
            this.picCell6.Size = new System.Drawing.Size(129, 121);
            this.picCell6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell6.TabIndex = 0;
            this.picCell6.TabStop = false;
            // 
            // pnlCell7
            // 
            this.pnlCell7.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell7.Controls.Add(this.lblCell7);
            this.pnlCell7.Controls.Add(this.picCell7);
            this.pnlCell7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell7.Location = new System.Drawing.Point(140, 258);
            this.pnlCell7.Name = "pnlCell7";
            this.pnlCell7.Size = new System.Drawing.Size(132, 123);
            this.pnlCell7.TabIndex = 7;
            // 
            // lblCell7
            // 
            this.lblCell7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell7.Location = new System.Drawing.Point(0, 95);
            this.lblCell7.Name = "lblCell7";
            this.lblCell7.Size = new System.Drawing.Size(130, 26);
            this.lblCell7.TabIndex = 1;
            this.lblCell7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell7
            // 
            this.picCell7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell7.Image = global::Poker.Properties.Resources.back;
            this.picCell7.Location = new System.Drawing.Point(0, 0);
            this.picCell7.Name = "picCell7";
            this.picCell7.Size = new System.Drawing.Size(130, 121);
            this.picCell7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell7.TabIndex = 0;
            this.picCell7.TabStop = false;
            // 
            // pnlCell8
            // 
            this.pnlCell8.BackColor = System.Drawing.Color.LightGray;
            this.pnlCell8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCell8.Controls.Add(this.lblCell8);
            this.pnlCell8.Controls.Add(this.picCell8);
            this.pnlCell8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCell8.Location = new System.Drawing.Point(278, 258);
            this.pnlCell8.Name = "pnlCell8";
            this.pnlCell8.Size = new System.Drawing.Size(133, 123);
            this.pnlCell8.TabIndex = 8;
            // 
            // lblCell8
            // 
            this.lblCell8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCell8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.lblCell8.Location = new System.Drawing.Point(0, 95);
            this.lblCell8.Name = "lblCell8";
            this.lblCell8.Size = new System.Drawing.Size(131, 26);
            this.lblCell8.TabIndex = 1;
            this.lblCell8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCell8
            // 
            this.picCell8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCell8.Image = global::Poker.Properties.Resources.back;
            this.picCell8.Location = new System.Drawing.Point(0, 0);
            this.picCell8.Name = "picCell8";
            this.picCell8.Size = new System.Drawing.Size(131, 121);
            this.picCell8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCell8.TabIndex = 0;
            this.picCell8.TabStop = false;
            // 
            // grpDeck
            // 
            this.grpDeck.Controls.Add(this.lblDeckCount);
            this.grpDeck.Controls.Add(this.lblDeckTitle);
            this.grpDeck.Controls.Add(this.picDeck);
            this.grpDeck.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpDeck.Location = new System.Drawing.Point(450, 82);
            this.grpDeck.Name = "grpDeck";
            this.grpDeck.Size = new System.Drawing.Size(220, 160);
            this.grpDeck.TabIndex = 2;
            this.grpDeck.TabStop = false;
            this.grpDeck.Text = "共用牌庫";
            // 
            // lblDeckCount
            // 
            this.lblDeckCount.AutoSize = true;
            this.lblDeckCount.Location = new System.Drawing.Point(16, 128);
            this.lblDeckCount.Name = "lblDeckCount";
            this.lblDeckCount.Size = new System.Drawing.Size(104, 28);
            this.lblDeckCount.TabIndex = 2;
            this.lblDeckCount.Text = "剩餘：11";
            // 
            // lblDeckTitle
            // 
            this.lblDeckTitle.AutoSize = true;
            this.lblDeckTitle.Location = new System.Drawing.Point(16, 28);
            this.lblDeckTitle.Name = "lblDeckTitle";
            this.lblDeckTitle.Size = new System.Drawing.Size(100, 28);
            this.lblDeckTitle.TabIndex = 1;
            this.lblDeckTitle.Text = "牌庫牌堆";
            // 
            // picDeck
            // 
            this.picDeck.Image = global::Poker.Properties.Resources.back;
            this.picDeck.Location = new System.Drawing.Point(110, 24);
            this.picDeck.Name = "picDeck";
            this.picDeck.Size = new System.Drawing.Size(90, 120);
            this.picDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeck.TabIndex = 0;
            this.picDeck.TabStop = false;
            // 
            // grpPlayerHand
            // 
            this.grpPlayerHand.Controls.Add(this.lblPlayerHandInfo);
            this.grpPlayerHand.Controls.Add(this.flpPlayerHand);
            this.grpPlayerHand.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpPlayerHand.Location = new System.Drawing.Point(450, 252);
            this.grpPlayerHand.Name = "grpPlayerHand";
            this.grpPlayerHand.Size = new System.Drawing.Size(498, 120);
            this.grpPlayerHand.TabIndex = 3;
            this.grpPlayerHand.TabStop = false;
            this.grpPlayerHand.Text = "玩家手牌";
            // 
            // lblPlayerHandInfo
            // 
            this.lblPlayerHandInfo.AutoSize = true;
            this.lblPlayerHandInfo.Location = new System.Drawing.Point(16, 28);
            this.lblPlayerHandInfo.Name = "lblPlayerHandInfo";
            this.lblPlayerHandInfo.Size = new System.Drawing.Size(125, 28);
            this.lblPlayerHandInfo.TabIndex = 1;
            this.lblPlayerHandInfo.Text = "手牌：0 / 3";
            // 
            // flpPlayerHand
            // 
            this.flpPlayerHand.Controls.Add(this.picPlayer0);
            this.flpPlayerHand.Controls.Add(this.picPlayer1);
            this.flpPlayerHand.Controls.Add(this.picPlayer2);
            this.flpPlayerHand.Location = new System.Drawing.Point(140, 22);
            this.flpPlayerHand.Name = "flpPlayerHand";
            this.flpPlayerHand.Size = new System.Drawing.Size(340, 88);
            this.flpPlayerHand.TabIndex = 0;
            // 
            // picPlayer0
            // 
            this.picPlayer0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer0.Image = global::Poker.Properties.Resources.back;
            this.picPlayer0.Location = new System.Drawing.Point(3, 3);
            this.picPlayer0.Name = "picPlayer0";
            this.picPlayer0.Size = new System.Drawing.Size(70, 82);
            this.picPlayer0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer0.TabIndex = 0;
            this.picPlayer0.TabStop = false;
            this.picPlayer0.Tag = "0";
            // 
            // picPlayer1
            // 
            this.picPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer1.Image = global::Poker.Properties.Resources.back;
            this.picPlayer1.Location = new System.Drawing.Point(79, 3);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(70, 82);
            this.picPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer1.TabIndex = 1;
            this.picPlayer1.TabStop = false;
            this.picPlayer1.Tag = "1";
            // 
            // picPlayer2
            // 
            this.picPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer2.Image = global::Poker.Properties.Resources.back;
            this.picPlayer2.Location = new System.Drawing.Point(155, 3);
            this.picPlayer2.Name = "picPlayer2";
            this.picPlayer2.Size = new System.Drawing.Size(70, 82);
            this.picPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer2.TabIndex = 2;
            this.picPlayer2.TabStop = false;
            this.picPlayer2.Tag = "2";
            // 
            // grpAIHand
            // 
            this.grpAIHand.Controls.Add(this.lblAIHandInfo);
            this.grpAIHand.Controls.Add(this.flpAIHand);
            this.grpAIHand.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpAIHand.Location = new System.Drawing.Point(450, 382);
            this.grpAIHand.Name = "grpAIHand";
            this.grpAIHand.Size = new System.Drawing.Size(498, 120);
            this.grpAIHand.TabIndex = 4;
            this.grpAIHand.TabStop = false;
            this.grpAIHand.Text = "AI 手牌";
            // 
            // lblAIHandInfo
            // 
            this.lblAIHandInfo.AutoSize = true;
            this.lblAIHandInfo.Location = new System.Drawing.Point(16, 28);
            this.lblAIHandInfo.Name = "lblAIHandInfo";
            this.lblAIHandInfo.Size = new System.Drawing.Size(146, 28);
            this.lblAIHandInfo.TabIndex = 1;
            this.lblAIHandInfo.Text = "AI 手牌：0 張";
            // 
            // flpAIHand
            // 
            this.flpAIHand.Controls.Add(this.picAI0);
            this.flpAIHand.Controls.Add(this.picAI1);
            this.flpAIHand.Controls.Add(this.picAI2);
            this.flpAIHand.Location = new System.Drawing.Point(140, 22);
            this.flpAIHand.Name = "flpAIHand";
            this.flpAIHand.Size = new System.Drawing.Size(340, 88);
            this.flpAIHand.TabIndex = 0;
            // 
            // picAI0
            // 
            this.picAI0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAI0.Image = global::Poker.Properties.Resources.back;
            this.picAI0.Location = new System.Drawing.Point(3, 3);
            this.picAI0.Name = "picAI0";
            this.picAI0.Size = new System.Drawing.Size(70, 82);
            this.picAI0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAI0.TabIndex = 0;
            this.picAI0.TabStop = false;
            this.picAI0.Tag = "0";
            // 
            // picAI1
            // 
            this.picAI1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAI1.Image = global::Poker.Properties.Resources.back;
            this.picAI1.Location = new System.Drawing.Point(79, 3);
            this.picAI1.Name = "picAI1";
            this.picAI1.Size = new System.Drawing.Size(70, 82);
            this.picAI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAI1.TabIndex = 1;
            this.picAI1.TabStop = false;
            this.picAI1.Tag = "1";
            // 
            // picAI2
            // 
            this.picAI2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAI2.Image = global::Poker.Properties.Resources.back;
            this.picAI2.Location = new System.Drawing.Point(155, 3);
            this.picAI2.Name = "picAI2";
            this.picAI2.Size = new System.Drawing.Size(70, 82);
            this.picAI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAI2.TabIndex = 2;
            this.picAI2.TabStop = false;
            this.picAI2.Tag = "2";
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnRestart);
            this.grpActions.Controls.Add(this.btnDrawCard);
            this.grpActions.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.grpActions.Location = new System.Drawing.Point(12, 512);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(936, 72);
            this.grpActions.TabIndex = 5;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "操作";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(150, 28);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(120, 36);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnDrawCard
            // 
            this.btnDrawCard.Location = new System.Drawing.Point(16, 28);
            this.btnDrawCard.Name = "btnDrawCard";
            this.btnDrawCard.Size = new System.Drawing.Size(120, 36);
            this.btnDrawCard.TabIndex = 0;
            this.btnDrawCard.Text = "抽牌";
            this.btnDrawCard.UseVisualStyleBackColor = true;
            this.btnDrawCard.Click += new System.EventHandler(this.btnDrawCard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpAIHand);
            this.Controls.Add(this.grpPlayerHand);
            this.Controls.Add(this.grpDeck);
            this.Controls.Add(this.grpBoard);
            this.Controls.Add(this.grpStatus);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "卡牌井字連線對戰";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpBoard.ResumeLayout(false);
            this.tblBoard.ResumeLayout(false);
            this.pnlCell0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell0)).EndInit();
            this.pnlCell1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell1)).EndInit();
            this.pnlCell2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell2)).EndInit();
            this.pnlCell3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell3)).EndInit();
            this.pnlCell4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell4)).EndInit();
            this.pnlCell5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell5)).EndInit();
            this.pnlCell6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell6)).EndInit();
            this.pnlCell7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell7)).EndInit();
            this.pnlCell8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCell8)).EndInit();
            this.grpDeck.ResumeLayout(false);
            this.grpDeck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDeck)).EndInit();
            this.grpPlayerHand.ResumeLayout(false);
            this.grpPlayerHand.PerformLayout();
            this.flpPlayerHand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).EndInit();
            this.grpAIHand.ResumeLayout(false);
            this.grpAIHand.PerformLayout();
            this.flpAIHand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAI0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAI2)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblDeckRemain;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.GroupBox grpBoard;
        private System.Windows.Forms.TableLayoutPanel tblBoard;
        private System.Windows.Forms.Panel pnlCell0;
        private System.Windows.Forms.PictureBox picCell0;
        private System.Windows.Forms.Label lblCell0;
        private System.Windows.Forms.Panel pnlCell1;
        private System.Windows.Forms.PictureBox picCell1;
        private System.Windows.Forms.Label lblCell1;
        private System.Windows.Forms.Panel pnlCell2;
        private System.Windows.Forms.PictureBox picCell2;
        private System.Windows.Forms.Label lblCell2;
        private System.Windows.Forms.Panel pnlCell3;
        private System.Windows.Forms.PictureBox picCell3;
        private System.Windows.Forms.Label lblCell3;
        private System.Windows.Forms.Panel pnlCell4;
        private System.Windows.Forms.PictureBox picCell4;
        private System.Windows.Forms.Label lblCell4;
        private System.Windows.Forms.Panel pnlCell5;
        private System.Windows.Forms.PictureBox picCell5;
        private System.Windows.Forms.Label lblCell5;
        private System.Windows.Forms.Panel pnlCell6;
        private System.Windows.Forms.PictureBox picCell6;
        private System.Windows.Forms.Label lblCell6;
        private System.Windows.Forms.Panel pnlCell7;
        private System.Windows.Forms.PictureBox picCell7;
        private System.Windows.Forms.Label lblCell7;
        private System.Windows.Forms.Panel pnlCell8;
        private System.Windows.Forms.PictureBox picCell8;
        private System.Windows.Forms.Label lblCell8;
        private System.Windows.Forms.GroupBox grpDeck;
        private System.Windows.Forms.PictureBox picDeck;
        private System.Windows.Forms.Label lblDeckTitle;
        private System.Windows.Forms.Label lblDeckCount;
        private System.Windows.Forms.GroupBox grpPlayerHand;
        private System.Windows.Forms.FlowLayoutPanel flpPlayerHand;
        private System.Windows.Forms.PictureBox picPlayer0;
        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.PictureBox picPlayer2;
        private System.Windows.Forms.Label lblPlayerHandInfo;
        private System.Windows.Forms.GroupBox grpAIHand;
        private System.Windows.Forms.FlowLayoutPanel flpAIHand;
        private System.Windows.Forms.PictureBox picAI0;
        private System.Windows.Forms.PictureBox picAI1;
        private System.Windows.Forms.PictureBox picAI2;
        private System.Windows.Forms.Label lblAIHandInfo;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnDrawCard;
        private System.Windows.Forms.Button btnRestart;
    }
}
