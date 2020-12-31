﻿using System.Collections.Generic;
using System.Web.UI.WebControls;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title => (Customer?.Id ?? 0) == 0 ? "New Customer" : "Edit Customer";
    }
}