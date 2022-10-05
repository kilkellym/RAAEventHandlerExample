#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RAAEventHandlerExample
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // create an instance of the event handler then create the event
            IExternalEventHandler curEvent = new CreateSheetEvent();
            ExternalEvent exEvent = ExternalEvent.Create(curEvent);

            Form1 curForm = new Form1(exEvent);
            curForm.TopMost = true;
            curForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            curForm.Show(); // modeless dialog
            //curForm.ShowDialog(); // modal dialog

            return Result.Succeeded;
        }
    }
}
