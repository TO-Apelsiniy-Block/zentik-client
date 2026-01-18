using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zentik.Controllers;

namespace Zentik.Views
{
    internal class EmailSearchView
    {
        public event EventHandler<string> EmailSearching;

        private readonly TextBox _emailSearchTextBox;
        public EmailSearchView(TextBox emailSearchTextBox)
        {
            _emailSearchTextBox = emailSearchTextBox;
            _emailSearchTextBox.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                    OnEnter();
            };
        }

        private void OnEnter()
        {
            EmailSearching.Invoke(this, _emailSearchTextBox.Text);
        }

        public void Clear()
        {
            _emailSearchTextBox.Clear();
        }


    }
}
