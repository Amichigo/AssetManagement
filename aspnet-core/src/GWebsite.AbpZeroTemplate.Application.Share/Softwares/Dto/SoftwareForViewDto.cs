﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Softwares.Dto
{
    public class SoftwareForViewDto
    {
        public string Cpuname { get; set; }
        public string Displayname { get; set; }
        public string DisplayVersion { get; set; }
        public string Publisher { get; set; }
        public string Installdate { get; set; }
        public string InstallLocation { get; set; }
        public string InstallSource { get; set; }
        public string URLInfoAbout { get; set; }
        public string URLUpdateInfo { get; set; }
    }
}
