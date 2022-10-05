#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;

#endregion

namespace RAAEventHandlerExample
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }

    // this is the event handler class
    // it contains the code to execute when the event is raised 
    internal class CreateSheetEvent : IExternalEventHandler
    {
        public void Execute(UIApplication uiapp)
        {
            Document Doc = uiapp.ActiveUIDocument.Document;

            FilteredElementCollector f = new FilteredElementCollector(Doc);
            f.OfCategory(BuiltInCategory.OST_TitleBlocks);
            f.WhereElementIsElementType();

            ElementId tblockId = f.FirstElementId();

            using (Transaction t = new Transaction(Doc))
            {
                t.Start("Create sheet");
                ViewSheet.Create(Doc, tblockId);
                t.Commit();
            }
        }

        public string GetName()
        {
            return "Create Sheet";
        }
    }
}
