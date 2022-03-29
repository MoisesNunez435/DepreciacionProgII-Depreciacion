﻿using AppCore.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class FrmActivo : Form
    {
        public IActivoServices aservices { get; set; }
        int index;
        public FrmActivo(int index)
        {
            this.index = index;
            InitializeComponent();
        }
        private void IndexVerification()
        {
            if(index < 0)
            {
                btnModificar.Visible = false;
                txtEnviar.Visible = true;
            }
            else
            {
                btnModificar.Visible = true;
                txtEnviar.Visible = false;
                Activo a = aservices.Read()[index];
                txtNombre.Text = a.Nombre;
                txtValor.Text = a.Valor.ToString();
                txtValorR.Text = a.ValorResidual.ToString();
                txtVidaU.Text = a.VidaUtil.ToString();
            }
        }
        private void FrmActivo_Load(object sender, EventArgs e)
        {
            IndexVerification();
        }

        private void txtEnviar_Click(object sender, EventArgs e)
        {
            
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {

                Activo activo = new Activo()
                {
                    Nombre = txtNombre.Text,
                    Valor = double.Parse(txtValor.Text),
                    ValorResidual = double.Parse(txtValorR.Text),
                    VidaUtil = int.Parse(txtVidaU.Text)
                };
                aservices.Add(activo);
                limpiar();
                Dispose();

            }
            
        }
        private bool verificar()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(txtVidaU.Text) || String.IsNullOrEmpty(txtValorR.Text))
            {

                return false;
            }
            return true;
        }
        private void limpiar()
        {
            this.txtNombre.Text = String.Empty;
            this.txtValor.Text = String.Empty;
            this.txtValorR.Text = String.Empty;
            this.txtVidaU.Text = String.Empty;
        }

        private void txtValorR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtVidaU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            Activo a = aservices.Read()[index];
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
            else
            {

                Activo activo = new Activo()
                {
                    Id = a.Id,
                    Nombre = txtNombre.Text,
                    Valor = double.Parse(txtValor.Text),
                    ValorResidual = double.Parse(txtValorR.Text),
                    VidaUtil = int.Parse(txtVidaU.Text)
                };
                aservices.Update(activo);
                limpiar();
                Dispose();


            }
        }
    }
}
