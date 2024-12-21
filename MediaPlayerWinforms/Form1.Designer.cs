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
            playPictureBox = new PictureBox();
            menuStrip = new MenuStrip();
            médiaToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnFichierToolStripMenuItem = new ToolStripMenuItem();
            ouvrirPlusieursFichiersToolStripMenuItem = new ToolStripMenuItem();
            ouvrirUnDossierToolStripMenuItem = new ToolStripMenuItem();
            historiqueToolStripMenuItem = new ToolStripMenuItem();
            lectureToolStripMenuItem = new ToolStripMenuItem();
            lireToolStripMenuItem = new ToolStripMenuItem();
            arrêterToolStripMenuItem = new ToolStripMenuItem();
            précedentToolStripMenuItem = new ToolStripMenuItem();
            suivantToolStripMenuItem = new ToolStripMenuItem();
            audioToolStripMenuItem = new ToolStripMenuItem();
            couperLeSonToolStripMenuItem = new ToolStripMenuItem();
            vidéoToolStripMenuItem = new ToolStripMenuItem();
            pleinÉcranToolStripMenuItem = new ToolStripMenuItem();
            soustitresToolStripMenuItem = new ToolStripMenuItem();
            créerSoustitresToolStripMenuItem1 = new ToolStripMenuItem();
            tailleDuModelToolStripMenuItem = new ToolStripMenuItem();
            tinyToolStripMenuItem = new ToolStripMenuItem();
            baseToolStripMenuItem = new ToolStripMenuItem();
            smallToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem = new ToolStripMenuItem();
            largeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            flushHistoryToolStripMenuItem = new ToolStripMenuItem();
            timeJumpToolStripMenuItem = new ToolStripMenuItem();
            secondesToolStripMenuItem = new ToolStripMenuItem();
            secondesToolStripMenuItem1 = new ToolStripMenuItem();
            outilsToolStripMenuItem = new ToolStripMenuItem();
            panelMediaControl = new Panel();
            loopPictureBox = new PictureBox();
            fullScrenPictureBox = new PictureBox();
            volumePictureBox = new PictureBox();
            forwardPictureBox = new PictureBox();
            rewindPictureBox = new PictureBox();
            favPictureBox = new PictureBox();
            labelVolumeSlider = new Label();
            NextPictureBox = new PictureBox();
            precedentPictureBox = new PictureBox();
            mediaPlayerSlider = new CustomControls.CustomSlider();
            queuePictureBox = new PictureBox();
            stopPictureBox = new PictureBox();
            timeWithProgressBar = new Panel();
            labelTotalMediaTime = new Label();
            labelCurrentMediaTime = new Label();
            mediaCustomProgressBar = new CustomControls.CustomProgressBar();
            updateMediaTime = new System.Windows.Forms.Timer(components);
            customQueuePanel = new CustomControls.CustomQueuePanel();
            customMediaPlayer = new CustomControls.CustomMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)playPictureBox).BeginInit();
            menuStrip.SuspendLayout();
            panelMediaControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loopPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fullScrenPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)forwardPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rewindPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)favPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NextPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precedentPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).BeginInit();
            timeWithProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // playPictureBox
            // 
            playPictureBox.BackColor = Color.DimGray;
            playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            playPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            playPictureBox.Location = new Point(72, 71);
            playPictureBox.Name = "playPictureBox";
            playPictureBox.Size = new Size(25, 25);
            playPictureBox.TabIndex = 9;
            playPictureBox.TabStop = false;
            playPictureBox.Click += playPictureBox_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { médiaToolStripMenuItem, lectureToolStripMenuItem, audioToolStripMenuItem, vidéoToolStripMenuItem, soustitresToolStripMenuItem, optionsToolStripMenuItem, outilsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(882, 24);
            menuStrip.TabIndex = 10;
            menuStrip.Text = "menuStrip";
            // 
            // médiaToolStripMenuItem
            // 
            médiaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnFichierToolStripMenuItem, ouvrirPlusieursFichiersToolStripMenuItem, ouvrirUnDossierToolStripMenuItem, historiqueToolStripMenuItem });
            médiaToolStripMenuItem.Name = "médiaToolStripMenuItem";
            médiaToolStripMenuItem.ShowShortcutKeys = false;
            médiaToolStripMenuItem.Size = new Size(52, 20);
            médiaToolStripMenuItem.Text = "Média";
            // 
            // ouvrirUnFichierToolStripMenuItem
            // 
            ouvrirUnFichierToolStripMenuItem.Image = Properties.Resources.b_video_file_50;
            ouvrirUnFichierToolStripMenuItem.Name = "ouvrirUnFichierToolStripMenuItem";
            ouvrirUnFichierToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            ouvrirUnFichierToolStripMenuItem.Size = new Size(312, 22);
            ouvrirUnFichierToolStripMenuItem.Text = "Ouvrir un fichier...";
            ouvrirUnFichierToolStripMenuItem.Click += ouvrirUnFichierToolStripMenuItem_Click;
            // 
            // ouvrirPlusieursFichiersToolStripMenuItem
            // 
            ouvrirPlusieursFichiersToolStripMenuItem.Image = Properties.Resources.b_video_file_50;
            ouvrirPlusieursFichiersToolStripMenuItem.Name = "ouvrirPlusieursFichiersToolStripMenuItem";
            ouvrirPlusieursFichiersToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.O;
            ouvrirPlusieursFichiersToolStripMenuItem.Size = new Size(312, 22);
            ouvrirPlusieursFichiersToolStripMenuItem.Text = "Ouvrir plusieurs fichiers...";
            ouvrirPlusieursFichiersToolStripMenuItem.Click += ouvrirPlusieursFichiersToolStripMenuItem_Click;
            // 
            // ouvrirUnDossierToolStripMenuItem
            // 
            ouvrirUnDossierToolStripMenuItem.Image = Properties.Resources.b_folder_50;
            ouvrirUnDossierToolStripMenuItem.Name = "ouvrirUnDossierToolStripMenuItem";
            ouvrirUnDossierToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            ouvrirUnDossierToolStripMenuItem.Size = new Size(312, 22);
            ouvrirUnDossierToolStripMenuItem.Text = "Ouvrir un dossier...";
            ouvrirUnDossierToolStripMenuItem.Click += ouvrirUnDossierToolStripMenuItem_Click;
            // 
            // historiqueToolStripMenuItem
            // 
            historiqueToolStripMenuItem.Image = Properties.Resources.b_time_machine_50;
            historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            historiqueToolStripMenuItem.Overflow = ToolStripItemOverflow.Always;
            historiqueToolStripMenuItem.Size = new Size(312, 22);
            historiqueToolStripMenuItem.Text = "Historique";
            historiqueToolStripMenuItem.MouseHover += historiqueToolStripMenuItem_MouseHover;
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
            lireToolStripMenuItem.Image = Properties.Resources.b_play_50;
            lireToolStripMenuItem.Name = "lireToolStripMenuItem";
            lireToolStripMenuItem.Size = new Size(127, 22);
            lireToolStripMenuItem.Text = "Lire";
            // 
            // arrêterToolStripMenuItem
            // 
            arrêterToolStripMenuItem.Image = Properties.Resources.b_stop_50;
            arrêterToolStripMenuItem.Name = "arrêterToolStripMenuItem";
            arrêterToolStripMenuItem.Size = new Size(127, 22);
            arrêterToolStripMenuItem.Text = "Arrêter";
            // 
            // précedentToolStripMenuItem
            // 
            précedentToolStripMenuItem.Image = Properties.Resources.b_skip_to_start_50;
            précedentToolStripMenuItem.Name = "précedentToolStripMenuItem";
            précedentToolStripMenuItem.Size = new Size(127, 22);
            précedentToolStripMenuItem.Text = "Précedent";
            // 
            // suivantToolStripMenuItem
            // 
            suivantToolStripMenuItem.Image = Properties.Resources.b_end_50;
            suivantToolStripMenuItem.Name = "suivantToolStripMenuItem";
            suivantToolStripMenuItem.Size = new Size(127, 22);
            suivantToolStripMenuItem.Text = "Suivant";
            // 
            // audioToolStripMenuItem
            // 
            audioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { couperLeSonToolStripMenuItem });
            audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            audioToolStripMenuItem.Size = new Size(51, 20);
            audioToolStripMenuItem.Text = "Audio";
            // 
            // couperLeSonToolStripMenuItem
            // 
            couperLeSonToolStripMenuItem.Image = Properties.Resources.b_mute_50;
            couperLeSonToolStripMenuItem.Name = "couperLeSonToolStripMenuItem";
            couperLeSonToolStripMenuItem.Size = new Size(147, 22);
            couperLeSonToolStripMenuItem.Text = "Couper le son";
            couperLeSonToolStripMenuItem.Click += couperLeSonToolStripMenuItem_Click;
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
            pleinÉcranToolStripMenuItem.Image = Properties.Resources.b_fullscreen_50;
            pleinÉcranToolStripMenuItem.Name = "pleinÉcranToolStripMenuItem";
            pleinÉcranToolStripMenuItem.Size = new Size(132, 22);
            pleinÉcranToolStripMenuItem.Text = "Plein écran";
            pleinÉcranToolStripMenuItem.Click += pleinÉcranToolStripMenuItem_Click;
            // 
            // soustitresToolStripMenuItem
            // 
            soustitresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { créerSoustitresToolStripMenuItem1, tailleDuModelToolStripMenuItem });
            soustitresToolStripMenuItem.Name = "soustitresToolStripMenuItem";
            soustitresToolStripMenuItem.Size = new Size(75, 20);
            soustitresToolStripMenuItem.Text = "Sous-titres";
            // 
            // créerSoustitresToolStripMenuItem1
            // 
            créerSoustitresToolStripMenuItem1.Name = "créerSoustitresToolStripMenuItem1";
            créerSoustitresToolStripMenuItem1.Size = new Size(180, 22);
            créerSoustitresToolStripMenuItem1.Text = "Créer sous-titres";
            créerSoustitresToolStripMenuItem1.Click += créerSoustitresToolStripMenuItem_Click;
            // 
            // tailleDuModelToolStripMenuItem
            // 
            tailleDuModelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tinyToolStripMenuItem, baseToolStripMenuItem, smallToolStripMenuItem, mediumToolStripMenuItem, largeToolStripMenuItem });
            tailleDuModelToolStripMenuItem.Name = "tailleDuModelToolStripMenuItem";
            tailleDuModelToolStripMenuItem.Size = new Size(180, 22);
            tailleDuModelToolStripMenuItem.Text = "Taille du Model";
            // 
            // tinyToolStripMenuItem
            // 
            tinyToolStripMenuItem.Name = "tinyToolStripMenuItem";
            tinyToolStripMenuItem.Size = new Size(184, 26);
            tinyToolStripMenuItem.Text = "tiny";
            tinyToolStripMenuItem.Click += tinyToolStripMenuItem_Click;
            // 
            // baseToolStripMenuItem
            // 
            baseToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            baseToolStripMenuItem.Image = Properties.Resources.approved_96;
            baseToolStripMenuItem.Name = "baseToolStripMenuItem";
            baseToolStripMenuItem.Size = new Size(184, 26);
            baseToolStripMenuItem.Text = "base";
            baseToolStripMenuItem.Click += baseToolStripMenuItem_Click;
            // 
            // smallToolStripMenuItem
            // 
            smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            smallToolStripMenuItem.Size = new Size(184, 26);
            smallToolStripMenuItem.Text = "small";
            smallToolStripMenuItem.Click += smallToolStripMenuItem_Click;
            // 
            // mediumToolStripMenuItem
            // 
            mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            mediumToolStripMenuItem.Size = new Size(184, 26);
            mediumToolStripMenuItem.Text = "medium";
            mediumToolStripMenuItem.Click += mediumToolStripMenuItem_Click;
            // 
            // largeToolStripMenuItem
            // 
            largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            largeToolStripMenuItem.Size = new Size(184, 26);
            largeToolStripMenuItem.Text = "large";
            largeToolStripMenuItem.Click += largeToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { flushHistoryToolStripMenuItem, timeJumpToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(56, 20);
            optionsToolStripMenuItem.Text = "Option";
            // 
            // flushHistoryToolStripMenuItem
            // 
            flushHistoryToolStripMenuItem.Image = Properties.Resources.b_delete_50;
            flushHistoryToolStripMenuItem.Name = "flushHistoryToolStripMenuItem";
            flushHistoryToolStripMenuItem.Size = new Size(168, 22);
            flushHistoryToolStripMenuItem.Text = "Effacer Historique";
            flushHistoryToolStripMenuItem.Click += flushHistoryToolStripMenuItem_Click;
            // 
            // timeJumpToolStripMenuItem
            // 
            timeJumpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { secondesToolStripMenuItem, secondesToolStripMenuItem1 });
            timeJumpToolStripMenuItem.Image = Properties.Resources.jump_50;
            timeJumpToolStripMenuItem.Name = "timeJumpToolStripMenuItem";
            timeJumpToolStripMenuItem.Size = new Size(168, 22);
            timeJumpToolStripMenuItem.Text = "Temps sauté";
            // 
            // secondesToolStripMenuItem
            // 
            secondesToolStripMenuItem.ForeColor = SystemColors.ControlText;
            secondesToolStripMenuItem.Image = Properties.Resources.b_forward_5_50;
            secondesToolStripMenuItem.Name = "secondesToolStripMenuItem";
            secondesToolStripMenuItem.Size = new Size(138, 22);
            secondesToolStripMenuItem.Text = "5 secondes";
            secondesToolStripMenuItem.Click += fiveSecondesToolStripMenuItem_Click;
            // 
            // secondesToolStripMenuItem1
            // 
            secondesToolStripMenuItem1.Image = Properties.Resources.b_forward_10_50;
            secondesToolStripMenuItem1.Name = "secondesToolStripMenuItem1";
            secondesToolStripMenuItem1.Size = new Size(138, 22);
            secondesToolStripMenuItem1.Text = "10 secondes";
            secondesToolStripMenuItem1.Click += tenSecondesToolStripMenuItem1_Click;
            // 
            // outilsToolStripMenuItem
            // 
            outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            outilsToolStripMenuItem.Size = new Size(50, 20);
            outilsToolStripMenuItem.Text = "Outils";
            // 
            // panelMediaControl
            // 
            panelMediaControl.BackColor = Color.DimGray;
            panelMediaControl.Controls.Add(loopPictureBox);
            panelMediaControl.Controls.Add(fullScrenPictureBox);
            panelMediaControl.Controls.Add(volumePictureBox);
            panelMediaControl.Controls.Add(forwardPictureBox);
            panelMediaControl.Controls.Add(rewindPictureBox);
            panelMediaControl.Controls.Add(favPictureBox);
            panelMediaControl.Controls.Add(labelVolumeSlider);
            panelMediaControl.Controls.Add(NextPictureBox);
            panelMediaControl.Controls.Add(precedentPictureBox);
            panelMediaControl.Controls.Add(mediaPlayerSlider);
            panelMediaControl.Controls.Add(queuePictureBox);
            panelMediaControl.Controls.Add(stopPictureBox);
            panelMediaControl.Controls.Add(playPictureBox);
            panelMediaControl.Controls.Add(timeWithProgressBar);
            panelMediaControl.Dock = DockStyle.Bottom;
            panelMediaControl.Location = new Point(0, 449);
            panelMediaControl.Name = "panelMediaControl";
            panelMediaControl.Size = new Size(882, 108);
            panelMediaControl.TabIndex = 11;
            // 
            // loopPictureBox
            // 
            loopPictureBox.BackgroundImage = Properties.Resources.loop_50;
            loopPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            loopPictureBox.Location = new Point(226, 71);
            loopPictureBox.Name = "loopPictureBox";
            loopPictureBox.Size = new Size(25, 25);
            loopPictureBox.TabIndex = 27;
            loopPictureBox.TabStop = false;
            // 
            // fullScrenPictureBox
            // 
            fullScrenPictureBox.BackgroundImage = Properties.Resources.fullscreen_50;
            fullScrenPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            fullScrenPictureBox.Location = new Point(195, 71);
            fullScrenPictureBox.Name = "fullScrenPictureBox";
            fullScrenPictureBox.Size = new Size(25, 25);
            fullScrenPictureBox.TabIndex = 26;
            fullScrenPictureBox.TabStop = false;
            fullScrenPictureBox.Click += fullScrenPictureBox_Click;
            // 
            // volumePictureBox
            // 
            volumePictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            volumePictureBox.BackgroundImage = Properties.Resources.high_volume_50;
            volumePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            volumePictureBox.Location = new Point(666, 71);
            volumePictureBox.Name = "volumePictureBox";
            volumePictureBox.Size = new Size(25, 25);
            volumePictureBox.TabIndex = 25;
            volumePictureBox.TabStop = false;
            volumePictureBox.Click += volumePictureBox_Click;
            // 
            // forwardPictureBox
            // 
            forwardPictureBox.BackgroundImage = Properties.Resources.forward_10_50;
            forwardPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            forwardPictureBox.Location = new Point(102, 71);
            forwardPictureBox.Name = "forwardPictureBox";
            forwardPictureBox.Size = new Size(25, 25);
            forwardPictureBox.TabIndex = 24;
            forwardPictureBox.TabStop = false;
            forwardPictureBox.Tag = "10";
            forwardPictureBox.Click += forwardPictureBox_Click;
            // 
            // rewindPictureBox
            // 
            rewindPictureBox.BackgroundImage = Properties.Resources.replay_10_50;
            rewindPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            rewindPictureBox.Location = new Point(41, 71);
            rewindPictureBox.Name = "rewindPictureBox";
            rewindPictureBox.Size = new Size(25, 25);
            rewindPictureBox.TabIndex = 23;
            rewindPictureBox.TabStop = false;
            rewindPictureBox.Tag = "10";
            rewindPictureBox.Click += rewindPictureBox_Click;
            // 
            // favPictureBox
            // 
            favPictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            favPictureBox.BackgroundImage = Properties.Resources.not_fav_50;
            favPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            favPictureBox.Location = new Point(605, 71);
            favPictureBox.Name = "favPictureBox";
            favPictureBox.Size = new Size(25, 25);
            favPictureBox.TabIndex = 22;
            favPictureBox.TabStop = false;
            favPictureBox.Click += favPictureBox_Click;
            // 
            // labelVolumeSlider
            // 
            labelVolumeSlider.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelVolumeSlider.BackColor = Color.White;
            labelVolumeSlider.Location = new Point(697, 77);
            labelVolumeSlider.Name = "labelVolumeSlider";
            labelVolumeSlider.Size = new Size(42, 19);
            labelVolumeSlider.TabIndex = 21;
            labelVolumeSlider.Text = "100%";
            // 
            // NextPictureBox
            // 
            NextPictureBox.BackgroundImage = Properties.Resources.next_50;
            NextPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            NextPictureBox.Location = new Point(133, 71);
            NextPictureBox.Name = "NextPictureBox";
            NextPictureBox.Size = new Size(25, 25);
            NextPictureBox.TabIndex = 20;
            NextPictureBox.TabStop = false;
            NextPictureBox.Click += NextPictureBox_Click;
            // 
            // precedentPictureBox
            // 
            precedentPictureBox.BackgroundImage = Properties.Resources.precedent_50;
            precedentPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            precedentPictureBox.Location = new Point(12, 71);
            precedentPictureBox.Name = "precedentPictureBox";
            precedentPictureBox.Size = new Size(25, 25);
            precedentPictureBox.TabIndex = 19;
            precedentPictureBox.TabStop = false;
            precedentPictureBox.Click += precedentPictureBox_Click;
            // 
            // mediaPlayerSlider
            // 
            mediaPlayerSlider.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            mediaPlayerSlider.ForeColor = Color.White;
            mediaPlayerSlider.LabelVolume = labelVolumeSlider;
            mediaPlayerSlider.Location = new Point(745, 59);
            mediaPlayerSlider.Maximum = 125;
            mediaPlayerSlider.Name = "mediaPlayerSlider";
            mediaPlayerSlider.Size = new Size(125, 37);
            mediaPlayerSlider.TabIndex = 17;
            mediaPlayerSlider.Value = 100;
            // 
            // queuePictureBox
            // 
            queuePictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            queuePictureBox.BackgroundImage = Properties.Resources.list_50px;
            queuePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            queuePictureBox.Location = new Point(636, 71);
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
            stopPictureBox.Location = new Point(164, 71);
            stopPictureBox.Name = "stopPictureBox";
            stopPictureBox.Size = new Size(25, 25);
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
            timeWithProgressBar.Name = "timeWithProgressBar";
            timeWithProgressBar.Size = new Size(882, 53);
            timeWithProgressBar.TabIndex = 16;
            // 
            // labelTotalMediaTime
            // 
            labelTotalMediaTime.AutoSize = true;
            labelTotalMediaTime.BackColor = Color.White;
            labelTotalMediaTime.Dock = DockStyle.Right;
            labelTotalMediaTime.Location = new Point(833, 30);
            labelTotalMediaTime.Name = "labelTotalMediaTime";
            labelTotalMediaTime.Size = new Size(49, 15);
            labelTotalMediaTime.TabIndex = 11;
            labelTotalMediaTime.Text = "00:00:00";
            // 
            // labelCurrentMediaTime
            // 
            labelCurrentMediaTime.AutoSize = true;
            labelCurrentMediaTime.BackColor = Color.White;
            labelCurrentMediaTime.Dock = DockStyle.Left;
            labelCurrentMediaTime.Location = new Point(0, 30);
            labelCurrentMediaTime.Name = "labelCurrentMediaTime";
            labelCurrentMediaTime.Size = new Size(49, 15);
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
            mediaCustomProgressBar.Name = "mediaCustomProgressBar";
            mediaCustomProgressBar.ShowMaximun = false;
            mediaCustomProgressBar.ShowValue = CustomControls.TextPosition.None;
            mediaCustomProgressBar.Size = new Size(882, 30);
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
            // customQueuePanel
            // 
            customQueuePanel.AutoScroll = true;
            customQueuePanel.Dock = DockStyle.Right;
            customQueuePanel.Location = new Point(682, 24);
            customQueuePanel.Name = "customQueuePanel";
            customQueuePanel.Size = new Size(200, 425);
            customQueuePanel.TabIndex = 13;
            // 
            // customMediaPlayer
            // 
            customMediaPlayer.BackColor = Color.Black;
            customMediaPlayer.Dock = DockStyle.Fill;
            customMediaPlayer.LabelTotalMediaTime = labelTotalMediaTime;
            customMediaPlayer.Location = new Point(0, 24);
            customMediaPlayer.LoopN = 5;
            customMediaPlayer.LoopVar = CustomControls.LoopType.InfiniteLoop;
            customMediaPlayer.Margin = new Padding(3, 2, 3, 2);
            customMediaPlayer.Name = "customMediaPlayer";
            customMediaPlayer.PositionSeconds = 0D;
            customMediaPlayer.Size = new Size(682, 425);
            customMediaPlayer.Spu = -1;
            customMediaPlayer.TabIndex = 14;
            customMediaPlayer.Text = "customMediaPlayer1";
            customMediaPlayer.VlcMediaplayerOptions = null;
            customMediaPlayer.EndReached += customMediaPlayer_EndReached;
            customMediaPlayer.Click += customMediaPlayer_Click;
            customMediaPlayer.DoubleClick += customMediaPlayer_DoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(882, 557);
            Controls.Add(customMediaPlayer);
            Controls.Add(customQueuePanel);
            Controls.Add(panelMediaControl);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "MediaPlayer";
            ((System.ComponentModel.ISupportInitialize)playPictureBox).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panelMediaControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loopPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fullScrenPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)forwardPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rewindPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)favPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NextPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)precedentPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)queuePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopPictureBox).EndInit();
            timeWithProgressBar.ResumeLayout(false);
            timeWithProgressBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customMediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private ToolStripMenuItem couperLeSonToolStripMenuItem;
        private ToolStripMenuItem pleinÉcranToolStripMenuItem;
        private PictureBox stopPictureBox;
        private PictureBox queuePictureBox;
        private Panel timeWithProgressBar;
        private CustomControls.CustomProgressBar mediaCustomProgressBar;
        private CustomControls.CustomSlider mediaPlayerSlider;
        private ToolStripMenuItem historiqueToolStripMenuItem;
        private CustomControls.CustomMediaPlayer customMediaPlayer;
        private CustomControls.CustomQueuePanel customQueuePanel;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem flushHistoryToolStripMenuItem;
        private PictureBox precedentPictureBox;
        private PictureBox NextPictureBox;
        private Label labelVolumeSlider;
        private PictureBox favPictureBox;
        private PictureBox rewindPictureBox;
        private PictureBox forwardPictureBox;
        private PictureBox volumePictureBox;
        private ToolStripMenuItem timeJumpToolStripMenuItem;
        private ToolStripMenuItem secondesToolStripMenuItem;
        private ToolStripMenuItem secondesToolStripMenuItem1;
        private PictureBox loopPictureBox;
        private PictureBox fullScrenPictureBox;
        private ToolStripMenuItem outilsToolStripMenuItem;
        private ToolStripMenuItem soustitresToolStripMenuItem;
        private ToolStripMenuItem créerSoustitresToolStripMenuItem1;
        private ToolStripMenuItem tailleDuModelToolStripMenuItem;
        private ToolStripMenuItem tinyToolStripMenuItem;
        private ToolStripMenuItem baseToolStripMenuItem;
        private ToolStripMenuItem smallToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private ToolStripMenuItem largeToolStripMenuItem;
    }
}
