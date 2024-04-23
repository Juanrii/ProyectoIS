﻿using System;
using System.Windows.Forms;
using Abstraccion;
using BE;
using BLL;
using Servicios.SesionManager;

namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
            // Ocultar la password
            inputPsw.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CamposInvalidos()) throw new Exception("Los campos ingresados son incorrectos. Por favor vuelva a ingresarlos.");

                BEUsuario u = new BEUsuario()
                {
                    Username = inputUsuario.Text,
                    Password = inputPsw.Text
                };

                bool valido = BLLUsuario.Buscar(u);

                if (!valido) throw new Exception("Credenciales incorrectas.Por favor vuelva a ingresar los datos.");

                IUsuario usuario = new BEUsuario
                {
                    Username = u.Username,
                    Password = u.Password
                };

                SesionManager.Login(usuario);
                MessageBox.Show(
                    $"Usuario logeado: {SesionManager.GetUsername()}",
                    "Logeado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Sistema sistema = new Sistema();
                sistema.Show();
                Hide();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool CamposInvalidos()
        {
            return String.IsNullOrEmpty(inputUsuario.Text.Trim()) ||
                String.IsNullOrEmpty(inputPsw.Text.Trim());
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro formRegistro = new Registro();
            formRegistro.Show();
        }
    }
  
}
