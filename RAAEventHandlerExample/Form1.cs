using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RAAEventHandlerExample
{
    public partial class Form1 : Forms.Form
    {
        // create a public variable for the event so the button can access it
        public ExternalEvent curEvent;

        // pass in the external event as an argument
        public Form1(ExternalEvent exEvent)
        {
            InitializeComponent();

            curEvent = exEvent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // execute the event using the Raise method
            curEvent.Raise();
        }
    }
}
