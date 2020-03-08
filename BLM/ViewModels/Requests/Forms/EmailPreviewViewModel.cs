using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static BLM.ViewModels.Requests.Forms.NewRequestViewModel;

namespace BLM.ViewModels.Requests.Forms
{
    internal class EmailPreviewViewModel : Screen
    {
        private List<MissingMaterial> _missingMaterials;

        public EmailPreviewViewModel(List<MissingMaterial> missingMaterials)
        {
            _missingMaterials = missingMaterials;
        }

        private string _txtEmailList;

        public string txtEmailList
        {
            get { return _txtEmailList; }
            set { _txtEmailList = value; }
        }

        protected override void OnActivate()
        {
            fillEmailList();
            base.OnActivate();
        }

        private void fillEmailList()
        {
            var emailGroups = from MissingMaterial in _missingMaterials group MissingMaterial by MissingMaterial.Email;
            foreach (var group in emailGroups)
            {
                _txtEmailList += group.Key;
                _txtEmailList += Environment.NewLine + "-------------------------";
                foreach (var material in group)
                {
                    _txtEmailList += Environment.NewLine + "   -" + material.MaterialName + " (x" + material.RequiredQuantity + ")";
                }
                _txtEmailList += Environment.NewLine + Environment.NewLine;
            }
            NotifyOfPropertyChange(() => txtEmailList);
        }

        public void btnSave()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to send out these emails?", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                emailSuppliers();
                TryClose();
            }
        }

        private void emailSuppliers()
        {
            var emailGroups = from MissingMaterial in _missingMaterials group MissingMaterial by MissingMaterial.Email;
            foreach (var group in emailGroups)
            {
                string subject = "Request for materials";
                string email = group.Key;
                string name = "";
                string body = @"We would like to request the following materials: ";
                foreach (var material in group)
                {
                    name = material.SupplierName;
                    body += System.Environment.NewLine + material.MaterialName + "(x" + material.RequiredQuantity + ")";
                }
                body += System.Environment.NewLine + "We hope to receive your reply as soon as possible.";
                body += System.Environment.NewLine + "Thank you.";
                body += System.Environment.NewLine + "[THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL]";
                Connection.sendEmail(subject, body, name, email);
            }
        }
    }
}