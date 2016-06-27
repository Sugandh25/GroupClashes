﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api;

namespace GroupClashes
{
    // AddIn plugin to show/hide the Group Clashes Addin 
    
    [PluginAttribute("GroupClashes", "BM42", 
        ToolTip = "Groups clashes according to the items involved", 
        DisplayName = "Group Clashes")]
    [AddInPluginAttribute(AddInLocation.AddIn, LoadForCanExecute = true)]

    class GroupClashes : AddInPlugin
    {
        private GroupClashesInterface groupClashesInterface;
        public override int Execute(params string[] parameters)
        {
            groupClashesInterface.ShowDialog();
            //theDialog.Setup();
            //theDialog.ShowDialog();
            return 0;
        }

        protected override void OnLoaded()
        {
            groupClashesInterface = new GroupClashesInterface();
            //theDialog = new ClashGrouperDialog();
            //ClashGrouperUtils.Init();
        }

        public override CommandState CanExecute()
        {
            try
            {
                //Inactive if there is no document open or there are no clash tests
                if (Application.MainDocument == null
                    || Application.MainDocument.IsClear
                    || Application.MainDocument.GetClash() == null
                    || Application.MainDocument.GetClash().TestsData.Tests.Count == 0)
                    return new CommandState(false);
            }
            catch
            {
                return new CommandState(false);
            }
            return new CommandState(true);
        }
    }
}


