using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AccountFormsApp
{
    public partial class Form1 : Form
    {
        IAccountServices accService = new AccountService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string accountName = accName.Text;
            decimal accountBalance;

            //prevents an error if nothing is put in the balance box
            if (accBalance.Text == "")
            {
                
                accountBalance = 0;
            }
            else
            {
                accountBalance = Decimal.Parse(accBalance.Text);
            }
            
            lbAccounts.Items.Add(accountName);

            accService.CreateAccount(accountName, AccountType.Silver);
            accService.Deposit(accountName, accountBalance);
        }

        private void lbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accName = lbAccounts.SelectedItem.ToString();

            decimal balance = accService.GetAccountBalance(accName);
            accBalance.Text = balance.ToString();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal deposit = Decimal.Parse(accDeposit.Text);
            string accountName = lbAccounts.SelectedItem.ToString();
            
            accService.Deposit(accountName, deposit);

            decimal balance = accService.GetAccountBalance(accountName);
            accBalance.Text = balance.ToString();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            decimal withdraw = Decimal.Parse(accWithdraw.Text);
            string accountName = lbAccounts.SelectedItem.ToString();
            
            accService.Withdrawal(accountName, withdraw);

            decimal balance = accService.GetAccountBalance(accountName);
            accBalance.Text = balance.ToString();
        }
    }
}
