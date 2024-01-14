namespace Generateur_de_Mot_de_passe
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
            components = new System.ComponentModel.Container();
            Nouveau = new Button();
            Modifier = new Button();
            Sauvegarder = new Button();
            Effacer = new Button();
            listBox1 = new ListBox();
            bindingSource1 = new BindingSource(components);
            panel1 = new Panel();
            txt_titre = new TextBox();
            txt_description = new TextBox();
            Titre = new Label();
            Description = new Label();
            txt_mdp = new TextBox();
            Motdepasse = new Label();
            Affichermdp = new CheckBox();
            copier = new Button();
            generermdp = new Button();
            groupBox1 = new GroupBox();
            txtNote = new TextBox();
            txt_url = new TextBox();
            txt_carspec = new TextBox();
            checkchiffre = new CheckBox();
            checkcar = new CheckBox();
            checkmaj = new CheckBox();
            longueurmdp = new Label();
            longueur = new Label();
            trackbar = new TrackBar();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            lblCount = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackbar).BeginInit();
            SuspendLayout();
            // 
            // Nouveau
            // 
            Nouveau.Location = new Point(91, 9);
            Nouveau.Name = "Nouveau";
            Nouveau.Size = new Size(94, 29);
            Nouveau.TabIndex = 0;
            Nouveau.Text = "Nouveau";
            Nouveau.UseVisualStyleBackColor = true;
            Nouveau.Click += Nouveau_Click;
            // 
            // Modifier
            // 
            Modifier.Enabled = false;
            Modifier.Location = new Point(192, 9);
            Modifier.Name = "Modifier";
            Modifier.Size = new Size(94, 29);
            Modifier.TabIndex = 1;
            Modifier.Text = "Modifier";
            Modifier.UseVisualStyleBackColor = true;
            Modifier.Click += buttonModifier_Click;
            // 
            // Sauvegarder
            // 
            Sauvegarder.Enabled = false;
            Sauvegarder.Location = new Point(293, 9);
            Sauvegarder.Name = "Sauvegarder";
            Sauvegarder.Size = new Size(94, 29);
            Sauvegarder.TabIndex = 2;
            Sauvegarder.Text = "Sauvegarder";
            Sauvegarder.UseVisualStyleBackColor = true;
            Sauvegarder.Click += Sauvegarder_Click;
            // 
            // Effacer
            // 
            Effacer.Enabled = false;
            Effacer.Location = new Point(392, 9);
            Effacer.Name = "Effacer";
            Effacer.Size = new Size(94, 29);
            Effacer.TabIndex = 3;
            Effacer.Text = "Effacer";
            Effacer.UseVisualStyleBackColor = true;
            Effacer.Click += buttonEffacer_Click;
            // 
            // listBox1
            // 
            listBox1.DataSource = bindingSource1;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(0, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(181, 444);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Password);
            // 
            // panel1
            // 
            panel1.Controls.Add(Nouveau);
            panel1.Controls.Add(Modifier);
            panel1.Controls.Add(Effacer);
            panel1.Controls.Add(Sauvegarder);
            panel1.Location = new Point(229, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(559, 91);
            panel1.TabIndex = 5;
            // 
            // txt_titre
            // 
            txt_titre.DataBindings.Add(new Binding("Text", bindingSource1, "Description", true));
            txt_titre.Location = new Point(321, 117);
            txt_titre.Name = "txt_titre";
            txt_titre.Size = new Size(271, 27);
            txt_titre.TabIndex = 7;
            // 
            // txt_description
            // 
            txt_description.DataBindings.Add(new Binding("Text", bindingSource1, "UserAccount", true));
            txt_description.Location = new Point(320, 161);
            txt_description.Name = "txt_description";
            txt_description.Size = new Size(271, 27);
            txt_description.TabIndex = 8;
            // 
            // Titre
            // 
            Titre.AutoSize = true;
            Titre.Location = new Point(229, 117);
            Titre.Name = "Titre";
            Titre.Size = new Size(49, 20);
            Titre.TabIndex = 9;
            Titre.Text = "Titre *";
            // 
            // Description
            // 
            Description.AutoSize = true;
            Description.Location = new Point(201, 164);
            Description.Name = "Description";
            Description.Size = new Size(113, 20);
            Description.TabIndex = 10;
            Description.Text = "Code utilisateur";
            // 
            // txt_mdp
            // 
            txt_mdp.DataBindings.Add(new Binding("Text", bindingSource1, "PasswordValue", true));
            txt_mdp.Enabled = false;
            txt_mdp.Location = new Point(321, 205);
            txt_mdp.Name = "txt_mdp";
            txt_mdp.ReadOnly = true;
            txt_mdp.Size = new Size(271, 27);
            txt_mdp.TabIndex = 11;
            txt_mdp.TextChanged += txt_mdp_TextChanged;
            // 
            // Motdepasse
            // 
            Motdepasse.AutoSize = true;
            Motdepasse.Location = new Point(217, 208);
            Motdepasse.Name = "Motdepasse";
            Motdepasse.Size = new Size(108, 20);
            Motdepasse.TabIndex = 12;
            Motdepasse.Text = "Mot de passe *";
            // 
            // Affichermdp
            // 
            Affichermdp.AutoSize = true;
            Affichermdp.Location = new Point(621, 208);
            Affichermdp.Name = "Affichermdp";
            Affichermdp.Size = new Size(83, 24);
            Affichermdp.TabIndex = 13;
            Affichermdp.Text = "Afficher";
            Affichermdp.UseVisualStyleBackColor = true;
            Affichermdp.CheckedChanged += Affichermdp_CheckedChanged;
            // 
            // copier
            // 
            copier.Location = new Point(618, 240);
            copier.Name = "copier";
            copier.Size = new Size(94, 29);
            copier.TabIndex = 14;
            copier.Text = "Copier";
            copier.UseVisualStyleBackColor = true;
            copier.Click += buttonCopier_Click;
            // 
            // generermdp
            // 
            generermdp.Location = new Point(293, 240);
            generermdp.Name = "generermdp";
            generermdp.Size = new Size(94, 29);
            generermdp.TabIndex = 15;
            generermdp.Text = "Générer";
            generermdp.UseVisualStyleBackColor = true;
            generermdp.Click += buttonGenerer_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtNote);
            groupBox1.Controls.Add(txt_url);
            groupBox1.Controls.Add(txt_carspec);
            groupBox1.Controls.Add(checkchiffre);
            groupBox1.Controls.Add(checkcar);
            groupBox1.Controls.Add(checkmaj);
            groupBox1.Controls.Add(longueurmdp);
            groupBox1.Controls.Add(longueur);
            groupBox1.Controls.Add(trackbar);
            groupBox1.Location = new Point(217, 275);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(575, 172);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Option du générateur";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(123, 84);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Vertical;
            txtNote.Size = new Size(125, 34);
            txtNote.TabIndex = 24;
            txtNote.TextChanged += txtNote_TextChanged;
            // 
            // txt_url
            // 
            txt_url.Location = new Point(415, 84);
            txt_url.Name = "txt_url";
            txt_url.Size = new Size(125, 27);
            txt_url.TabIndex = 23;
            txt_url.TextChanged += txt_url_TextChanged;
            // 
            // txt_carspec
            // 
            txt_carspec.DataBindings.Add(new Binding("Text", bindingSource1, "SpecialCharacters", true));
            txt_carspec.Location = new Point(173, 133);
            txt_carspec.Name = "txt_carspec";
            txt_carspec.Size = new Size(271, 27);
            txt_carspec.TabIndex = 22;
            txt_carspec.TextChanged += txt_carspec_TextChanged;
            // 
            // checkchiffre
            // 
            checkchiffre.AutoSize = true;
            checkchiffre.DataBindings.Add(new Binding("CheckState", bindingSource1, "HasDigitCharacters", true));
            checkchiffre.Location = new Point(6, 103);
            checkchiffre.Name = "checkchiffre";
            checkchiffre.Size = new Size(81, 24);
            checkchiffre.TabIndex = 21;
            checkchiffre.Text = "Chiffres";
            checkchiffre.UseVisualStyleBackColor = true;
            // 
            // checkcar
            // 
            checkcar.AutoSize = true;
            checkcar.Location = new Point(6, 133);
            checkcar.Name = "checkcar";
            checkcar.Size = new Size(161, 24);
            checkcar.TabIndex = 20;
            checkcar.Text = "Caractères spéciaux";
            checkcar.UseVisualStyleBackColor = true;
            // 
            // checkmaj
            // 
            checkmaj.AutoSize = true;
            checkmaj.DataBindings.Add(new Binding("CheckState", bindingSource1, "HasUppercaseCharacters", true));
            checkmaj.Location = new Point(6, 73);
            checkmaj.Name = "checkmaj";
            checkmaj.Size = new Size(97, 24);
            checkmaj.TabIndex = 17;
            checkmaj.Text = "Majuscule";
            checkmaj.UseVisualStyleBackColor = true;
            // 
            // longueurmdp
            // 
            longueurmdp.AutoSize = true;
            longueurmdp.Location = new Point(401, 37);
            longueurmdp.Name = "longueurmdp";
            longueurmdp.Size = new Size(23, 20);
            longueurmdp.TabIndex = 19;
            longueurmdp.Text = "??";
            // 
            // longueur
            // 
            longueur.AutoSize = true;
            longueur.Location = new Point(26, 37);
            longueur.Name = "longueur";
            longueur.Size = new Size(71, 20);
            longueur.TabIndex = 18;
            longueur.Text = "Longueur";
            // 
            // trackbar
            // 
            trackbar.DataBindings.Add(new Binding("Value", bindingSource1, "Length", true));
            trackbar.Location = new Point(187, 16);
            trackbar.Maximum = 50;
            trackbar.Minimum = 6;
            trackbar.Name = "trackbar";
            trackbar.Size = new Size(202, 56);
            trackbar.TabIndex = 17;
            trackbar.Value = 12;
            trackbar.Scroll += trackbar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(621, 161);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 17;
            label1.Text = "qualite";
            label1.Click += label1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.AllowDrop = true;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(821, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(0, 427);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(131, 20);
            lblCount.TabIndex = 19;
            lblCount.Text = "Nombre de mdp : ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(821, 451);
            Controls.Add(lblCount);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(generermdp);
            Controls.Add(copier);
            Controls.Add(Affichermdp);
            Controls.Add(Motdepasse);
            Controls.Add(txt_mdp);
            Controls.Add(Description);
            Controls.Add(Titre);
            Controls.Add(txt_description);
            Controls.Add(txt_titre);
            Controls.Add(panel1);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            Cursor = Cursors.Cross;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Generateur de mot de passe";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackbar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private Button Nouveau;
        private Button Modifier;
        private Button Sauvegarder;
        private Button Effacer;
        private ListBox listBox1;
        private Panel panel1;
        private TextBox txt_titre;
        private TextBox txt_description;
        private Label Titre;
        private Label Description;
        private TextBox txt_mdp;
        private Label Motdepasse;
        private CheckBox Affichermdp;
        private Button copier;
        private Button generermdp;
        private GroupBox groupBox1;
        private TrackBar trackbar;
        private Label longueur;
        private Label longueurmdp;
        private CheckBox checkchiffre;
        private CheckBox checkcar;
        private CheckBox checkmaj;
        private TextBox txt_carspec;
        private BindingSource bindingSource1;
        private Label label2;
        private Label label1;
        private MenuStrip menuStrip1;
        private TextBox txt_url;
        private Label lblCount;
        private TextBox txtNote;
    }
}
