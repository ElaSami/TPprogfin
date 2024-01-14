using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Zxcvbn;

namespace Generateur_de_Mot_de_passe
{
    public partial class Form1 : Form
    {
        private Password password;
        private List<Password> passwordsList = new List<Password>();
        private BindingList<Password>? passwordsBindingList;
        public Form1()
        {
            InitializeComponent();
            // Initialiser la TrackBar
            LoadPasswordsFromFile();
            trackbar.Minimum = 6;
            trackbar.Maximum = 50;
            trackbar.Value = 12;
            trackbar.TickFrequency = 1;
            trackbar.SmallChange = 1;
            trackbar.LargeChange = 5;
            trackbar.Scroll += new EventHandler(trackbar_Scroll);
            txt_carspec.Enabled = false;
            txt_description.Enabled = false;
            txt_titre.Enabled = false;
            generermdp.Enabled = false;
            checkcar.Enabled = false;
            checkchiffre.Enabled = false;
            checkmaj.Enabled = false;
            txt_mdp.Enabled = false;
            trackbar.Enabled = false;
            Sauvegarder.Enabled = false;
            // Initialiser le champ URL
            txt_url = new TextBox();
            txt_url.Location = new Point(321, 240);
            txt_url.Size = new Size(271, 27);
            txt_url.Name = "txt_url";
            Controls.Add(txt_url);
            txtNote = new TextBox();
            Controls.Add(txtNote);
            // Cr�ez une instance de Password
            password = new Password();
            // Cr�er le lien entre le champ de texte txtNote et la propri�t� Note de l'objet Password
            txtNote.DataBindings.Add("Text", password, "Note", false, DataSourceUpdateMode.OnPropertyChanged);

            // D�sactiver le contr�le txtNote par d�faut
            txtNote.Enabled = false;



            // Initialiser le Label
            longueurmdp.Text = trackbar.Value.ToString();
            txt_mdp.UseSystemPasswordChar = true;

        }
        private int compteurMotDePasse = 1;
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // V�rifie s'il y a des �l�ments s�lectionn�s dans la liste
            if (listBox1.SelectedItems.Count != 0)
            {
                // R�cup�re l'�l�ment s�lectionn�
                password = (Password)listBox1.SelectedItem;

                // Active les champs et boutons pour la modification
                Sauvegarder.Enabled = true;
                txt_carspec.Enabled = true;
                txt_description.Enabled = true;
                generermdp.Enabled = true;
                checkcar.Enabled = true;
                checkchiffre.Enabled = true;
                checkmaj.Enabled = true;
                txt_mdp.Enabled = true;
                trackbar.Enabled = true;
                txt_titre.Enabled = true;

                // D�sactive les boutons et champs inutiles pendant la modification
                Modifier.Enabled = false;
                Effacer.Enabled = false;
                Affichermdp.Enabled = false;
                copier.Enabled = false;
            }
            else
            {
                MessageBox.Show("Veuillez s�lectionner un �l�ment dans la liste avant de cliquer sur Modifier.");
                return;
            }
        }
        private void LoadPasswordsFromFile()
        {
            try
            {
                // Sp�cifiez le chemin du fichier o� vous souhaitez stocker les mots de passe
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "mdpsauv.json"
                );

                // V�rifiez si le fichier existe
                if (File.Exists(filePath))
                {
                    // Lisez le contenu du fichier
                    string json = File.ReadAllText(filePath);

                    // D�s�rialisez le JSON en une liste de mots de passe
                    List<Password> loadedPasswords = JsonConvert.DeserializeObject<List<Password>>(json);

                    // Mettez � jour votre liste de mots de passe
                    passwordsList = loadedPasswords;

                    // Mettez � jour la source de donn�es de la liste
                    passwordsBindingList = new BindingList<Password>(passwordsList);
                    listBox1.DataSource = passwordsBindingList;
                    listBox1.DisplayMember = "Description";

                    // Mettez � jour le Label avec le nombre de mots de passe
                    UpdatePasswordCountLabel();
                }
            }
            catch (Exception ex)
            {
                // G�rez les exceptions en cons�quence (par exemple, affichez un message d'erreur)
                MessageBox.Show($"Erreur lors du chargement des mots de passe : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            // V�rifie s'il y a des �l�ments s�lectionn�s dans la liste
            if (listBox1.SelectedItems.Count != 0)
            {
                // Supprime l'�l�ment s�lectionn� de la liste
                passwordsList.Remove((Password)listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);

                // Efface les champs de texte
                txt_titre.Text = "";
                txt_description.Text = "";
                txt_mdp.Text = "";
                txt_carspec.Text = "";
                longueurmdp.Text = "";

                // D�sactive les boutons et champs inutiles
                Modifier.Enabled = false;
                Effacer.Enabled = false;
                Affichermdp.Enabled = true;
                copier.Enabled = false;

                Sauvegarder.Enabled = true;
                txt_carspec.Enabled = true;
                txt_description.Enabled = true;
                generermdp.Enabled = true;
                checkcar.Enabled = true;
                checkchiffre.Enabled = true;
                checkmaj.Enabled = true;
                txt_mdp.Enabled = true;
                trackbar.Enabled = true;
                txt_titre.Enabled = true;
            }
            else
            {
                MessageBox.Show("Veuillez s�lectionner un �l�ment dans la liste avant de cliquer sur Effacer.");
            }
        }


        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            // R�cup�rer la longueur � partir du trackbar
            int longueurMotDePasse = trackbar.Value;

            // V�rifier les options s�lectionn�es
            bool inclureMajuscules = checkmaj.Checked;
            bool inclureChiffres = checkchiffre.Checked;
            bool inclureCaracteresSpeciaux = checkcar.Checked;
            password.HasUppercaseCharacters = checkmaj.Checked;
            password.HasDigitCharacters = checkchiffre.Checked;
            password.Length = longueurMotDePasse;
            // G�n�rer le mot de passe
            if (checkcar.Checked)
            {

                // V�rifie si le champ de caract�res sp�ciaux est vide ou compos� uniquement d'espaces
                if (string.IsNullOrWhiteSpace(txt_carspec.Text))
                {
                    // Affiche un message d'erreur

                    string errorMessages = "Vous devez entrer des caract�res sp�ciaux si vous cochez la case Caract�res sp�ciaux!";
                    DialogResult result = MessageBox.Show(this, errorMessages, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else
                {
                    // Affecte les caract�res sp�ciaux et g�n�re le mot de passe
                    password.SpecialCharacters = txt_carspec.Text;
                    txt_mdp.Text = password.GeneratePassword();
                }



            }

            txt_mdp.Text = password.GeneratePassword();
            // Mettre � jour le champ de texte du mot de passe

            // Cacher le mot de passe par d�faut

        }
        private void Affichermdp_CheckedChanged(object sender, EventArgs e)
        {
            // Utiliser '*' comme caract�re de remplacement pour le mot de passe
            txt_mdp.UseSystemPasswordChar = !Affichermdp.Checked;
        }



        private void checkBoxcar_CheckedChanged(object sender, EventArgs e)
        {


            if (checkcar.Checked)
            {
                txt_carspec.ReadOnly = false;
            }
            else
            {
                txt_carspec.Text = string.Empty;
                txt_carspec.ReadOnly = true;
            }

        }



        // V�rifier si la cha�ne contient tous les caract�res sp�ciaux




        private void buttonCopier_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txt_mdp.Text);
        }
        private void Nouveau_Click(object sender, EventArgs e)
        {
            Sauvegarder.Enabled = true;
            txt_description.Text = string.Empty;
            txt_mdp.Text = string.Empty;
            txt_titre.Text = string.Empty;
            txt_carspec.Text = string.Empty;
            txt_carspec.Enabled = true;
            txt_description.Enabled = true;
            txt_titre.Enabled = true;
            generermdp.Enabled = true;
            checkcar.Enabled = true;
            checkchiffre.Enabled = true;
            checkmaj.Enabled = true;
            txt_mdp.Enabled = true;
            trackbar.Enabled = true;
            txt_mdp.ReadOnly = false;
            password = new Password();
            listBox1.SelectedItem = null;
            bindingSource1.DataSource = password;
            bindingSource1.ResetBindings(false);
            // R�initialiser la TextBox de l'URL et activer la saisie
            txt_url.Text = "";
            txt_url.Enabled = true;

            // G�n�rer un mot de passe pour cet objet
            // R�initialiser la propri�t� URL du mot de passe actuel
            if (password != null)
            {
                password.URL = "";
            }


            // Mettre � jour les contr�les de l'interface utilisateur avec les valeurs du nouvel objet Password


            // Activer les boutons Modifier, Sauvegarder et Effacer
            Modifier.Enabled = true;
            Sauvegarder.Enabled = true;
            Effacer.Enabled = true;

            // Ajouter le nouvel objet Password � la liste





        }


        private void trackbar_Scroll(object sender, EventArgs e)
        {
            longueurmdp.Text = trackbar.Value.ToString();

        }



        private void txt_carspec_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sauvegarder_Click(object sender, EventArgs e)
        {
            // V�rifier si les champs sont vides
            if (string.IsNullOrEmpty(txt_titre.Text) || string.IsNullOrEmpty(txt_description.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs avant de sauvegarder.");
                return;
            }

            DialogResult result = MessageBox.Show("Souhaitez-vous sauvegarder ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cr�er un nouvel objet Password avec le champ d'URL
                Password newPassword = new Password
                {
                    Description = txt_titre.Text,
                    UserAccount = txt_description.Text,
                    HasUppercaseCharacters = checkmaj.Checked,
                    HasDigitCharacters = checkchiffre.Checked,
                    SpecialCharacters = txt_carspec.Text,
                    Length = trackbar.Value,
                    URL = txt_url.Text,// R�cup�rer l'URL depuis le champ

                };
                if (password != null)
                {
                    password.URL = txt_url.Text;
                }


                // V�rifier si un mot de passe avec le m�me titre ou la m�me description existe d�j�
                var existingPassword = passwordsList.FirstOrDefault(p => p.Description == newPassword.Description);

                if (existingPassword != null)
                {
                    // Mettre � jour l'affichage dans la listBox si n�cessaire
                    if (listBox1.Items.Contains(existingPassword))
                    {
                        MessageBox.Show("Un mot de passe avec le m�me titre existe d�j�. Veuillez choisir un titre diff�rent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Mise � jour du Label avec le nombre de mots de passe
                UpdatePasswordCountLabel();

                // Ajouter le nouveau mot de passe � la liste
                passwordsBindingList.Add(newPassword);
                // Sauvegarder la liste des mots de passe dans un fichier JSON
                SavePasswordsToFile();

                // R�initialiser les champs
                txt_titre.Text = "";
                txt_description.Text = "";
                txt_carspec.Text = "";
                txt_url.Text = "";

                Sauvegarder.Enabled = false;
                txt_carspec.Enabled = false;
                txt_description.Enabled = false;
                generermdp.Enabled = false;
                checkcar.Enabled = false;
                checkchiffre.Enabled = false;
                checkmaj.Enabled = false;
                trackbar.Enabled = false;
                // Affecter la valeur de txtNote � la propri�t� Note de l'objet Password
                password.Note = txtNote.Text;

                // D�sactiver le contr�le txtNote apr�s la sauvegarde
                txtNote.Enabled = false;

                txt_titre.Enabled = false;
                bindingSource1.ResetBindings(false);
            }

        }
        private void SavePasswordsToFile()
        {
            try
            {
                // Sp�cifiez le chemin du fichier o� vous souhaitez stocker les mots de passe
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "mdpsauv.json"
                );

                // S�rialisez la liste des mots de passe en format JSON
                string json = JsonConvert.SerializeObject(passwordsList, Formatting.Indented);

                // �crivez le contenu JSON dans le fichier
                File.WriteAllText(filePath, json);

                MessageBox.Show("Liste des mots de passe sauvegard�e avec succ�s.", "Succ�s", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // G�rez les exceptions en cons�quence (par exemple, affichez un message d'erreur)
                MessageBox.Show($"Erreur lors de la sauvegarde des mots de passe : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPasswordsFromFile()
        {
            try
            {
                // Sp�cifiez le chemin du fichier o� vous souhaitez stocker les mots de passe
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "mdpsauv.json"
                );

                // V�rifiez si le fichier existe
                if (File.Exists(filePath))
                {
                    // Lisez le contenu du fichier
                    string json = File.ReadAllText(filePath);

                    // D�s�rialisez le JSON en une liste de mots de passe
                    List<Password> loadedPasswords = JsonConvert.DeserializeObject<List<Password>>(json);

                    // Mettez � jour votre liste de mots de passe
                    passwordsList = loadedPasswords;

                    // Mettez � jour la source de donn�es de la liste
                    passwordsBindingList = new BindingList<Password>(passwordsList);
                    listBox1.DataSource = passwordsBindingList;
                    listBox1.DisplayMember = "Description";

                    // Mettez � jour le Label avec le nombre de mots de passe
                    UpdatePasswordCountLabel();
                }
            }
            catch (Exception ex)
            {
                // G�rez les exceptions en cons�quence (par exemple, affichez un message d'erreur)
                MessageBox.Show($"Erreur lors du chargement des mots de passe : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // V�rifie s'il y a des �l�ments s�lectionn�s dans la liste
            if (listBox1.SelectedItems.Count != 0)
            {
                // V�rifie si l'�l�ment s�lectionn� n'est pas nul
                if (listBox1.SelectedItem != null)
                {
                    // R�cup�re le mot de passe s�lectionn� dans la liste
                    password = (Password)listBox1.SelectedItem;
                    bindingSource1.DataSource = password;
                    // Met � jour les champs de texte avec les informations du mot de passe



                    Modifier.Enabled = true;
                    Effacer.Enabled = true;
                    Affichermdp.Enabled = true;
                    copier.Enabled = true;



                }
                else
                {

                    Modifier.Enabled = false;
                    Effacer.Enabled = false;
                }
            }
            else
            {

                Modifier.Enabled = false;
                Effacer.Enabled = false;
            }
            bindingSource1.ResetBindings(false);
        }
      


        private void Form1_Load(object sender, EventArgs e)
        {
            passwordsBindingList = new BindingList<Password>(passwordsList);
            listBox1.DataSource = passwordsBindingList;
            listBox1.DisplayMember = "Description";
            txt_url.Enabled = false; // D�sactiver la saisie d'URL par d�faut
            // Charger la liste des mots de passe depuis le fichier au d�marrage
            LoadPasswordsFromFile();
        }

        private void CheckPaswordQuality()
        {
            if (txt_mdp.Text != "")
            {
                Result result = Zxcvbn.Core.EvaluatePassword(txt_mdp.Text);
                if (result.Score == 0)
                    label1.Text = "Mot de passe tr�s mauvais";
                else if (result.Score == 1)
                    label1.Text = "Mot de passe mauvais";
                else if (result.Score == 2)
                    label1.Text = "Mot de passe moyen";
                else if (result.Score == 3)
                    label1.Text = "Mot de passe s�curis�";
                else if (result.Score == 4)
                    label1.Text = "Mot de passe tr�s s�curis�";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_mdp_TextChanged(object sender, EventArgs e)
        {
            CheckPaswordQuality();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            // Mise � jour de la propri�t� URL de l'objet Password lorsque le texte change
            if (password != null)
            {
                password.URL = txt_url.Text;
            }
        }
        private void UpdatePasswordCountLabel()
        {
            // Mettre � jour le Label avec le nombre de mots de passe
            lblCount.Text = $"Nombre de mots de passe : {passwordsBindingList.Count + 1}";
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

