using Vlc.DotNet.Forms;

namespace VlcPlayerWinforms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            QueuePanel = new FlowLayoutPanel();
            ImageListQueue = new ImageList(components);
            vlcControl = new VlcControl();
            timerMouseMovement = new System.Windows.Forms.Timer(components);
            playPictureBox = new PictureBox();
            menuStrip1 = new MenuStrip();
            médiaToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnFichierToolStripMenuItem = new ToolStripMenuItem();
            ouvrirPlusieursFichiersToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnDossierToolStripMenuItem = new ToolStripMenuItem();
            lectureToolStripMenuItem = new ToolStripMenuItem();
            lireToolStripMenuItem = new ToolStripMenuItem();
            arrêterToolStripMenuItem = new ToolStripMenuItem();
            précedentToolStripMenuItem = new ToolStripMenuItem();
            suivantToolStripMenuItem = new ToolStripMenuItem();
            audioToolStripMenuItem = new ToolStripMenuItem();
            augmenterLeVolumeToolStripMenuItem = new ToolStripMenuItem();
            réduireLeVolumeToolStripMenuItem = new ToolStripMenuItem();
            couperLeSonToolStripMenuItem = new ToolStripMenuItem();
            vidéoToolStripMenuItem = new ToolStripMenuItem();
            pleinÉcranToolStripMenuItem = new ToolStripMenuItem();
            panelMediaControl = new Panel();
            labelTotalMediaTime = new Label();
            queuePictureBox = new PictureBox();
            stopPictureBox = new PictureBox();
            labelCurrentMediaTime = new Label();
            mediaProgressBar = new ProgressBar();
            updateMediaTime = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)vlcControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playPictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            panelMediaControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).BeginInit();
            SuspendLayout();
            // 
            // QueuePanel
            // 
            QueuePanel.BackColor = Color.Honeydew;
            QueuePanel.Dock = DockStyle.Right;
            QueuePanel.Location = new Point(575, 24);
            QueuePanel.Name = "QueuePanel";
            QueuePanel.Size = new Size(147, 442);
            QueuePanel.TabIndex = 5;
            // 
            // ImageListQueue
            // 
            ImageListQueue.ColorDepth = ColorDepth.Depth32Bit;
            ImageListQueue.ImageSize = new Size(16, 16);
            ImageListQueue.TransparentColor = Color.Transparent;
            // 
            // vlcControl
            // 
            vlcControl.BackColor = Color.Black;
            vlcControl.Dock = DockStyle.Fill;
            vlcControl.Location = new Point(0, 24);
            vlcControl.Name = "vlcControl";
            vlcControl.Size = new Size(575, 389);
            vlcControl.Spu = -1;
            vlcControl.TabIndex = 0;
            vlcControl.Text = "vlcControl";
            vlcControl.VlcMediaplayerOptions = null;
            vlcControl.Click += vlcControl_Click;
            vlcControl.DoubleClick += vlcControl1_DoubleClick;
            vlcControl.MouseEnter += vlcControl1_MouseEnter;
            vlcControl.MouseLeave += vlcControl1_MouseLeave;
            // 
            // timerMouseMovement
            // 
            timerMouseMovement.Interval = 1000;
            timerMouseMovement.Tick += timer1_Tick;
            // 
            // playPictureBox
            // 
            playPictureBox.BackColor = Color.DimGray;
            playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            playPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            playPictureBox.Location = new Point(3, 25);
            playPictureBox.Name = "playPictureBox";
            playPictureBox.Size = new Size(25, 25);
            playPictureBox.TabIndex = 9;
            playPictureBox.TabStop = false;
            playPictureBox.Click += playPictureBox_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { médiaToolStripMenuItem, lectureToolStripMenuItem, audioToolStripMenuItem, vidéoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(722, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // médiaToolStripMenuItem
            // 
            médiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnFichierToolStripMenuItem, ouvrirPlusieursFichiersToolStripMenuItem, ouvrirUnDossierToolStripMenuItem });
            médiaToolStripMenuItem.Name = "médiaToolStripMenuItem";
            médiaToolStripMenuItem.Size = new Size(52, 20);
            médiaToolStripMenuItem.Text = "Média";
            // 
            // ouvrirUnFichierToolStripMenuItem
            // 
            ouvrirUnFichierToolStripMenuItem.Name = "ouvrirUnFichierToolStripMenuItem";
            ouvrirUnFichierToolStripMenuItem.Size = new Size(207, 22);
            ouvrirUnFichierToolStripMenuItem.Text = "Ouvrir un fichier...";
            ouvrirUnFichierToolStripMenuItem.Click += ouvrirUnFichierToolStripMenuItem_Click;
            // 
            // ouvrirPlusieursFichiersToolStripMenuItem
            // 
            ouvrirPlusieursFichiersToolStripMenuItem.Name = "ouvrirPlusieursFichiersToolStripMenuItem";
            ouvrirPlusieursFichiersToolStripMenuItem.Size = new Size(207, 22);
            ouvrirPlusieursFichiersToolStripMenuItem.Text = "Ouvrir plusieurs fichiers...";
            // 
            // ouvrirUnDossierToolStripMenuItem
            // 
            ouvrirUnDossierToolStripMenuItem.Name = "ouvrirUnDossierToolStripMenuItem";
            ouvrirUnDossierToolStripMenuItem.Size = new Size(207, 22);
            ouvrirUnDossierToolStripMenuItem.Text = "Ouvrir un dossier...";
            // 
            // lectureToolStripMenuItem
            // 
            lectureToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lireToolStripMenuItem, arrêterToolStripMenuItem, précedentToolStripMenuItem, suivantToolStripMenuItem });
            lectureToolStripMenuItem.Name = "lectureToolStripMenuItem";
            lectureToolStripMenuItem.Size = new Size(58, 20);
            lectureToolStripMenuItem.Text = "Lecture";
            // 
            // lireToolStripMenuItem
            // 
            lireToolStripMenuItem.Name = "lireToolStripMenuItem";
            lireToolStripMenuItem.Size = new Size(127, 22);
            lireToolStripMenuItem.Text = "Lire";
            // 
            // arrêterToolStripMenuItem
            // 
            arrêterToolStripMenuItem.Name = "arrêterToolStripMenuItem";
            arrêterToolStripMenuItem.Size = new Size(127, 22);
            arrêterToolStripMenuItem.Text = "Arrêter";
            // 
            // précedentToolStripMenuItem
            // 
            précedentToolStripMenuItem.Name = "précedentToolStripMenuItem";
            précedentToolStripMenuItem.Size = new Size(127, 22);
            précedentToolStripMenuItem.Text = "Précedent";
            // 
            // suivantToolStripMenuItem
            // 
            suivantToolStripMenuItem.Name = "suivantToolStripMenuItem";
            suivantToolStripMenuItem.Size = new Size(127, 22);
            suivantToolStripMenuItem.Text = "Suivant";
            // 
            // audioToolStripMenuItem
            // 
            audioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { augmenterLeVolumeToolStripMenuItem, réduireLeVolumeToolStripMenuItem, couperLeSonToolStripMenuItem });
            audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            audioToolStripMenuItem.Size = new Size(51, 20);
            audioToolStripMenuItem.Text = "Audio";
            // 
            // augmenterLeVolumeToolStripMenuItem
            // 
            augmenterLeVolumeToolStripMenuItem.Name = "augmenterLeVolumeToolStripMenuItem";
            augmenterLeVolumeToolStripMenuItem.Size = new Size(189, 22);
            augmenterLeVolumeToolStripMenuItem.Text = "Augmenter le volume";
            // 
            // réduireLeVolumeToolStripMenuItem
            // 
            réduireLeVolumeToolStripMenuItem.Name = "réduireLeVolumeToolStripMenuItem";
            réduireLeVolumeToolStripMenuItem.Size = new Size(189, 22);
            réduireLeVolumeToolStripMenuItem.Text = "Réduire le volume";
            // 
            // couperLeSonToolStripMenuItem
            // 
            couperLeSonToolStripMenuItem.Name = "couperLeSonToolStripMenuItem";
            couperLeSonToolStripMenuItem.Size = new Size(189, 22);
            couperLeSonToolStripMenuItem.Text = "Couper le son";
            // 
            // vidéoToolStripMenuItem
            // 
            vidéoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pleinÉcranToolStripMenuItem });
            vidéoToolStripMenuItem.Name = "vidéoToolStripMenuItem";
            vidéoToolStripMenuItem.Size = new Size(49, 20);
            vidéoToolStripMenuItem.Text = "Vidéo";
            // 
            // pleinÉcranToolStripMenuItem
            // 
            pleinÉcranToolStripMenuItem.Name = "pleinÉcranToolStripMenuItem";
            pleinÉcranToolStripMenuItem.Size = new Size(132, 22);
            pleinÉcranToolStripMenuItem.Text = "Plein écran";
            // 
            // panelMediaControl
            // 
            panelMediaControl.BackColor = Color.DimGray;
            panelMediaControl.Controls.Add(labelTotalMediaTime);
            panelMediaControl.Controls.Add(queuePictureBox);
            panelMediaControl.Controls.Add(stopPictureBox);
            panelMediaControl.Controls.Add(labelCurrentMediaTime);
            panelMediaControl.Controls.Add(playPictureBox);
            panelMediaControl.Controls.Add(mediaProgressBar);
            panelMediaControl.Dock = DockStyle.Bottom;
            panelMediaControl.Location = new Point(0, 413);
            panelMediaControl.Name = "panelMediaControl";
            panelMediaControl.Size = new Size(575, 53);
            panelMediaControl.TabIndex = 11;
            // 
            // labelTotalMediaTime
            // 
            labelTotalMediaTime.AutoSize = true;
            labelTotalMediaTime.BackColor = Color.White;
            labelTotalMediaTime.Location = new Point(520, 6);
            labelTotalMediaTime.Name = "labelTotalMediaTime";
            labelTotalMediaTime.Size = new Size(49, 15);
            labelTotalMediaTime.TabIndex = 11;
            labelTotalMediaTime.Text = "00:00:00";
            // 
            // queuePictureBox
            // 
            queuePictureBox.BackgroundImage = Properties.Resources.list_50px;
            queuePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            queuePictureBox.Location = new Point(65, 25);
            queuePictureBox.Name = "queuePictureBox";
            queuePictureBox.Size = new Size(25, 25);
            queuePictureBox.TabIndex = 14;
            queuePictureBox.TabStop = false;
            queuePictureBox.Click += queuePictureBox_Click;
            // 
            // stopPictureBox
            // 
            stopPictureBox.BackgroundImage = Properties.Resources.stop_50px;
            stopPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            stopPictureBox.Location = new Point(34, 25);
            stopPictureBox.Name = "stopPictureBox";
            stopPictureBox.Size = new Size(25, 25);
            stopPictureBox.TabIndex = 13;
            stopPictureBox.TabStop = false;
            stopPictureBox.Click += stopPictureBox_Click;
            // 
            // labelCurrentMediaTime
            // 
            labelCurrentMediaTime.AutoSize = true;
            labelCurrentMediaTime.BackColor = Color.White;
            labelCurrentMediaTime.Location = new Point(3, 6);
            labelCurrentMediaTime.Name = "labelCurrentMediaTime";
            labelCurrentMediaTime.Size = new Size(49, 15);
            labelCurrentMediaTime.TabIndex = 12;
            labelCurrentMediaTime.Text = "00:00:00";
            // 
            // mediaProgressBar
            // 
            mediaProgressBar.Location = new Point(58, 3);
            mediaProgressBar.Name = "mediaProgressBar";
            mediaProgressBar.Size = new Size(456, 18);
            mediaProgressBar.TabIndex = 10;
            // 
            // updateMediaTime
            // 
            updateMediaTime.Enabled = true;
            updateMediaTime.Tick += updateMediaTime_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(722, 466);
            Controls.Add(vlcControl);
            Controls.Add(panelMediaControl);
            Controls.Add(QueuePanel);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MediaPlayer";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            Resize += MainForm_Resize;
            vlcControl.VlcLibDirectory = new DirectoryInfo("C:\\Program Files\\VideoLAN\\VLC");
            ((System.ComponentModel.ISupportInitialize)vlcControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)playPictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMediaControl.ResumeLayout(false);
            panelMediaControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel QueuePanel;
        private ImageList ImageListQueue;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.Timer timerMouseMovement;
        private PictureBox playPictureBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem médiaToolStripMenuItem;
        private ToolStripMenuItem lectureToolStripMenuItem;
        private ToolStripMenuItem audioToolStripMenuItem;
        private ToolStripMenuItem vidéoToolStripMenuItem;
        private Panel panelMediaControl;
        private ProgressBar mediaProgressBar;
        private Label labelCurrentMediaTime;
        private Label labelTotalMediaTime;
        private System.Windows.Forms.Timer updateMediaTime;
        private ToolStripMenuItem ouvrirUnFichierToolStripMenuItem;
        private ToolStripMenuItem ouvrirPlusieursFichiersToolStripMenuItem;
        private ToolStripMenuItem ouvrirUnDossierToolStripMenuItem;
        private ToolStripMenuItem lireToolStripMenuItem;
        private ToolStripMenuItem arrêterToolStripMenuItem;
        private ToolStripMenuItem précedentToolStripMenuItem;
        private ToolStripMenuItem suivantToolStripMenuItem;
        private ToolStripMenuItem augmenterLeVolumeToolStripMenuItem;
        private ToolStripMenuItem réduireLeVolumeToolStripMenuItem;
        private ToolStripMenuItem couperLeSonToolStripMenuItem;
        private ToolStripMenuItem pleinÉcranToolStripMenuItem;
        private PictureBox stopPictureBox;
        private PictureBox queuePictureBox;
    }
}
