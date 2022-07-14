using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public partial class frmKorisniciDetails : Form
    {
        public APIService KorisniciService { get; set; } = new APIService("Korisnici");
        public APIService RoleService { get; set; } = new APIService("Uloge");
        private Korisnici _model = null;
        public frmKorisniciDetails(Korisnici model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private async void frmKorisniciDetails_Load(object sender, EventArgs e)
        {
            await LoadRoles();

            if(_model != null)
            {
                txtIme.Text = _model.Ime;
                txtPrezime.Text = _model.Prezime;
                txtEmail.Text = _model.Email;
                txtUsername.Text = _model.KorisnickoIme;
                ckbStatus.Checked = _model.Status.GetValueOrDefault(false);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var roleList = clbUloge.CheckedItems.Cast<Uloge>().ToList();
                var roleIdList = roleList.Select(x => x.UlogaId).ToList();

                if (_model == null)
                {
                    KorisniciInsertRequest insertObject = new KorisniciInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        KorisnickoIme = txtUsername.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtConfirmation.Text,
                        Status = ckbStatus.Checked,
                        UlogeIdList = roleIdList
                    };

                    var user = await KorisniciService.Post<Korisnici>(insertObject);
                }
                else
                {
                    KorisniciUpdateRequest updateObject = new KorisniciUpdateRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtConfirmation.Text,
                        Status = ckbStatus.Checked,
                    };

                    _model = await KorisniciService.Put<Korisnici>(_model.KorisnikId, updateObject);
                }
            }           

        }

        private async Task LoadRoles()
        {
            var roles = await RoleService.Get<List<Uloge>>();

            clbUloge.DataSource = roles;
            clbUloge.DisplayMember = "Naziv";
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                e.Cancel = true;
                txtIme.Focus();
                errorProvider.SetError(txtIme, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtIme, "");
            }
        }
    }
}
