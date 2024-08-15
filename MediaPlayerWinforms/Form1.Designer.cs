using Vlc.DotNet.Forms;

namespace MediaPlayerWinforms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            QueuePanel = new FlowLayoutPanel();
            ImageListQueue = new ImageList(components);
            timerMouseMovement = new System.Windows.Forms.Timer(components);
            playPictureBox = new PictureBox();
            menuStrip = new MenuStrip();
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
            labelTest = new Label();
            mediaPlayerSlider = new CustomControls.CustomSlider();
            queuePictureBox = new PictureBox();
            stopPictureBox = new PictureBox();
            timeWithProgressBar = new Panel();
            labelTotalMediaTime = new Label();
            labelCurrentMediaTime = new Label();
            mediaCustomProgressBar = new CustomControls.CustomProgressBar();
            updateMediaTime = new System.Windows.Forms.Timer(components);
            windowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            historiqueToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)playPictureBox).BeginInit();
            menuStrip.SuspendLayout();
            panelMediaControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).BeginInit();
            timeWithProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)windowsMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // QueuePanel
            // 
            QueuePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            QueuePanel.BackColor = Color.Honeydew;
            QueuePanel.Dock = DockStyle.Right;
            QueuePanel.Location = new Point(821, 30);
            QueuePanel.Margin = new Padding(3, 4, 3, 4);
            QueuePanel.Name = "QueuePanel";
            QueuePanel.Size = new Size(187, 569);
            QueuePanel.TabIndex = 5;
            // 
            // ImageListQueue
            // 
            ImageListQueue.ColorDepth = ColorDepth.Depth32Bit;
            ImageListQueue.ImageSize = new Size(16, 16);
            ImageListQueue.TransparentColor = Color.Transparent;
            // 
            // timerMouseMovement
            // 
            timerMouseMovement.Enabled = true;
            timerMouseMovement.Interval = 1000;
            timerMouseMovement.Tick += timerMouvementMouse_Tick;
            // 
            // playPictureBox
            // 
            playPictureBox.BackColor = Color.DimGray;
            playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            playPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            playPictureBox.Location = new Point(3, 95);
            playPictureBox.Margin = new Padding(3, 4, 3, 4);
            playPictureBox.Name = "playPictureBox";
            playPictureBox.Size = new Size(29, 33);
            playPictureBox.TabIndex = 9;
            playPictureBox.TabStop = false;
            playPictureBox.Click += playPictureBox_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { médiaToolStripMenuItem, lectureToolStripMenuItem, audioToolStripMenuItem, vidéoToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 3, 0, 3);
            menuStrip.Size = new Size(1008, 30);
            menuStrip.TabIndex = 10;
            menuStrip.Text = "menuStrip";
            // 
            // médiaToolStripMenuItem
            // 
            médiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnFichierToolStripMenuItem, ouvrirPlusieursFichiersToolStripMenuItem, ouvrirUnDossierToolStripMenuItem, historiqueToolStripMenuItem });
            médiaToolStripMenuItem.Name = "médiaToolStripMenuItem";
            médiaToolStripMenuItem.Size = new Size(65, 24);
            médiaToolStripMenuItem.Text = "Média";
            // 
            // ouvrirUnFichierToolStripMenuItem
            // 
            ouvrirUnFichierToolStripMenuItem.Name = "ouvrirUnFichierToolStripMenuItem";
            ouvrirUnFichierToolStripMenuItem.Size = new Size(254, 26);
            ouvrirUnFichierToolStripMenuItem.Text = "Ouvrir un fichier...";
            ouvrirUnFichierToolStripMenuItem.Click += ouvrirUnFichierToolStripMenuItem_Click;
            // 
            // ouvrirPlusieursFichiersToolStripMenuItem
            // 
            ouvrirPlusieursFichiersToolStripMenuItem.Name = "ouvrirPlusieursFichiersToolStripMenuItem";
            ouvrirPlusieursFichiersToolStripMenuItem.Size = new Size(254, 26);
            ouvrirPlusieursFichiersToolStripMenuItem.Text = "Ouvrir plusieurs fichiers...";
            // 
            // ouvrirUnDossierToolStripMenuItem
            // 
            ouvrirUnDossierToolStripMenuItem.Name = "ouvrirUnDossierToolStripMenuItem";
            ouvrirUnDossierToolStripMenuItem.Size = new Size(254, 26);
            ouvrirUnDossierToolStripMenuItem.Text = "Ouvrir un dossier...";
            // 
            // lectureToolStripMenuItem
            // 
            lectureToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lireToolStripMenuItem, arrêterToolStripMenuItem, précedentToolStripMenuItem, suivantToolStripMenuItem });
            lectureToolStripMenuItem.Name = "lectureToolStripMenuItem";
            lectureToolStripMenuItem.Size = new Size(71, 24);
            lectureToolStripMenuItem.Text = "Lecture";
            // 
            // lireToolStripMenuItem
            // 
            lireToolStripMenuItem.Name = "lireToolStripMenuItem";
            lireToolStripMenuItem.Size = new Size(158, 26);
            lireToolStripMenuItem.Text = "Lire";
            // 
            // arrêterToolStripMenuItem
            // 
            arrêterToolStripMenuItem.Name = "arrêterToolStripMenuItem";
            arrêterToolStripMenuItem.Size = new Size(158, 26);
            arrêterToolStripMenuItem.Text = "Arrêter";
            // 
            // précedentToolStripMenuItem
            // 
            précedentToolStripMenuItem.Name = "précedentToolStripMenuItem";
            précedentToolStripMenuItem.Size = new Size(158, 26);
            précedentToolStripMenuItem.Text = "Précedent";
            // 
            // suivantToolStripMenuItem
            // 
            suivantToolStripMenuItem.Name = "suivantToolStripMenuItem";
            suivantToolStripMenuItem.Size = new Size(158, 26);
            suivantToolStripMenuItem.Text = "Suivant";
            // 
            // audioToolStripMenuItem
            // 
            audioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { augmenterLeVolumeToolStripMenuItem, réduireLeVolumeToolStripMenuItem, couperLeSonToolStripMenuItem });
            audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            audioToolStripMenuItem.Size = new Size(63, 24);
            audioToolStripMenuItem.Text = "Audio";
            // 
            // augmenterLeVolumeToolStripMenuItem
            // 
            augmenterLeVolumeToolStripMenuItem.Name = "augmenterLeVolumeToolStripMenuItem";
            augmenterLeVolumeToolStripMenuItem.Size = new Size(235, 26);
            augmenterLeVolumeToolStripMenuItem.Text = "Augmenter le volume";
            // 
            // réduireLeVolumeToolStripMenuItem
            // 
            réduireLeVolumeToolStripMenuItem.Name = "réduireLeVolumeToolStripMenuItem";
            réduireLeVolumeToolStripMenuItem.Size = new Size(235, 26);
            réduireLeVolumeToolStripMenuItem.Text = "Réduire le volume";
            // 
            // couperLeSonToolStripMenuItem
            // 
            couperLeSonToolStripMenuItem.Name = "couperLeSonToolStripMenuItem";
            couperLeSonToolStripMenuItem.Size = new Size(235, 26);
            couperLeSonToolStripMenuItem.Text = "Couper le son";
            // 
            // vidéoToolStripMenuItem
            // 
            vidéoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pleinÉcranToolStripMenuItem });
            vidéoToolStripMenuItem.Name = "vidéoToolStripMenuItem";
            vidéoToolStripMenuItem.Size = new Size(62, 24);
            vidéoToolStripMenuItem.Text = "Vidéo";
            // 
            // pleinÉcranToolStripMenuItem
            // 
            pleinÉcranToolStripMenuItem.Name = "pleinÉcranToolStripMenuItem";
            pleinÉcranToolStripMenuItem.Size = new Size(164, 26);
            pleinÉcranToolStripMenuItem.Text = "Plein écran";
            // 
            // panelMediaControl
            // 
            panelMediaControl.BackColor = Color.DimGray;
            panelMediaControl.Controls.Add(labelTest);
            panelMediaControl.Controls.Add(mediaPlayerSlider);
            panelMediaControl.Controls.Add(queuePictureBox);
            panelMediaControl.Controls.Add(stopPictureBox);
            panelMediaControl.Controls.Add(playPictureBox);
            panelMediaControl.Controls.Add(timeWithProgressBar);
            panelMediaControl.Dock = DockStyle.Bottom;
            panelMediaControl.Location = new Point(0, 599);
            panelMediaControl.Margin = new Padding(3, 4, 3, 4);
            panelMediaControl.Name = "panelMediaControl";
            panelMediaControl.Size = new Size(1008, 144);
            panelMediaControl.TabIndex = 11;
            // 
            // labelTest
            // 
            labelTest.AutoSize = true;
            labelTest.BackColor = Color.White;
            labelTest.Location = new Point(421, 95);
            labelTest.Name = "labelTest";
            labelTest.Size = new Size(33, 20);
            labelTest.TabIndex = 18;
            labelTest.Text = "test";
            // 
            // mediaPlayerSlider
            // 
            mediaPlayerSlider.Anchor = AnchorStyles.Right;
            mediaPlayerSlider.ForeColor = Color.White;
            mediaPlayerSlider.LabelDebug = labelTest;
            mediaPlayerSlider.Location = new Point(851, 81);
            mediaPlayerSlider.Margin = new Padding(3, 4, 3, 4);
            mediaPlayerSlider.Maximum = 125;
            mediaPlayerSlider.MediaPlayer = null;
            mediaPlayerSlider.Name = "mediaPlayerSlider";
            mediaPlayerSlider.Size = new Size(143, 47);
            mediaPlayerSlider.TabIndex = 17;
            mediaPlayerSlider.Value = 100;
            // 
            // queuePictureBox
            // 
            queuePictureBox.BackgroundImage = Properties.Resources.list_50px;
            queuePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            queuePictureBox.Location = new Point(74, 95);
            queuePictureBox.Margin = new Padding(3, 4, 3, 4);
            queuePictureBox.Name = "queuePictureBox";
            queuePictureBox.Size = new Size(29, 33);
            queuePictureBox.TabIndex = 14;
            queuePictureBox.TabStop = false;
            queuePictureBox.Click += queuePictureBox_Click;
            // 
            // stopPictureBox
            // 
            stopPictureBox.BackgroundImage = Properties.Resources.stop_50px;
            stopPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            stopPictureBox.Location = new Point(39, 95);
            stopPictureBox.Margin = new Padding(3, 4, 3, 4);
            stopPictureBox.Name = "stopPictureBox";
            stopPictureBox.Size = new Size(29, 33);
            stopPictureBox.TabIndex = 13;
            stopPictureBox.TabStop = false;
            stopPictureBox.Click += stopPictureBox_Click;
            // 
            // timeWithProgressBar
            // 
            timeWithProgressBar.Controls.Add(labelTotalMediaTime);
            timeWithProgressBar.Controls.Add(labelCurrentMediaTime);
            timeWithProgressBar.Controls.Add(mediaCustomProgressBar);
            timeWithProgressBar.Dock = DockStyle.Top;
            timeWithProgressBar.Location = new Point(0, 0);
            timeWithProgressBar.Margin = new Padding(3, 4, 3, 4);
            timeWithProgressBar.Name = "timeWithProgressBar";
            timeWithProgressBar.Size = new Size(1008, 57);
            timeWithProgressBar.TabIndex = 16;
            // 
            // labelTotalMediaTime
            // 
            labelTotalMediaTime.BackColor = Color.White;
            labelTotalMediaTime.Dock = DockStyle.Right;
            labelTotalMediaTime.Location = new Point(952, 35);
            labelTotalMediaTime.Name = "labelTotalMediaTime";
            labelTotalMediaTime.Size = new Size(56, 22);
            labelTotalMediaTime.TabIndex = 11;
            labelTotalMediaTime.Text = "00:00:00";
            // 
            // labelCurrentMediaTime
            // 
            labelCurrentMediaTime.BackColor = Color.White;
            labelCurrentMediaTime.Dock = DockStyle.Left;
            labelCurrentMediaTime.Location = new Point(0, 35);
            labelCurrentMediaTime.Name = "labelCurrentMediaTime";
            labelCurrentMediaTime.Size = new Size(56, 22);
            labelCurrentMediaTime.TabIndex = 12;
            labelCurrentMediaTime.Text = "00:00:00";
            // 
            // mediaCustomProgressBar
            // 
            mediaCustomProgressBar.ChannelColor = Color.FromArgb(64, 64, 64);
            mediaCustomProgressBar.ChannelHeight = 10;
            mediaCustomProgressBar.Dock = DockStyle.Top;
            mediaCustomProgressBar.ForeBackColor = Color.Black;
            mediaCustomProgressBar.ForeColor = Color.White;
            mediaCustomProgressBar.Location = new Point(0, 0);
            mediaCustomProgressBar.Margin = new Padding(3, 4, 3, 4);
            mediaCustomProgressBar.MediaPlayer = null;
            mediaCustomProgressBar.Name = "mediaCustomProgressBar";
            mediaCustomProgressBar.ShowMaximun = false;
            mediaCustomProgressBar.ShowValue = CustomControls.TextPosition.None;
            mediaCustomProgressBar.Size = new Size(1008, 35);
            mediaCustomProgressBar.SliderColor = Color.LightSeaGreen;
            mediaCustomProgressBar.SliderHeight = 10;
            mediaCustomProgressBar.SymbolAfter = "";
            mediaCustomProgressBar.SymbolBefore = "";
            mediaCustomProgressBar.TabIndex = 17;
            // 
            // updateMediaTime
            // 
            updateMediaTime.Enabled = true;
            updateMediaTime.Interval = 10;
            updateMediaTime.Tick += updateMediaTime_Tick;
            // 
            // windowsMediaPlayer
            // 
            windowsMediaPlayer.Dock = DockStyle.Fill;
            windowsMediaPlayer.Enabled = true;
            windowsMediaPlayer.Location = new Point(0, 30);
            windowsMediaPlayer.Margin = new Padding(3, 4, 3, 4);
            windowsMediaPlayer.Name = "windowsMediaPlayer";
            windowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("windowsMediaPlayer.OcxState");
            windowsMediaPlayer.Size = new Size(821, 569);
            windowsMediaPlayer.TabIndex = 13;
            windowsMediaPlayer.DoubleClickEvent += windowsMediaPlayer_DoubleClickEvent;
            windowsMediaPlayer.MouseUpEvent += windowsMediaPlayer_MouseUpEvent;
            // 
            // historiqueToolStripMenuItem
            // 
            historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            historiqueToolStripMenuItem.Size = new Size(254, 26);
            historiqueToolStripMenuItem.Text = "Historique";
            historiqueToolStripMenuItem.Click += historiqueToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1008, 743);
            Controls.Add(windowsMediaPlayer);
            Controls.Add(QueuePanel);
            Controls.Add(panelMediaControl);
            Controls.Add(menuStrip);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "MediaPlayer";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)playPictureBox).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelMediaControl.ResumeLayout(false);
            panelMediaControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).EndInit();
            timeWithProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)windowsMediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel QueuePanel;
        private ImageList ImageListQueue;
        private System.Windows.Forms.Timer timerMouseMovement;
        private PictureBox playPictureBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem médiaToolStripMenuItem;
        private ToolStripMenuItem lectureToolStripMenuItem;
        private ToolStripMenuItem audioToolStripMenuItem;
        private ToolStripMenuItem vidéoToolStripMenuItem;
        private Panel panelMediaControl;
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
        private Panel timeWithProgressBar;
        private CustomControls.CustomProgressBar mediaCustomProgressBar;
        private AxWMPLib.AxWindowsMediaPlayer windowsMediaPlayer;
        private CustomControls.CustomSlider mediaPlayerSlider;
        private Label labelTest;
        private ToolStripMenuItem historiqueToolStripMenuItem;
    }
}
