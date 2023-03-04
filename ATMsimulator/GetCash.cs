﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMsimulator
{
    public partial class GetCash : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"D:\\C Projs\\ATMsimulator\\ATMsimulator\\СlientСardDB.mdb\"";
        private OleDbConnection connection;
        public GetCash()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectString);
            connection.Open();
        }
        private void GetCash_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
        private void buttonGetEnterCash_Click(object sender, EventArgs e)
        {
            string requestPastBalance = $"SELECT [balance] FROM ClientCard WHERE PIN = '{LogIn.PIN}'";
            OleDbCommand commandPastBalance = new OleDbCommand(requestPastBalance, connection);
            string pastBalance = commandPastBalance.ExecuteScalar().ToString();

            double balance = Convert.ToDouble(pastBalance) - Convert.ToDouble(textBoxGetCash.Text);
            string requestNewBalance = $"UPDATE ClientCard SET [balance] = {balance} WHERE PIN = '{LogIn.PIN}'";
            OleDbCommand commandCardNumber = new OleDbCommand(requestNewBalance, connection);
            commandCardNumber.ExecuteNonQuery();
            MessageBox.Show($"{textBoxGetCash.Text} geted successfully\nBalance: {balance}");
        }

        private void buttonGet100_Click(object sender, EventArgs e)
        {
            textBoxGetCash.Text = "100";
        }

        private void buttonGet500_Click(object sender, EventArgs e)
        {
            textBoxGetCash.Text = "500";
        }

        private void buttonGet1000_Click(object sender, EventArgs e)
        {
            textBoxGetCash.Text = "1000";
        }

        private void buttonGet2000_Click(object sender, EventArgs e)
        {
            textBoxGetCash.Text = "2000";
        }
    }
}
