﻿
namespace _EPAM_Forum.Entites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleDTO(string name)
        {
            this.Name = name;
        }

        public RoleDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
