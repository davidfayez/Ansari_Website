﻿using ERP.DAL.Domains;
using ERP.DAL.Domains.Def;
using Ansari_Website.Domain.Entities.Def;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ansari_Website.Domain.Entities.Identity;

    [Table("AspNetUserDefBranch")]
    public class AspNetUserDefBranch : AuditableEntity
    {
		public int Id { get; set; }
		public int DefBranchId { get; set; }
        public string AspNetUserId { get; set; }
		public virtual DefBranch DefBranch { get; set; }
		public virtual AspNetUser AspNetUser { get; set; }
	}

