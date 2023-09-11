using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDataLayer.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        protected Entity()
        {
        }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}
