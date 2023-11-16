using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HotelManagement.Areas.Admin.ViewModels
{
    public class AddRoleToUserViewModel
    {
        public string MyRoleId { get; set; }
        public int MyUserId { get; set; }
        public string MyUsername { get; set; }
        public List<AppRole> MyRoleList { get; set; }
    }
}
